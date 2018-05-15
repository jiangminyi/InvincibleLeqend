using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ns
{
	/// <summary>
	/// 游戏入口
	/// </summary>
	public class GameMain : MonoBehaviour 
	{ 
        private void Start()
        {
            transform.FindChildByName("ButtonStart").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
        }

        private void OnStartButtonClick()
        {
            GameController.Instance.GameStart();     
        }
    }
}
