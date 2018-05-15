using Common;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ConfigDic = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, string>>;

namespace AI.FSM
{
    /// <summary>
    /// AI 配置文件读取器
    /// </summary>
    public class AIConfigurationReader
    {
        //配置文件数据结构
        public ConfigDic ConfigMap
        {
            get; private set;
        }

        public AIConfigurationReader(string aiConfigFile)
        {
            ConfigMap = new ConfigDic();

            //读取配置文件 string
            string configFile = ConfigurationReader.GetConfigFile(aiConfigFile);
            //形成数据结构
            ConfigurationReader.Load(configFile, BuildMap);
        }

        private string mainKey = string.Empty;//""
        private void BuildMap(string line)
        {
            //如果是空行 则跳过 
            line = line.Trim();//去除空白
            if (string.IsNullOrEmpty(line)) return;
            //如果带[，则在大字典中添加记录
            if (line.StartsWith("["))
            {
                mainKey = line.Substring(1, line.Length - 2);
                ConfigMap.Add(mainKey, new Dictionary<string, string>());
            }
            else
            {
                //否则，在小字典中添加记录
                string[] map = line.Split('>');
                ConfigMap[mainKey].Add(map[0], map[1]);
            }
        }

        //private string GetConfigFile(string fileName)
        //{
        //    string configPath = Application.streamingAssetsPath + "/" + fileName;

        //    if (Application.platform != RuntimePlatform.Android)
        //    {
        //        configPath = "file://" + configPath;
        //    }

        //    WWW www = new WWW(configPath);
        //    while (true)
        //    {
        //        if (www.isDone) return www.text;
        //    }
        //}

        //private void BuildMap(string configFile)
        //{
        //    //字符串读取器：提供仅向前 逐行读取方式。
        //    StringReader reader = new StringReader(configFile);
        //    string line;
        //    string mainKey = string.Empty;//""
        //    while ((line = reader.ReadLine()) != null)
        //    {
        //        //如果是空行 则跳过 
        //        line = line.Trim();//去除空白
        //        if (string.IsNullOrEmpty(line)) continue; 
        //        //如果带[，则在大字典中添加记录
        //        if (line.StartsWith("[")) 
        //        {
        //            mainKey = line.Substring(1, line.Length - 2);
        //            ConfigMap.Add(mainKey, new Dictionary<string, string>());
        //        }
        //        else
        //        {
        //            //否则，在小字典中添加记录
        //            string[] map = line.Split('>');
        //            ConfigMap[mainKey].Add(map[0], map[1]);
        //        }
        //    }
    }
}
