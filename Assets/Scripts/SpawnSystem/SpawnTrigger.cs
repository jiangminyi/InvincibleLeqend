using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
	/// <summary>
	/// 生成器开关
	/// </summary>
	public class SpawnTrigger : MonoBehaviour 
	{
        private string spawnName = "WayLineRoot";
        //private GameObject spawnGO;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Player") return;
            gameObject.SetActive(false);
            //通过父物体查找兄弟物体
            transform.parent.Find(spawnName).gameObject.SetActive(true);
            //启用生成器
            //spawnGO.SetActive(true);
        }
    }
}
