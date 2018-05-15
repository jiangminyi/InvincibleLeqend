using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// 配置文件读取器
    /// </summary>
    public class ConfigurationReader
    {
        public static string GetConfigFile(string fileName)
        {
            string configPath = Application.streamingAssetsPath + "/" + fileName;

            if (Application.platform != RuntimePlatform.Android)
            {
                configPath = "file://" + configPath;
            }

            WWW www = new WWW(configPath);
            while (true)
            {
                if (www.isDone) return www.text;
            }
        }

        public static void Load(string configFile,Action<string> handler)
        {
            //字符串读取器：提供仅向前 逐行读取方式。
            StringReader reader = new StringReader(configFile);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                //string[] keyValue = line.Split('=');
                //configMap.Add(keyValue[0], keyValue[1]);
                handler(line);
            }
        }
    }
}
