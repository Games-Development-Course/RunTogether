using UnityEngine;
using UnityEngine.EventSystems;

public class MapPanZoom : MonoBehaviour, IDragHandler, IScrollHandler
{
    public RectTransform mapTransform;
    public float zoomSpeed = 0.1f;
    public float minZoom = 0.5f;
    public float maxZoom = 2.5f;

    public void OnDrag(PointerEventData eventData)
    {
        mapTransform.anchoredPosition += eventData.delta;
    }

    public void OnScroll(PointerEventData eventData)
    {
        float delta = eventData.scrollDelta.y * zoomSpeed;

        float newScale = Mathf.Clamp(mapTransform.localScale.x + delta, minZoom, maxZoom);
        mapTransform.localScale = new Vector3(newScale, newScale, 1);
    }
}