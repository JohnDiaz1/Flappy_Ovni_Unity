using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    public static int recordScore = 0;
    private int actualScore;

    // Start is called before the first frame update
    void Start()
    {
        actualScore = PlayerPrefs.GetInt("score", 0);
        recordScore = PlayerPrefs.GetInt("record", 0);
        validarBestScore();
    }

    private void validarBestScore()
    {
        if(actualScore >= recordScore)
        {
            PlayerPrefs.SetInt("record", actualScore);
            GetComponent<TextMeshProUGUI>().text = actualScore.ToString();
            PlayServices.AddScoreToLeaderboard();
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = recordScore.ToString();
        }
    }
}
