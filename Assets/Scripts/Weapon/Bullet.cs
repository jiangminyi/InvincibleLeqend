using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvincibleLegend.Weapon
{
	/// <summary>
	/// 子弹
	/// </summary>
	public class Bullet : MonoBehaviour 
	{
        public LayerMask layer;
        protected RaycastHit hit;
        private float atkDistance = 100;
        private Vector3 targetPoint;
        [Tooltip("移动速度")]
        public float moveSpeed = 100;
        [HideInInspector]
        public float atk;//来源于枪

        public event EventHandler<BulletArrivedEventArgs> BulletArrived;

        private void Awake()
        {
            CalculateTargetPoint();
        }

        private void Update()
        {
            Movement();

            if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
                ArriveTargetPoint();
        }

        //计算目标点
        private void CalculateTargetPoint()
        {
            //如果检测到目标
            if (Physics.Raycast(transform.position, transform.forward, out hit, atkDistance, layer))
            {
                targetPoint = hit.point;
            }
            else
            {//没有检测到目标
                //正前方100处
                targetPoint = transform.TransformPoint(0, 0, 100);
            }
        }

        //移动
        private void Movement()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, Time.deltaTime * moveSpeed);
        }

        //到达目标(销毁子弹)
        protected virtual void ArriveTargetPoint()
        {
            Destroy(gameObject);

            //引发事件
            if (BulletArrived != null)
            {
                BulletArrivedEventArgs args = new BulletArrivedEventArgs()
                {
                    Hit = hit
                };
                BulletArrived(this, args);
            }
        }
	}
}
