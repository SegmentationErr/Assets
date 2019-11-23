using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
	public static void SavePlayer(PlayerControl player){
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.fun";
		FileStream stream = new FileStream(Path,FileMode.Create);

		PlayerDate data = new PlayerDate(player);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static void 
}
