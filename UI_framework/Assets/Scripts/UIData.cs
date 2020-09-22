using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

[Serializable]
public class UIData : ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIType ut;
    public string panelType;
    public string path;

    public void OnAfterDeserialize()
    {
        ut = (UIType)System.Enum.Parse(typeof(UIType), panelType);
    }

    public void OnBeforeSerialize()
    {
        throw new NotImplementedException();
    }
}
