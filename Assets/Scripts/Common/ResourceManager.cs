using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Common
{
	/// <summary>
	/// 资源管理器
	/// </summary>
	public class ResourceManager
	{
        //资源映射表的数据结构
        private static Dictionary<string, string> configMap; 

        static ResourceManager()
        {
            configMap = new Dictionary<string, string>();

            //读取配置文件 string
            string configFile = ConfigurationReader.GetConfigFile("ResourceMap.txt");
            //形成数据结构
            ConfigurationReader.Load(configFile, BuildMap); 
        }

        private static void BuildMap(string line)
        {
            string[] keyValue = line.Split('=');
            configMap.Add(keyValue[0], keyValue[1]);
        } 

        /// <summary>
        /// 加载资源(内部根据资源名称，查找对应的路径。)
        /// </summary>
        /// <typeparam name="T">需要加载的数据类型</typeparam>
        /// <param name="resourceName">资源名称</param>
        /// <returns></returns>
        public static T Load<T>(string resourceName) where T : Object
        {
            if (!configMap.ContainsKey(resourceName)) return null;
            //从配置文件中获取对应的路径
            string path = configMap[resourceName];
            //通过Resource加载
            return Resources.Load<T>(path);
        }
	}
}
