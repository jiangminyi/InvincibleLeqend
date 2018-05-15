using ns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR.UGUI.Framework;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

namespace VR.UGUI
{
	/// <summary>
	///  游戏入口 窗口
	/// </summary>
	public class UIGameMainWindow : UIWindow 
	{
        //private Button btn;
        //private UIEventListener eventListener;
        //private new void Awake()
        //{
        //    base.Awake();
        //    //btn = transform.FindChildByName("ButtonStart").GetComponent<Button>();
        //    //eventListener = transform.FindChildByName("ButtonStart").GetComponent<UIEventListener>();
        //    //eventListener = UIEventListener.GetListener(transform.FindChildByName("ButtonStart"));
        //}
        private new void Awake() {
            base.Awake();
        }
        private void OnEnable()
        {
            //btn.onClick.AddListener(OnClick);
            //eventListener.PointerClick += OnGameStartButtonClick;
            GetUIEventListener("ButtonStart").PointerClick += OnGameStartButtonClick;
        }

        private void OnDisable()
        {
            //btn.onClick.RemoveListener(OnClick);
            //eventListener.PointerClick -= OnGameStartButtonClick;
            GetUIEventListener("ButtonStart").PointerClick -= OnGameStartButtonClick;
        }
        private void OnGameStartButtonClick(PointerEventData eventData)
        {
            print("开始咯"+eventData.pointerPress);
        }

        //缺点：
        //1.缺少事件参数类
        //  当多个按钮，需要绑定同一方法时，该方法无法获取被点击的按钮。
        //2.注册其他UI事件

        //解决：
        //仿照Button思想，自定义UI事件

        //缺点：
        //如果UI没有附加监听器，则异常
        public void OnClick()
        {
            print("开始咯");
        }
    }
}
