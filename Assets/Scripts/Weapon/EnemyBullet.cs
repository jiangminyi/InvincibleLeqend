using ARPGDemo.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvincibleLegend.Weapon
{
	/// <summary>
	/// 
	/// </summary>
	public class EnemyBullet : Bullet 
	{
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Player") return;
            other.GetComponent<PlayerStatus>().Damage(atk);
            Destroy(gameObject);
        }
    }
}
