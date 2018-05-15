using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
    /// <summary>
    /// 
    /// </summary>
    public class DamageScreenMask : ScreenMask<DamageScreenMask>
    {
        public Color damgedBeginColor = Color.red, damagedEndColor = Color.clear;
        public void DamageScreenEffect()
        {
            base.currentColor = damgedBeginColor;
            base.targetColor = damagedEndColor;
            base.DisplayMask();
        }
	}
}
