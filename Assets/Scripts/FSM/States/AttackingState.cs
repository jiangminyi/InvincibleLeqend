using Common;
using InvincibleLegend.Weapon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 攻击状态
    /// </summary>
    public class AttackingState : FSMState
    {
        private Gun gun;
        public override void Init()
        {
            StateID = FSMStateID.Attacking;
        }

        public override void EnterState(BaseFSM fsm)
        {
            base.EnterState(fsm);
            gun = fsm.gun;
            fsm.GetComponentInChildren<AnimationEventBehaviour>().OnAttackHandler += DoShooting;
        }

        private float attackTime;
        public override void Action(BaseFSM fsm)
        {
            base.Action(fsm);
            if (attackTime <= Time.time)
            {
                //播放攻击动画
                fsm.anim.SetBool(fsm.status.animParam.Attack, true);
                attackTime = Time.time + fsm.attackInterval;
            }
            Vector3 lookPosition = fsm.playerStatus.transform.position;
            lookPosition.y = fsm.transform.position.y;
            fsm.transform.LookPosition(lookPosition, 50);
        }
         
        public override void ExitState(BaseFSM fsm)
        {
            base.ExitState(fsm);
            fsm.GetComponentInChildren<AnimationEventBehaviour>().OnAttackHandler -= DoShooting;
        }

        private void DoShooting()
        {
            //枪口 --> 玩家头部
            gun.Firing(Camera.main.transform.position - gun.firePointTF.position);
        }
    }
}
