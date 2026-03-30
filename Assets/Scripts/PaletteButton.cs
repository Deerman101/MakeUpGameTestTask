using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaletteButton : MonoBehaviour
{
    public Color assignedColor;
    public Sprite assignedSprite;
    public Item linkedItem; // кисточка, которую выбираем

    public Image maskInHand;

    public void OnClick()
    {
        assignedColor.a = 0.8f;

        if (maskInHand != null)
            maskInHand.color = assignedColor;

        linkedItem.PickColor(assignedColor, assignedSprite);
    }
}
