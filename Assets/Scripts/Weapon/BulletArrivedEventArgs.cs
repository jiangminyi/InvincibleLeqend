using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvincibleLegend.Weapon
{
	/// <summary>
	/// 子弹到达事件参数类
	/// </summary>
	public class BulletArrivedEventArgs:EventArgs
	{ 
        public RaycastHit Hit;
	}
}
