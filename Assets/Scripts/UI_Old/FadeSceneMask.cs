using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ns
{
	/// <summary>
	/// 
	/// </summary>
	public class FadeSceneMask : ScreenMask<FadeSceneMask>
	{ 
        public Color fadeinBeginColor = Color.black, fadeinEndColor = Color.clear;
        //淡入 不透明  --> 透明
        public void FadeinSceneEffect()
        {
            currentColor = fadeinBeginColor;
            targetColor = fadeinEndColor;
            DisplayMask();
        }

        public Color fadeoutBeginColor = Color.clear, fadeoutEndColor = Color.black;
        //淡出 透明  --> 不透明
        public void FadeoutSceneEffect()
        {
            currentColor = fadeoutBeginColor;
            targetColor = fadeoutEndColor;
            DisplayMask();
        } 
    }
}
