using ns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPGDemo.Character
{
	/// <summary>
	/// 玩家状态类：存储玩家的状态(数据/变量)
	/// </summary>
	public class PlayerStatus : CharacterStatus 
	{
        public override void Damage(float val)
        {
            base.Damage(val);
            DamageScreenMask.Instance.DamageScreenEffect();
        }
        public override void Dead()
        {
            //……
            //Debug.Log("游戏结束");
            ns.GameController.Instance.GameOver();
        }
    }
}
