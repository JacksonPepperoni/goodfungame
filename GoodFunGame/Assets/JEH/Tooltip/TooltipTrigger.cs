using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    // ���콺�÷����� �۾� ��������� �޾ƾ��� ��ũ��Ʈ.


    public string header;
    public string content;

    public void OnPointerEnter(PointerEventData eventData) //�̰͵� �ݶ��̴� ������ �νľ��ϳ�
    {
        TooltipSystem.Show(content, header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }
}
