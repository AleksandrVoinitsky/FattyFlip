using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public int Score;
    [SerializeField] public int Fat;
    [SerializeField] CameraFollow LevelCamera;
    [SerializeField] TextMeshProUGUI Coins;
    [SerializeField] TextMeshProUGUI Burgers;
    [SerializeField] Image Fill;
    [SerializeField] float Timer;
    public GameData data;
    [SerializeField] CanvasGroup BlackoutCanvas;
    private Player player;
    public bool PlayerInputActive = false;
    private float maxDistance;
    public int FinishScore;
    private float time;

    void Start()
    {
        BlackoutCanvas.alpha = 1;
        BlackoutCanvas.DOFade(0, 2);
        player = FindObjectOfType<Player>();
        PlayerInputActive = true;
        data.InitData();
    }

    public void ResetTime()
    {
        time = Timer;
    }

    public IEnumerator MenuLoadTimer()
    {
        time = Timer;
        while (true)
        {
            time -= Time.deltaTime;

            if(time <= 0)
            {
                
                BlackoutCanvas.alpha = 0;
                BlackoutCanvas.DOFade(1, 2).OnComplete(() => 
                {
                    data.data.PlayerProgress += 5;
                    data.SetCoins(Score);
                    SceneManager.LoadScene("MainMenu"); 
                });
                break;
               
            }
            yield return null;
        }
    }

    public void SetDistance(float dis)
    {
        if(PlayerInputActive)
        {
            float val = dis;

            if (val > maxDistance)
            {
                maxDistance = val;
            }

            float BarFill;
            if (val == 0)
            {
                BarFill = val;
            }
            else
            {
                BarFill = ((val / maxDistance) * 100);
            }

            Fill.fillAmount = BarFill / 100;
        }
    }

    public void SetLevelDistance(float maxDis)
    {
        maxDistance = maxDis;
    }


    public void AddScore(int score)
    {
        Coins.transform.DOScale(1.3f, 0.08f).OnComplete(() => Coins.transform.DOScale(1f, 0.08f));
        Score += score;
        Coins.text = Score.ToString();
    }

    public void AddHealth(int health, float velosity = 0)
    {
        if(health < 0)
        {
            Fat += health;
            if (Fat < 0)
            {
                Fat = 0;
            }
        }
        if (health > 0)
        {
            Fat += health;
        }
        CameraShake(velosity);
        UpdaleHealth();
    }

    public void CameraShake(float ShakePower)
    {
        if (ShakePower > 0)
        {
            if(ShakePower > 1)
            {
                ShakePower = 1;
            }
            LevelCamera.StartCoroutine(LevelCamera.Shake(ShakePower / 5, ShakePower));
        }
    }

    public void WallBoosterEffect(bool add)
    {
        if (add)
        {
            Fat = Fat * 2;
        }
        else
        {
            Fat = Fat / 2;
        }
        UpdaleHealth();
    }

    public void UpdaleHealth()
    {
        if(Fat < 9999)
        {
            Burgers.text = Fat.ToString();
            player.SetBlandShape(Fat * 10);
        }
        else
        {
            Burgers.text = "MAX";
        }
        Burgers.transform.DOScale(1.3f, 0.08f).OnComplete(() => Burgers.transform.DOScale(1f, 0.08f));
       
    }
}
