using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class HandController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private bool isDragging; // для тестов drag and drop'а
    [SerializeField] private bool isBusy;
    [SerializeField] private bool canDrag;

    public RectTransform handRect;
    public FaceZone faceZone;
    public Action<bool> OnDrop; 

    void Awake() => handRect = GetComponent<RectTransform>();

    public void SetBusy(bool value) => isBusy = value;

    public void EnableDrag(bool value) => canDrag = value;

    public bool IsOverFace()
    {
        return faceZone != null && faceZone.IsInside;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isBusy || !canDrag) return;
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        bool success = IsOverFace();

        Debug.Log("DROP: " + success);
        OnDrop?.Invoke(success);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isBusy || !isDragging || !canDrag) return;

        handRect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}