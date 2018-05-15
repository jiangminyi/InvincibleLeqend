using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPGDemo.Character
{
	/// <summary>
	/// 角色动画参数类：封装角色动画参数。
	/// </summary>
    [System.Serializable]//目的：可以在编译器中看见
	public class EnemyAnimationParameter
    {
        public string Run = "Run";
        public string Death = "Death";
        public string Idle = "Idle"; 
        public string Attack= "Attack"; 
        public string Reload= "Reload"; 
    }
}
