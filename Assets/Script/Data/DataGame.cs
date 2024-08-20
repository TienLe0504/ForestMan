using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataGame 
{
    public Dictionary<string, int> valueState;
    public Dictionary<string, bool> checkBool;
    public DataGame(Dictionary<string,int> _valueState, Dictionary<string ,bool> _checkBool)
    {
        valueState = _valueState;
        checkBool = _checkBool;
    }
}
