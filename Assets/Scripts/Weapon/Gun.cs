using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvincibleLegend.Weapon
{
    /// <summary>
    /// 枪
    /// </summary>
    [RequireComponent(typeof(AudioSource),typeof(MuzzleFlash))]
    public class Gun : MonoBehaviour 
	{
        [Tooltip("子弹预制件名称")]
        public string bulletName = "PlayerBullet";

        private GameObject bulletPrefab;
        [HideInInspector]
        public Transform firePointTF;

        private AudioSource audioSource;
        [HideInInspector]
        public Animator anim;

        [Tooltip("开火动画参数")]
        public string fireAnimParam = "Fire";

        [Tooltip("攻击力")]
        public float atk = 100;

        private MuzzleFlash flash;
        private void Start()
        {
            bulletPrefab = ResourceManager.Load<GameObject>(bulletName);
            firePointTF = transform.FindChildByName("FirePoint");
            audioSource = GetComponent<AudioSource>();
            anim = GetComponentInChildren<Animator>();
            flash = GetComponent<MuzzleFlash>();
        }

        //敌人子弹：朝向玩家头部
        //玩家子弹：朝向枪口前方 
        /// <summary>
        /// 开火
        /// </summary>
        /// <param name="direction">子弹朝向</param>
        public void Firing(Vector3 direction)
        {
            //向量类型的方向 --->  四元数
            //创建子弹，设置旋转方向
            GameObject bulletGO = Instantiate(bulletPrefab, firePointTF.position, Quaternion.LookRotation(direction));
            bulletGO.GetComponent<Bullet>().atk = atk;
            audioSource.Play();
            flash.DisplayFlash();
        }
	}
}
