using ARPGDemo.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.AI;
using InvincibleLegend.Weapon;

namespace AI.FSM
{
    /// <summary>
    /// 状态机
    /// </summary>
    public class BaseFSM : MonoBehaviour
    {
        #region Unity API
        private void Start()
        {
            InitComponent();
            ConfigFSM();
            InitDefaultState();
        }
         
        public FSMStateID currentStateID;
        public void Update()
        {
            currentStateID = currentState.StateID;

            currentState.Action(this);
            currentState.Reason(this); 
        }
        #endregion

        #region 状态机成员 

        private List<FSMState> stateList;

        private FSMState currentState;

        [Tooltip("默认状态编号")]
        public FSMStateID defaultStateID;//备注：由此确认当前状态
        private FSMState defaultState;
        private void InitDefaultState()
        {
            //根据 defaultStateID 在 stateList 中查找状态对象
            defaultState = stateList.Find(s => s.StateID == defaultStateID);
            currentState = defaultState;
            currentState.EnterState(this);//进入状态
        }
        [Tooltip("配置文件")]
        public string aiConfigFile = "Config/AI_01.txt";
   
        private void ConfigFSM()
        {
            stateList = new List<FSMState>();
            var configMap = AIConfigurationReaderFactory.GetConfigDic(aiConfigFile);
 
            foreach (var stateName in configMap.Keys)
            {
                //创建状态对象
                Type type = Type.GetType("AI.FSM." + stateName + "State");
                FSMState stateObject = Activator.CreateInstance(type) as FSMState;
                //配置状态映射
                foreach (var map in configMap[stateName])
                {
                    //map.Key : 条件编号
                    //map.Value：状态编号
                    FSMTriggerID triggerID = (FSMTriggerID)Enum.Parse(typeof(FSMTriggerID), map.Key);
                    FSMStateID stateID = (FSMStateID)Enum.Parse(typeof(FSMStateID), map.Value);
                    stateObject.AddMap(triggerID, stateID);
                }
                //加入集合
                stateList.Add(stateObject);
            }
         
        }
        

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="stateID">需要切换的状态编号</param>
        public void ChanageState(FSMStateID stateID)
        {
            //如果需要切换的状态是默认状态，则
            //FSMState targetState = stateList.Find(s => s.StateID == stateID);
            //if (stateID == FSMStateID.Default) 
            //    targetState = defaultState;
            FSMState targetState = stateID == FSMStateID.Default? defaultState: stateList.Find(s => s.StateID == stateID);
           
            //切换状态
            currentState.ExitState(this);
            currentState = targetState;
            currentState.EnterState(this);
        }
        #endregion

        #region 为状态或条件提供的成员
        [HideInInspector]
        public Animator anim;
        [HideInInspector]
        public EnemyStatus status;    
        [Tooltip("跑步速度")]
        public float runSpeed = 2; 
        [HideInInspector]
        public Gun gun; 
        [HideInInspector]
        public Vector3[] wayPoints;
        [HideInInspector]
        public bool isPathfindingComplete;
        [Tooltip("攻击间隔")]
        public float attackInterval = 5;
        private void InitComponent()
        {
            anim = GetComponentInChildren<Animator>();
            status = GetComponent<EnemyStatus>(); 
            gun = GetComponent<Gun>();
            playerStatus = FindObjectOfType<PlayerStatus>();
        }
        [HideInInspector]
        public PlayerStatus playerStatus;
        #endregion
    }
}
