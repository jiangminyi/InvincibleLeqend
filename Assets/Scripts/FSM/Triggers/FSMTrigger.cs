using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
	/// <summary>
	/// 条件
	/// </summary>
	public abstract class FSMTrigger
	{
        public FSMTriggerID TriggerID { get; set; }

        public FSMTrigger()
        {
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// 条件处理
        /// </summary>
        public abstract  bool HandleTrigger(BaseFSM fsm);
	}
}
