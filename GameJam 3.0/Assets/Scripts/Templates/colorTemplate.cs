using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Global Color", menuName = "Global Variables/Color")]
public class colorTemplate : ScriptableObject, ISerializationCallbackReceiver
{
    public Color initialValue;

    [System.NonSerialized]
    public Color value;

    public void OnAfterDeserialize()
    {
        value = initialValue;
    }

    public void OnBeforeSerialize() { }
}
