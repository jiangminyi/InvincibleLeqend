using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPGDemo.Character
{
	/// <summary>
	/// 角色状态类
	/// </summary>
	public abstract class CharacterStatus : MonoBehaviour 
	{ 
        public float HP = 1000;
        public float maxHP = 1000;    
          
        /// <summary>
        /// 受伤
        /// </summary>
        /// <param name="val">需要扣除的血量</param>
        public virtual void Damage(float val)//100
        {  
            HP -= val;
            if (HP <= 0)
            {
                Dead();
            }
        }

        /// <summary>
        /// 死亡
        /// </summary>
        public abstract void Dead(); 
    }
}
