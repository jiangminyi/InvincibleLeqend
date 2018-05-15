
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
namespace ARPGDemo.Character
{
	/// <summary>
	/// 
	/// </summary>
	public class EnemyStatus : CharacterStatus 
	{
        public EnemyAnimationParameter animParam;

        public event Action OnDeathHandler;

        //public ns.EnemySpawn spawn;
        public override void Dead()
        {
            GetComponentInChildren<Animator>().SetBool(animParam.Death, true);
            Destroy(gameObject, 10);
            //通知生成器
            //spawn.IsComplete();
            if(OnDeathHandler!=null)
            {
                OnDeathHandler();
            }
        }
    }
}
