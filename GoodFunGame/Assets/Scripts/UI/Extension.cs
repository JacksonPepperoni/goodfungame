using System;
using UnityEngine.EventSystems;
using UnityEngine;

public static class Extension
{
    
    // 확장메서드
    public static void BindEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.BindEvent(go, action, type);
    }
}
