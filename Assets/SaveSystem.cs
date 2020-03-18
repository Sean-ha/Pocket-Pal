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

        //Path of save file. "persistentDataPath" differs depending on the OS.
        string path = Path.Combine(Application.persistentDataPath, "data.pp");
        FileStream stream = new FileStream(path, FileMode.Create);

        Database database = new Database();

        //Stores the data in a binary file
        formatter.Serialize(stream, database);
        stream.Close();
    }

    public static Database LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.pp");

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
