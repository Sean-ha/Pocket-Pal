using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Path.Combine(Application.persistentDataPath, "data.ppp");
        FileStream stream = new FileStream(path, FileMode.Create);

        Database database = new Database();

        formatter.Serialize(stream, database);
        stream.Close();
    }

    public static Database LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.ppp");

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Database database = formatter.Deserialize(stream) as Database;

            stream.Close();

            return database;

        } else
        {
            return null;
        }
    }
}
