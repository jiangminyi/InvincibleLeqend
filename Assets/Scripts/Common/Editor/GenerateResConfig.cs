using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 编译器类
/// </summary>
public class GenerateResConfig : Editor
{
    [MenuItem("Tools/Resources/Generate Rresource Config")]
    public static void Generate()
    {
        //资源名=路径
        //1.查找Resources目录下所有预制件
        string[] resFiles = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Resources" });
        //2.生成映射表
        //guid   
        for (int i = 0; i < resFiles.Length; i++)
        {
            resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
            //Assets/Resources/FX/Player/rune 10.prefab
            //资源名：rune 10
            string fileName = Path.GetFileNameWithoutExtension(resFiles[i]);
            //路径：FX/Player/rune 10
            string filePath = resFiles[i].Replace("Assets/Resources/", "").Replace(".prefab", "");
            resFiles[i] = fileName + "=" + filePath;
        }
        //3.写入文件
        File.WriteAllLines("Assets/StreamingAssets/ResourceMap.txt", resFiles);
        AssetDatabase.Refresh();//刷新
    }
}