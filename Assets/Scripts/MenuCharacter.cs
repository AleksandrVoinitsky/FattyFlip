using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharacter : MonoBehaviour
{
    public CharacterName Name;
    public GameObject CharacterModel;
    private Character character;

    private void Start()
    {
        MenuManager manager = FindObjectOfType<MenuManager>();
        character = manager.gameData.GetCharacterInfo(Name);
    }

    public void Show()
    {
        CharacterModel.SetActive(true);
    }

    public void Hide()
    {
        CharacterModel.SetActive(false);
    }
    
}
