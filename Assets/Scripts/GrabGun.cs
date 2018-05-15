using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace ns 
{
    /// <summary>
    /// 
    /// </summary>
    public class GrabGun : MonoBehaviour
    {
        private VRTK_InteractableObject interactable;
        private void Awake()
        {
            interactable = GetComponent<VRTK_InteractableObject>();
        }
        private void OnEnable()
        {
            interactable.InteractableObjectGrabbed += OnGrab;
        }

        private void OnDisable()
        {
            interactable.InteractableObjectGrabbed -= OnGrab;
        }

        //需求：先设置为子物体  再启用组件
        private void OnGrab(object sender, InteractableObjectEventArgs e)
        {
            //等待。。。。
            //启用枪的控制脚本
            StartCoroutine(EnableGunControl());
        }

        private IEnumerator EnableGunControl()
        {
            yield return null;
            GetComponent<SingleGunControl>().enabled = true;
        }
    }
}
