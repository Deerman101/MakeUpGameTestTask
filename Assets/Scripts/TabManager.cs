using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public GameObject[] tabPanels;
    public Button[] tabButtons;

    public void TurnOnTabPanel(int tabIndex)
    {
        for (int i = 0; i < tabPanels.Length; i++)
        {
            tabButtons[i].interactable = true;
            tabPanels[i].SetActive(false);
        }
        tabPanels[tabIndex - 1].SetActive(true);
        tabButtons[tabIndex - 1].interactable = false;
    }
}
