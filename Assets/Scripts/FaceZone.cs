using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceZone : MonoBehaviour
{
    public bool IsInside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
            IsInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
            IsInside = false;
    }
}
