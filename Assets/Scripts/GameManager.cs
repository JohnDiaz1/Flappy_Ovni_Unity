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
            if ( MaxSdk.IsInterstitialReady("d651db7115d8f6d4") )
                {
                     MaxSdk.ShowInterstitial("d651db7115d8f6d4");
                }
        }

            if (MaxSdk.IsRewardedAdReady("2e1eed1ffb6aa580"))
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
        if (MaxSdk.IsRewardedAdReady("2e1eed1ffb6aa580"))
        {
            adRewardPulsado = adRewardPulsado + 1;
            PlayerPrefs.SetInt("pulsado", adRewardPulsado);
            MaxSdk.ShowRewardedAd("2e1eed1ffb6aa580");
        }
    }

    public void RateUs()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.towo.flappyovni");
    }

}
