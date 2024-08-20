using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveSystem
{
    public static void SaveData(Dictionary<string, int> _valueState, Dictionary<string, bool> _checkBool)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/FUNGAME.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        DataGame data = new DataGame(_valueState, _checkBool);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static DataGame LoadData()
    {
        string path = Application.persistentDataPath + "/FUNGAME.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            DataGame data = formatter.Deserialize(stream) as DataGame;
            return data;
        }
        else
        {
            return null;
        }
    }
}
