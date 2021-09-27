using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Play;
    public GameObject Score;
    public GameObject buttonAdReward;
    public static int adRewardPulsado = 0;
    private BannerAdMob intersicial, reward;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

  public void jugar()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void perdiste()
    {
        if (PlayerPrefs.GetInt("ads") == 0)
        {
            
                intersicial.showIntersicial();
            
        }

            if (reward.rewardIsLoaded())
            {
                buttonAdReward.SetActive(true);
            }
            else
            {
                buttonAdReward.SetActive(false);
            }
        
        Score.SetActive(false);
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public static void Retry()
    {
        SceneManager.LoadScene(1);
       // Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void AdReward()
    {
        if (reward.rewardIsLoaded())
        {
            adRewardPulsado = adRewardPulsado + 1;
            PlayerPrefs.SetInt("pulsado", adRewardPulsado);
            reward.showReward();
        }
    }

    public void RateUs()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.towo.flappyovni");
    }

}
