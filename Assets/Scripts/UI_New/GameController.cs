using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR.UGUI;
using VR.UGUI.Framework;

namespace xx
{
    /// <summary>
    ///  游戏控制器：负责控制游戏流程。
    /// </summary>
    public class GameController : MonoBehaviour
    {
        //游戏开启前……
        private void Start()
        {
            //显示游戏入口UI
            UIManager.Instance.GetWindow<UIGameMainWindow>().SetVisible(true);
        }

        //游戏开始……

        //游戏暂停……

        //游戏结束……

        //游戏重新开始……
    }
}
