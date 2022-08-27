using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{
    public bool boolVariable;

    public void SetValue(bool _boolVariable)
    {
        boolVariable = _boolVariable;
    }

    public bool GetValue()
    {
        return boolVariable;
    }
}
