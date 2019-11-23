using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
	public static void SavePlayer(){
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.fun";
        //Debug.Log(path);
		FileStream stream = new FileStream(path,FileMode.Create);

        PlayerData data = new PlayerData();
        //Debug.Log(data.coin);
        //Debug.Log(data.level);
        formatter.Serialize(stream, data);
		stream.Close();
	}

	public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        //Debug.Log(path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //Debug.Log(data.coin);
            //Debug.Log(data.level);
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }


    }


}
