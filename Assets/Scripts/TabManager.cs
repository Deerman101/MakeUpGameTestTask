using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    public GameObject[] tabPanels;

    public void TurnOnTabPanel(int tabIndex)
    {
        for (int i = 0; i < tabPanels.Length; i++)
            tabPanels[i].SetActive(false);
        tabPanels[tabIndex - 1].SetActive(true);
    }
}
