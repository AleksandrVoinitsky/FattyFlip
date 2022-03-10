using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Coins;
    [SerializeField] MenuCharacter[] Characters;
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject PayButton;
    [SerializeField] TextMeshProUGUI CharacterName;
    [SerializeField] TextMeshProUGUI CharacterPrice;
    [SerializeField] CanvasGroup BlackoutCanvas;

    public GameData gameData;
    

    void Start()
    {
#if UNITY_EDITOR
        gameData.Save();
#endif

        BlackoutCanvas.alpha = 1;
        BlackoutCanvas.DOFade(0, 2);
        gameData.InitData();
        Coins.text = gameData.data.Coins.ToString();
        foreach (var item in Characters)
        {
            item.Hide();
        }
        Characters[gameData.currentCharacter].Show();
        ChoiceButton();
    }

    public void OpenCharacter()
    {
        Character character = gameData.GetCharacterInfo(Characters[gameData.currentCharacter].Name);
        if (character.State == CharacterState.Close)
        {
            if (character.price <= gameData.data.Coins)
            {
                gameData.data.Coins -= character.price;
                gameData.OpenCharacter(character.Name);
                Coins.text = gameData.data.Coins.ToString();
                ChoiceButton();
            }
        }
    }

    public void Next()
    {
        Characters[gameData.currentCharacter].Hide();
        if(gameData.currentCharacter == Characters.Length - 1)
        {
            gameData.currentCharacter = 0;
        }
        else
        {
            gameData.currentCharacter++;
        }
        Characters[gameData.currentCharacter].Show();
        ChoiceButton();
    }

    public void Back()
    {
        Characters[gameData.currentCharacter].Hide();
        if (gameData.currentCharacter == 0)
        {
            gameData.currentCharacter = Characters.Length - 1;
        }
        else
        {
            gameData.currentCharacter--;
        }
        Characters[gameData.currentCharacter].Show();
        ChoiceButton();
    }

    void ChoiceButton()
    {
        Character character = gameData.GetCharacterInfo(Characters[gameData.currentCharacter].Name);
        CharacterName.text = character.name;
        if (character.State == CharacterState.Open)
        {
            CharacterPrice.text = "";
            PlayButton.SetActive(true);
            PayButton.SetActive(false);
        }
        else
        {
            CharacterPrice.text = character.price.ToString();
            PlayButton.SetActive(false);
            PayButton.SetActive(true);
        }
    }

    public void LoadLevel()
    {
        BlackoutCanvas.alpha = 0;
        BlackoutCanvas.DOFade(1, 2).OnComplete(() => { SceneManager.LoadScene("Level_1.2"); });
    }
}
