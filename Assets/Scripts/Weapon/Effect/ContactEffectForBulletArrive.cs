using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvincibleLegend.Weapon
{
	/// <summary>
	/// 创建接触特效
	/// </summary>
	public class ContactEffectForBulletArrive : MonoBehaviour 
	{
        private void Start()
        {
            GetComponent<Bullet>().BulletArrived += GenerateEffect;
        }

        private void GenerateEffect(object sender, BulletArrivedEventArgs e)
        {
            //不同物体    不同特效
            //switch (e.Hit.collider.tag)
            //{ 
            //} 
            if (e.Hit.collider == null) return;
            //特效命名规则：Effects +  物体标签
            string prefabName = "Effects" + e.Hit.collider.tag;
            var effectPrefab = ResourceManager.Load<GameObject>(prefabName);
            if (effectPrefab == null) return;
            //备注：考虑接触特效可能是片，所以需要沿法线方向移动，Z轴朝向法线方向。
            Instantiate(effectPrefab, e.Hit.point + e.Hit.normal*0.001f, Quaternion.FromToRotation(Vector3.forward, e.Hit.normal));
        }
    }
}
