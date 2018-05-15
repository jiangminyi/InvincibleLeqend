using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VR.UGUI.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public delegate void PointerEventHandler(PointerEventData eventData);


    public class UIEventListener : MonoBehaviour, IPointerDownHandler,IPointerClickHandler,IPointerUpHandler
    {
        public static UIEventListener GetListener(Transform tf)
        {
            UIEventListener listener = tf.GetComponent<UIEventListener>();
            if (listener != null) return listener;
            return tf.gameObject.AddComponent<UIEventListener>();
        }
        /*
         定义事件
         1.定义事件参数类
         2.定义委托类型
         3.声明事件
         4.引发事件                     
        */
        public event PointerEventHandler PointerClick;
        public event PointerEventHandler PointerDown;
        public event PointerEventHandler PointerUp;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (PointerClick != null)
            {
                PointerClick(eventData);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (PointerDown !=null)
            {
                PointerDown(eventData);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (PointerUp != null)
            {
                PointerUp(eventData);
            }
        }
    }
}
