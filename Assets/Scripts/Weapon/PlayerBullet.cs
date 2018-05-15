using ARPGDemo.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvincibleLegend.Weapon
{
	/// <summary>
	/// 玩家子弹
	/// </summary>
	public class PlayerBullet : Bullet 
	{ 
        //计算攻击力(根据碰撞器名称)
        private void CalculateAttackForce()
        {
            switch (hit.collider.name)
            {
                case "Coll_Head":
                    atk *= 3;
                    break;
                case "Coll_Body":
                    atk *= 2;
                    break;
            }
        }

        protected override void ArriveTargetPoint()
        {
            base.ArriveTargetPoint();

            if (hit.collider == null) return;

            var status = hit.transform.root.GetComponent<EnemyStatus>();

            if (status == null) return;

            CalculateAttackForce();
            //伤害敌人(调用敌人受伤方法)
            status.Damage(atk);
        }
    }
}
