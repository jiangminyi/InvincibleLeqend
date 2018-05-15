using ARPGDemo.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 击杀目标条件
    /// </summary>
    public class KilledTargetTrigger : FSMTrigger
    {
        public override bool HandleTrigger(BaseFSM fsm)
        {
            return fsm.playerStatus.HP <= 0;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.KilledTarget;
        }
    }
}
