using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    public static int recordScore = 0;
    private int actualScore;
    private int cloudRecordScore;

    // Start is called before the first frame update
    void Start()
    {
        actualScore = PlayerPrefs.GetInt("score", 0);
        recordScore = PlayerPrefs.GetInt("record", 0);
        cloudRecordScore = PlayServices.UpdateUI();
        validarBestScore();
    }

    private void validarBestScore()
    {

        if (cloudRecordScore >= recordScore)
        {
            PlayerPrefs.SetInt("record", cloudRecordScore);
            GetComponent<TextMeshProUGUI>().text = "BEST: " + cloudRecordScore.ToString();
        }

        if (actualScore >= recordScore)
        {
            PlayerPrefs.SetInt("record", actualScore);
            GetComponent<TextMeshProUGUI>().text = actualScore.ToString();
            PlayServices.AddScoreToLeaderboard();
            PlayServices.SaveCloudScore();
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = recordScore.ToString();
        }
    }
}
