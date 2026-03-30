using UnityEngine;
using UnityEngine.UI;

public class MakeupManager : MonoBehaviour
{
    [Header("Face Parts")]
    public Image acneFace;
    public Image blushImg;
    public Image eyeshadowImg;
    public Image lipsImg;

    private void Start()
    {
        ResetMakeup();
    }

    public void ApplyCream() => acneFace?.gameObject.SetActive(false);

    public void ApplyBlush(Sprite sprite)
    {
        if (blushImg != null)
        {
            blushImg.sprite = sprite;
            blushImg.gameObject.SetActive(true);
        }
    }

    public void ApplyEyeshadow(Sprite sprite)
    {
        if (eyeshadowImg != null)
        {
            eyeshadowImg.sprite = sprite;
            eyeshadowImg.gameObject.SetActive(true);
        }
    }

    public void ApplyLipstick(Sprite sprite)
    {
        if (lipsImg != null)
        {
            lipsImg.sprite = sprite;
            lipsImg.gameObject.SetActive(true);
        }
    }

    public void ResetMakeup()
    {
        acneFace?.gameObject.SetActive(true);
        blushImg?.gameObject.SetActive(false);
        eyeshadowImg?.gameObject.SetActive(false);
        lipsImg?.gameObject.SetActive(false);
    }
}