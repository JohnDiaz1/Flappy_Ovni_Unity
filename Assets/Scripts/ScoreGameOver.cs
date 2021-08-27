using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreGameOver : MonoBehaviour
{

    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("score", 0).ToString();
    }

   
}
