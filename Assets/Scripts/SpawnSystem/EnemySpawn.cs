using AI.FSM;
using ARPGDemo.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
	/// <summary>
	/// 生成器
	/// </summary>
	public class EnemySpawn : MonoBehaviour 
	{
        //1.计算路线  交错数组 Vector3[][]
        //-- 路线数据结构：Vector3[4]
        //-- 路线数据结构：Vector3[3]
        //-- 路线数据结构：Vector3[5]

        private Vector3[][] wayLines;

        [Tooltip("需要创建的敌人")]
        public GameObject[] enemyPrefabs;
        [Tooltip("创建敌人最大延迟时间")]
        public float maxDelay = 5;

        private void CalculateWayLines()
        {
            //根据子物体数量创建交错数组
            wayLines = new Vector3[transform.childCount][];
            //创建路线 
            for (int wayLineIndex = 0; wayLineIndex < wayLines.Length; wayLineIndex++)
            {
                Transform childTF = transform.GetChild(wayLineIndex);
                //根据孙子数量创建路线
                wayLines[wayLineIndex] = new Vector3[childTF.childCount];
                //为路线赋值路点坐标
                for (int wayPointIndex = 0; wayPointIndex < childTF.childCount; wayPointIndex++)
                {
                    wayLines[wayLineIndex][wayPointIndex] 
                        = childTF.GetChild(wayPointIndex).position;
                }
            } 
        }

        private void Start()
        {
            CalculateWayLines();
             
            //如果当前生成器没有路线，则直接激活下一个生成器
            if (wayLines.Length == 0)
                SpawnSystem.Instance.ActivateNextSpawn();
            else//否则批量生成敌人
                StartCoroutine(GenerateEnemy());
        }

        //2.生成敌人
        public IEnumerator GenerateEnemy()
        {
            //根据路线数量，随机时间，创建随机敌人。 
            for (int i = 0; i < wayLines.Length; i++)
            {
                float delay = Random.Range(1, maxDelay);
                yield return new WaitForSeconds(delay);//等待
                //创建敌人
                RandomCreateEnemy(wayLines[i]); 
            } 
        }

        private void RandomCreateEnemy(Vector3[] wayLine)
        {
            var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject enemyGO = Instantiate(prefab, wayLine[0], Quaternion.identity);
            //为敌人分配路线
            enemyGO.GetComponent<BaseFSM>().wayPoints = wayLine;
            //enemyGO.GetComponent<EnemyStatus>().spawn = this;
            enemyGO.GetComponent<EnemyStatus>().OnDeathHandler += IsComplete;
        }

        private int diedCount;
        //生成器任务是否完成
        public void IsComplete()
        {
            diedCount++;
            if (diedCount == wayLines.Length)
            {
                SpawnSystem.Instance.ActivateNextSpawn();
            }
        }
    }
}
