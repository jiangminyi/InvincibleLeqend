using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace ns 
{
    /// <summary>
    /// 单发枪控制：手枪
    /// </summary>
    public class SingleGunControl : MonoBehaviour
    {
        private VRTK_ControllerEvents controller;

        private void OnEnable()
        {
            if (controller == null)
            {//当前物体没有被捡拾
                enabled = false;
                return;
            }
            controller = GetComponentInParent<VRTK_ControllerEvents>();
            controller.TriggerPressed += OnFireTriggerPressed;
        }
        private void OnDisable()
        {
            if (controller == null) return;
            controller = GetComponentInParent<VRTK_ControllerEvents>();
            controller.TriggerPressed -= OnFireTriggerPressed;
        }

        private void OnFireTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {
            print("发射");
        }


    }
}
