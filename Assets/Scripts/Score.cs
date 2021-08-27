using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;
    private int scoreAdReward;

    // Start is called before the first frame update
    void Start()
    { 
       ScoreAdReward();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = score.ToString();
        PlayerPrefs.SetInt("score", score);
    }

    public void ScoreAdReward()
    {
        scoreAdReward = PlayerPrefs.GetInt("pulsado");
        if (scoreAdReward > 0)
        {
            score = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("pulsado", 0);
        }
        else
        {
            score = 0;
        }
    }

}
