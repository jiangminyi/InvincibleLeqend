using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace ns
{
	/// <summary>
	/// 
	/// </summary>
	public class GameOver : MonoBehaviour 
	{
        private void Start()
        {
            transform.FindChildByName("ButtonRestart").GetComponent<Button>().onClick.AddListener(OnRestartButtonClick);
        }

        private void OnRestartButtonClick()
        {
            GameController.Instance.Restart();
        }
    }
}
