using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;


    public void OnPointerClick(PointerEventData eventData) // Ŭ�� �̺�Ʈ �������̵�
    {
        if (OnClickHandler != null)
            OnClickHandler.Invoke(eventData); // Ŭ���� ���õ� �׼� ����
    }

    public void OnDrag(PointerEventData eventData) // �巡�� �̺�Ʈ �������̵�
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData); // �巡�׿� ���õ� �׼� ����
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�׽���");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�׳�");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("����?");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Ŭ�� u��");
    }
}
