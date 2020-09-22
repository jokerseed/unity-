using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class UIManager
{
    private static UIManager _instance;
    //界面类型和加载路径
    private Dictionary<UIType, string> dic;

    public static UIManager Instane
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    private UIManager() {
        PareUIPanelJson();
    }

    private void PareUIPanelJson()
    {
        dic = new Dictionary<UIType, string>();
        TextAsset ta = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Scripts/UIType.json");
        UIDataInfo uidata = JsonUtility.FromJson<UIDataInfo>(ta.text);
        foreach (UIData ui in uidata.ld)
        {
            dic.Add(ui.ut, ui.path);
        }
    }

    public void Test() {
        string path;
        dic.TryGetValue(UIType.Bag,out path);
        //Debug.Log(path);
    }
    
    [Serializable]
    class UIDataInfo {
        public List<UIData> ld;
    }
}
