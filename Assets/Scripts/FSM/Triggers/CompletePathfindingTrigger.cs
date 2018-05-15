using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 完成巡逻
    /// </summary>
    public class CompletePathfindingTrigger : FSMTrigger
    {
        public override bool HandleTrigger(BaseFSM fsm)
        {
            return fsm.isPathfindingComplete;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.CompletePathfinding;
        }
    }
}
