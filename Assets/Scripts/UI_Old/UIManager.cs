using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns
{
    /// <summary>
    /// UI管理器：管理所有世界模式的画布，提供显隐功能。
    /// </summary>
    public class UIManager :MonoSingleton<UIManager>
    {
        private Dictionary<string, GameObject> canvasDIC;//可以用Canvas Group
        public string UITag = "CanvasWorld";
        //1. 记录画布
        private void Start()
        { 
            canvasDIC = new Dictionary<string, GameObject>();
            //查找画布
            var canvasArray = GameObject.FindGameObjectsWithTag(UITag);
            for (int i = 0; i < canvasArray.Length; i++)
            {
                canvasDIC.Add(canvasArray[i].name, canvasArray[i]);
                //禁用画布
                canvasArray[i].SetActive(false);
            } 
        }

        //2. 激活/禁用画布
        public void SetCanvasActive(string canvasName, bool state, float delay=0)
        {
            StartCoroutine(DelaySetCanvasActive(canvasName, state, delay));
        }

        private IEnumerator DelaySetCanvasActive(string canvasName, bool state, float delay)
        {
            yield return new WaitForSeconds(delay);
            canvasDIC[canvasName].SetActive(state);
        }

        //3. 记录画布名称 
        /// <summary>
        /// 主菜单面板
        /// </summary>
        public const string CW_MAIN_MENU = "CanvasMain";

        /// <summary>
        /// 3D键盘
        /// </summary>
        public const string CW_KEYBOARD = "WorldKeyboard";

        /// <summary>
        /// 游戏结束面板
        /// </summary>
        public const string CW_CANVAS_OVER = "CanvasOver";
    }
}
