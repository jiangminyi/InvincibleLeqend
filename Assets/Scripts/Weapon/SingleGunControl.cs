using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


namespace InvincibleLegend.Weapon
{
	/// <summary>
	/// 
	/// </summary>
    [RequireComponent(typeof(Gun))]
	public class SingleGunControl : MonoBehaviour 
	{
        private VRTK_ControllerEvents controller;
        private AnimationEventBehaviour eventBehaviour;
        private Gun gunAction;
        [Tooltip("最小射击间隔")]
        public float minFireInterval = 0.3f;
        private float lastFireTime;
        private void Awake()
        {
            gunAction = GetComponent<Gun>();
        }

        private void  OnEnable()
        {  
            controller = GetComponentInParent<VRTK_ControllerEvents>();
            eventBehaviour = GetComponentInChildren<AnimationEventBehaviour>();

            controller.TriggerPressed += OnTriggerPressed;
            eventBehaviour.OnAttackHandler += DoFiring;
        }

        private void DoFiring()
        {
            gunAction.Firing(gunAction.firePointTF.forward);
        }

        private void OnDisable()
        {
            controller.TriggerPressed -= OnTriggerPressed;
            eventBehaviour.OnAttackHandler -= DoFiring; 
        }

        private void OnTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {
            if (Time.time - lastFireTime < minFireInterval  ) return;
            //播放动画
            gunAction.anim.SetBool(gunAction.fireAnimParam, true);
            lastFireTime = Time.time;
        }

        //private void Update()
        //{
        //    if (controller.triggerPressed)
        //    {
        //        print("按住开火");
        //    }
        //}
    }
}
