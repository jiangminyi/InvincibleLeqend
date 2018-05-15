using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR.UGUI.Framework
{
    /// <summary>
    ///  UI管理器：负责管理(记录、禁用、查找、添加、删除)所有UI。
    /// </summary>
    public class UIManager : MonoSingleton<UIManager>
    {
        private Dictionary<Type, UIWindow> uiWindowCache;
        
        protected override void Init()
        {
            InitUIWindowDic();
        }

        private void InitUIWindowDic()
        {
            uiWindowCache = new Dictionary<Type, UIWindow>();
            //获取场景中所有窗口对象
            UIWindow[] windowArr = FindObjectsOfType<UIWindow>();
            for (int i = 0; i < windowArr.Length; i++)
            {
                //记录窗口
                uiWindowCache.Add(windowArr[i].GetType(), windowArr[i]);
                //禁用窗口
                windowArr[i].SetVisible(false); 
            }
        }

        /// <summary>
        /// 根据类型获取UIWindow对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetWindow<T>() where T:UIWindow
        {
            Type type = typeof(T);
            //如果字典中没有key，则返回空
            if (!uiWindowCache.ContainsKey(type)) return null;
            return uiWindowCache[type] as T;
        }
        //UIManager.Instance.GetWindow<UIXXXWindow>().成员
    }
}
