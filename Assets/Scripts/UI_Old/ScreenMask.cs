using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ns
{
	/// <summary>
	/// 
	/// </summary>
	public class ScreenMask<T> : MonoSingleton<T> where T: ScreenMask<T>
    {
        protected Color currentColor, targetColor;
        public AnimationCurve curve;
        private float x;
        public float duration = 1;

        private Image imgMask;
        private void Start()
        {
            imgMask = GetComponent<Image>();
        }

        protected void DisplayMask()
        {
            x = 0;
            enabled = true;
        }

        private void Update()
        {
            if (x < 1)
            {
                x += Time.deltaTime / duration;
                float y = curve.Evaluate(x);
                imgMask.color = Color.Lerp(currentColor, targetColor, y);
            }
            else
            {
                enabled = false;
            }
        }
    }
}
