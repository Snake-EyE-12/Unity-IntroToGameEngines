using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Variable", menuName = "Variable/Int", order = 0)]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver {
    [NonSerialized] public int initialValue;
    public int value;

    public void OnAfterDeserialize()
    {
        value = initialValue;
    }

    public void OnBeforeSerialize()
    {
        //
    }
}