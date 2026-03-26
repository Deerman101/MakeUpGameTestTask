using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeupManager : MonoBehaviour
{
    public GameObject acneFace;

    public GameObject eyeshadow;
    public GameObject lips;

    public void ApplyCream()
    {
        acneFace.SetActive(false);
    }

    public void ApplyEyeshadow()
    {
        eyeshadow.SetActive(true);
    }

    public void ApplyLipstick()
    {
        lips.SetActive(true);
    }

    public void ResetMakeup()
    {
        acneFace.SetActive(true);

        eyeshadow.SetActive(false);
        lips.SetActive(false);
    }
}
