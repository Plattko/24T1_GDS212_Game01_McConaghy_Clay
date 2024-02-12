using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;

    [SerializeField] private RectTransform appsRectTransform;
    private float leftBound;
    private float rightBound;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        rectTransform = transform.parent.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SetBounds();
        //Debug.Log("OnPointerDown");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = rectTransform.position;
        pos.x += eventData.delta.x / canvas.scaleFactor;
        pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
        rectTransform.position = pos;
        //Debug.Log("OnDrag");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
    }

    void SetBounds()
    {
        Vector3[] appCorners = new Vector3[4];
        appsRectTransform.GetWorldCorners(appCorners);

        //for (var i = 0; i < 4; i++)
        //{
        //    Debug.Log("World corner " + i + ": " + appCorners[i]);
        //}

        leftBound = appCorners[0].x;
        rightBound = appCorners[2].x - 600f;
    }
}
