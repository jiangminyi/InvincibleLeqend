using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
	/// <summary>
	/// 状态类
	/// </summary>
	public abstract class FSMState
	{
        #region 状态共性成员
        public FSMStateID StateID;
        //映射表
        private Dictionary<FSMTriggerID, FSMStateID> map;
        //条件对象
        private List<FSMTrigger> triggerList;

        public FSMState()
        {
            map = new Dictionary<FSMTriggerID, FSMStateID>();
            triggerList = new List<FSMTrigger>();
            Init();
        }

        public abstract void Init();

        //由状态机调用
        public void AddMap(FSMTriggerID triggerID,FSMStateID stateID)
        {
            map.Add(triggerID, stateID);
            AddTriggerObject(triggerID);
        }

        //创建条件对象
        private void AddTriggerObject(FSMTriggerID triggerID)
        {
            Type type = Type.GetType("AI.FSM." + triggerID + "Trigger");
            var triggerObj = Activator.CreateInstance(type) as FSMTrigger;
            triggerList.Add(triggerObj);
        }

        //条件检测，由状态机每帧调用
        public void Reason(BaseFSM fsm)
        {
            for (int i = 0; i < triggerList.Count; i++)
            {
                if (triggerList[i].HandleTrigger(fsm))
                {
                    //发现满足的条件
                    //切换状态
                    FSMStateID stateID = map[triggerList[i].TriggerID];
                    fsm.ChanageState(stateID);
                }
            }
        }
        #endregion


        #region 具体行为的抽象
        public virtual void EnterState(BaseFSM fsm) { }

        public virtual void ExitState(BaseFSM fsm) { }

        public virtual void Action(BaseFSM fsm) { }
        #endregion

    }
}
