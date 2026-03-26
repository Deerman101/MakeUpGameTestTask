using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Transform holdPoint;
    public Transform defaultPos;

    private Camera cam;

    private bool isDragging;
    private bool canApply;

    private GameObject currentItem;

    public FaceZone faceZone;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (isDragging)
        {
            Drag();
        }
    }

    void Drag()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 5f;

        Vector3 world = cam.ScreenToWorldPoint(pos);
        transform.position = world;
    }

    public void TakeItem(GameObject item)
    {
        if (currentItem != null) return;

        currentItem = item;

        item.transform.SetParent(holdPoint);
        item.transform.DOLocalMove(Vector3.zero, 0.3f);
        item.transform.DOLocalRotate(Vector3.zero, 0.3f);

        transform.DOMoveY(0f, 0.3f); // уровень груди

        canApply = false;
        Invoke(nameof(EnableDrag), 0.3f);
    }

    void EnableDrag()
    {
        isDragging = true;
    }

    public void Release()
    {
        isDragging = false;

        if (faceZone.IsInside)
        {
            Apply();
        }
        else
        {
            ReturnItem();
        }
    }

    void Apply()
    {
        canApply = true;

        transform.DOScale(1.1f, 0.1f).SetLoops(2, LoopType.Yoyo);

        currentItem.GetComponent<Item>().Apply();

        Invoke(nameof(ReturnItem), 0.5f);
    }

    void ReturnItem()
    {
        isDragging = false;
        canApply = false;

        currentItem.transform.SetParent(null);

        currentItem.transform.DOMove(currentItem.GetComponent<Item>().startPos, 0.4f);

        transform.DOMove(defaultPos.position, 0.4f);

        currentItem = null;
    }
}
