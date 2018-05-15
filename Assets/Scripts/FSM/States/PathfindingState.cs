using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    ///  寻路状态
    /// </summary>
    public class PathfindingState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Pathfinding;
        }

        public override void EnterState(BaseFSM fsm)
        {
            base.EnterState(fsm);
            fsm.isPathfindingComplete = false;
            fsm.anim.SetBool(fsm.status.animParam.Run, true);
        }

        public override void ExitState(BaseFSM fsm)
        {
            base.ExitState(fsm);
            fsm.anim.SetBool(fsm.status.animParam.Run, false);
        }

        private int index;
        public override void Action(BaseFSM fsm)
        {
            base.Action(fsm);

            if (Vector3.Distance(fsm.transform.position, fsm.wayPoints[index]) <= 0.5)
            {
                if (index == fsm.wayPoints.Length - 1)
                {
                    fsm.isPathfindingComplete = true;
                    return;
                }
                index = (index + 1) % fsm.wayPoints.Length; 
            }
            fsm.transform.LookPosition(fsm.wayPoints[index], 50);
            fsm.transform.position = Vector3.MoveTowards(fsm.transform.position, fsm.wayPoints[index], fsm.runSpeed * Time.deltaTime);
        } 
    }
}
