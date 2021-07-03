using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestDrug : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("OnBeginDrag");
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        Debug.Log("OnEndDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // try
        // {
        //     throw new OloloException("jojo");
        // }
        // catch(OloloException exception)
        // {
        //     Debug.Log(exception.Message);
        // }

        rectTransform.anchoredPosition += eventData.delta;
    }
}
