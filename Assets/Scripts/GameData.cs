using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[CreateAssetMenu(fileName = "GAME_DATA", menuName = "Data/ Game data object", order = 1)]
public class GameData : ScriptableObject
{
    public Data data;
    public string datapath;
    public int currentCharacter;
    public CharacterName LevelCharacterName;
    
    public void InitData()
    {
        Load();
    }

    public void SetCoins(int coins)
    {
        data.Coins += coins;
        Save(data);
    }

    public void OpenCharacter(CharacterName name)
    {
        for (int i = 0; i < data.Characters.Length; i++)
        {
            if(data.Characters[i].Name == name)
            {
                data.Characters[i].State = CharacterState.Open;
                Save(data);
            }
        }
    }

    public Character GetCharacterInfo(CharacterName name)
    {
        for (int i = 0; i < data.Characters.Length; i++)
        {
            if (data.Characters[i].Name == name)
            {
                return data.Characters[i];
            }
        }
        return new Character();
    }

    public DirectoryInfo SafeCreateDirectory(string path)
    {
        if (Directory.Exists(path))
        {
            return null;
        }
        return Directory.CreateDirectory(path);
    }

    public void CheckSafeFile(string path)
    {
        if (File.Exists(path) == false)
        {
            Debug.Log("Создаем файл");
            using (FileStream fs = File.Create(path)) { }
            Save(data);
        }
    }

    public void Save(Data file)
    {
        SafeCreateDirectory(Application.persistentDataPath);
        CheckSafeFile(Application.persistentDataPath + "/" + datapath);
        string json = JsonUtility.ToJson(file);
        StreamWriter Writer = new StreamWriter(Application.persistentDataPath + "/" + datapath);
        Writer.Write(json);
        Writer.Flush();
        Writer.Close();
    }

    public void Load()
    {
        SafeCreateDirectory(Application.persistentDataPath);
        CheckSafeFile(Application.persistentDataPath + "/" + datapath);
        var reader = new StreamReader(Application.persistentDataPath + "/" + datapath);
        string json = reader.ReadToEnd();
        Debug.Log(json);
        reader.Close();
        data = JsonUtility.FromJson<Data>(json);
    }

}

[System.Serializable]
public struct Data
{
    public int Coins;
    public Character[] Characters;
    public int PlayerProgress;
}

[System.Serializable]
public struct Character
{
    public string name;
    public CharacterName Name;
    public CharacterState State;
    public int price;

}

[System.Serializable]
public enum CharacterName
{
    Haggy,
    Wooman,
    Dino,
    SerenaHead
}

[System.Serializable]
public enum CharacterState
{
    Close,
    Open
}
