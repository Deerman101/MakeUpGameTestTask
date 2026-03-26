using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Vector3 startPos;

    public enum ItemType
    {
        Cream,
        Eyeshadow,
        Lipstick
    }

    public ItemType type;

    public MakeupManager makeup;

    void Start()
    {
        startPos = transform.position;
    }

    void OnMouseDown()
    {
        FindObjectOfType<HandController>().TakeItem(gameObject);
    }

    public void Apply()
    {
        switch (type)
        {
            case ItemType.Cream:
                makeup.ApplyCream();
                break;

            case ItemType.Eyeshadow:
                makeup.ApplyEyeshadow();
                break;

            case ItemType.Lipstick:
                makeup.ApplyLipstick();
                break;
        }
    }
}
