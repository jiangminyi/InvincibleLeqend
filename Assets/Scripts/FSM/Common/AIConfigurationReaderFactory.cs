using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cache = System.Collections.Generic.Dictionary<string, AI.FSM.AIConfigurationReader>;
using ConfigDic = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, string>>;

namespace AI.FSM
{
	/// <summary>
	/// 
	/// </summary>
	public class AIConfigurationReaderFactory
	{
        private static Cache cache;
        static AIConfigurationReaderFactory()
        {
            cache = new Cache();
        }

        public static ConfigDic GetConfigDic(string aiConfigFile)
        {
            if (!cache.ContainsKey(aiConfigFile))
            {
                var obj = new AIConfigurationReader(aiConfigFile);
                cache.Add(aiConfigFile, obj);
            }
            return cache[aiConfigFile].ConfigMap;
        }
	}
}
