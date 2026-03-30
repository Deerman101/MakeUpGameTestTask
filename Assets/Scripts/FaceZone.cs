using UnityEngine;

public class FaceZone : MonoBehaviour
{
    public bool IsInside;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            IsInside = true;
            Debug.Log("Рука ВНУТРИ зоны лица");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            IsInside = false;
            Debug.Log("Рука ВНЕ зоны лица");
        }
    }
}