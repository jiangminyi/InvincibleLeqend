using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
	/// <summary>
	/// 生成器系统
	/// </summary>
	public class SpawnSystem : MonoSingleton<SpawnSystem> 
	{
        private GameObject[] allSpawn;
        //查找所有子物体
        // --禁用子物体
        // --禁用根路线 
        private new void Awake()
        {
            base.Awake();
            allSpawn = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                allSpawn[i] = transform.GetChild(i).gameObject;
                allSpawn[i].GetComponentInChildren<EnemySpawn>().gameObject.SetActive(false);
                allSpawn[i].SetActive(false);
            } 
        }

        //激活下一个生成器
        private int currentIndex = -1;
        public void ActivateNextSpawn()
        {
            if(currentIndex!= -1) allSpawn[currentIndex].SetActive(false);
            currentIndex++;
            if (currentIndex <= allSpawn.Length - 1)
                allSpawn[currentIndex].SetActive(true);
            else
                //print("游戏结束"); 
                GameController.Instance.GameOver();
        }
    }
}
