using Common;
using ns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace VR.UGUI.Framework
{
	/// <summary>
	///  UI窗口基类：定义所有具体窗口的共性成员(显示/隐藏)。
	/// </summary>
	public class UIWindow : MonoBehaviour 
	{
        private CanvasGroup group;
        private VRTK_UICanvas canvas;
        private Dictionary<string, UIEventListener> uiEventListenerCache;
        protected void Awake()
        {
            group = GetComponent<CanvasGroup>();
            canvas = GetComponent<VRTK_UICanvas>();
            uiEventListenerCache = new Dictionary<string, UIEventListener>();
        }
       
        //立即设置可见度
        private void SetVisibleImmediate(bool state)
        {
            group.alpha = state ? 1 : 0;
            canvas.enabled = state;
            //if (state)
            //{
            //    group.alpha = 1;
            //    canvas.enabled = true;
            //}
            //else
            //{
            //    group.alpha = 0;
            //    canvas.enabled = false;
            //} 
        }

        //延迟设置可见度
        private IEnumerator SetVisibleDelay(bool state, float delay)
        {
            yield return new WaitForSeconds(delay);
            SetVisibleImmediate(state);
        }

        //设置可见度
        public void SetVisible(bool state,float delay = 0)
        {
            StartCoroutine(SetVisibleDelay(state, delay));
        }

        //SetVisible(true,3)  -->   SetVisible(true,3)    
        //SetVisible(true)  -->   SetVisible(true,0)   

        public UIEventListener GetUIEventListener(string name)
        {
            if (!uiEventListenerCache.ContainsKey(name))
            {
                var listener = UIEventListener.GetListener(transform.FindChildByName(name));
                uiEventListenerCache.Add(name,listener);
            }
            return uiEventListenerCache[name]; 
        }

    }
}
