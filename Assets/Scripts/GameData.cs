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
    
    

    public void InitData()
    {
        Load();
    }

    public void SetCoins(int coins)
    {
        data.Coins += coins;
        Save();
    }

    public void OpenCharacter(CharacterName name)
    {
        for (int i = 0; i < data.Characters.Length; i++)
        {
            if(data.Characters[i].Name == name)
            {
                data.Characters[i].State = CharacterState.Open;
                Save();
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

    public static DirectoryInfo SafeCreateDirectory(string path)
    {
        if (Directory.Exists(path))
        {
            return null;
        }
        return Directory.CreateDirectory(path);
    }

    public void Save()
    {
        SafeCreateDirectory(Application.persistentDataPath);
        string json = JsonUtility.ToJson(data);
        StreamWriter Writer = new StreamWriter(Application.persistentDataPath + "/" + datapath);
        Writer.Write(json);
        Writer.Flush();
        Writer.Close();
    }

    public void Load()
    {
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
    Hahhi,
    Non
}

[System.Serializable]
public enum CharacterState
{
    Close,
    Open
}
