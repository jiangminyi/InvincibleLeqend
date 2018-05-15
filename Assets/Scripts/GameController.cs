using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ns
{
    /// <summary>
    /// 游戏控制器：负责管理游戏流程。
    /// </summary>
    public class GameController : MonoSingleton<GameController>
    {
        //游戏开始前
        private void Start()
        {
            //显示主菜单
            UIManager.Instance.SetCanvasActive(UIManager.CW_MAIN_MENU, true);
            //淡入
            FadeSceneMask.Instance.FadeinSceneEffect();
        }

        //游戏开始
        public void GameStart()
        {
            //禁用主菜单
            UIManager.Instance.SetCanvasActive(UIManager.CW_MAIN_MENU, false);
            //启用敌人生成器
            SpawnSystem.Instance.ActivateNextSpawn();
        }

        //游戏结束（玩家被击杀PlayerStatus、通关SpawnSystem）
        public void GameOver()
        {
            //屏幕淡出  透明 --> 不透明
            FadeSceneMask.Instance.FadeoutSceneEffect();
            StartCoroutine(DoOver());
        }

        private IEnumerator DoOver()
        {
            //等待
            yield return new WaitForSeconds(FadeSceneMask.Instance.duration);
            //屏幕淡入  不透明-->  透明 
            FadeSceneMask.Instance.FadeinSceneEffect();
            //使玩家回到游戏控制器位置  CameraRig
            VRTK.VRTK_DeviceFinder.PlayAreaTransform().position = transform.position;
            //显示游戏结束界面
            UIManager.Instance.SetCanvasActive(UIManager.CW_CANVAS_OVER, true);
        }

        //游戏重新开始(由UI调用)
        public void Restart()
        {
            SceneManager.LoadScene(gameObject.scene.name);
        }
    }
}
