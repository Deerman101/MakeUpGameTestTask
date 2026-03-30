using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Cream,
        Eyeshadow,
        Lipstick,
        Blush
    }

    [SerializeField] private bool isPlaying = false;

    [Header("Item Settings")]
    public ItemType type;

    [Header("Scene References")]
    public RectTransform worldItem; // предмет в книжке
    public RectTransform handItem; // предмет в руке
    public RectTransform hand;
    public RectTransform handHoldPoint; // для точкb предмета в руке
    public RectTransform handDefaultPosition;

    public RectTransform faceTopPoint; // начальная точка анимации нанесения
    public RectTransform faceBottomPoint; // конечная точка анимации нанесения
    public RectTransform itemHoldPoint; // точка для предмета после выбора цвета
    public RectTransform itemStartPoint;

    [Header("Manager")]
    public MakeupManager makeup;

    [Header("Palette")]
    public Color pickedColor; // для выбранного цвета румян и тд
    public Image colorMask; // визуальная подсветка кисточки

    [Header("DevInfa")]
    public Sprite pickedSprite;

    public void OnClick()
    {
        if (isPlaying) return;

        switch (type)
        {
            case ItemType.Cream:
                PlayItem(() => makeup.ApplyCream());
                break;
            case ItemType.Eyeshadow:
                PlayItem(() => makeup.ApplyEyeshadow(pickedSprite));
                break;
            case ItemType.Blush:
                PlayItem(() => makeup.ApplyBlush(pickedSprite));
                break;
            case ItemType.Lipstick:
                PlayItem(() => makeup.ApplyLipstick(pickedSprite));
                break;
        }
    }

    private void PlayItem(Action applyEffect)
    {
        if (isPlaying) return;

        isPlaying = true;

        HandController hc = hand.GetComponent<HandController>();
        hc.SetBusy(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(hand.DOMove(worldItem.position, 0.4f));

        seq.AppendCallback(() =>
        {
            worldItem.gameObject.SetActive(false);
            handItem.gameObject.SetActive(true);

            if (handHoldPoint != null)
                handItem.position = handHoldPoint.position;
        });

        seq.Append(hand.DOMove(itemHoldPoint.position, 0.4f));

        seq.AppendCallback(() =>
        {
            hc.SetBusy(false);
            hc.EnableDrag(true);

            hc.OnDrop += OnDropHandler;

            void OnDropHandler(bool result)
            {

                if (!result)
                {
                    hc.SetBusy(false);
                    hc.EnableDrag(true);

                    isPlaying = false;
                    return;
                }

                hc.OnDrop -= OnDropHandler;

                hc.SetBusy(true);
                hc.EnableDrag(false);

                WaitForDrop(applyEffect);
            }
        });
    }

    private void WaitForDrop(Action applyEffect)
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(hand.DOMove(faceTopPoint.position, 0.2f));
        seq.Append(hand.DOMove(faceBottomPoint.position, 0.3f));

        seq.AppendCallback(() =>
        {
            applyEffect?.Invoke();
        });

        seq.Append(hand.DOMove(worldItem.position, 0.4f));

        seq.AppendCallback(() =>
        {
            handItem.gameObject.SetActive(false);
            worldItem.gameObject.SetActive(true);
        });

        seq.Append(hand.DOMove(itemStartPoint.position, 0.4f));
        seq.Append(hand.DOMove(handDefaultPosition.position, 0.4f));

        seq.AppendCallback(() =>
        {
            hand.rotation = Quaternion.identity;
            isPlaying = false;
            hand.GetComponent<HandController>().SetBusy(false);
        });
    }

    public void PickColor(Color color, Sprite sprite)
    {
        pickedColor = color;
        pickedSprite = sprite;

        if (colorMask != null)
            colorMask.color = color;
    }
}