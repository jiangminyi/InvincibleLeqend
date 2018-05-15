using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvincibleLegend.Weapon
{
	/// <summary>
	/// 枪口火光特效
	/// </summary>
	public class MuzzleFlash : MonoBehaviour 
	{
        [Tooltip("火光特效名称")]
        public string flashName;

        private float hideTime;

        private GameObject flashGO;

        [Tooltip("显示时间")]
        public float displayTime = 0.2f;

        private void Start()
        {
            flashGO = transform.FindChildByName(flashName).gameObject;
        }

        /// <summary>
        /// 显示火光
        /// </summary>
        public void DisplayFlash()
        {
            flashGO.SetActive(true);
            hideTime = Time.time + displayTime;
            enabled = true;
        }

        private void Update()
        {
            if (hideTime <= Time.time)
            { 
                HideFlash();
            }
        }

        private void HideFlash()
        {
            flashGO.SetActive(false);
            enabled = false;
        }
    }
}
