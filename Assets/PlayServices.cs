using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CloudOnce;

public class PlayServices : MonoBehaviour
{

    void Start()
    {

        DontDestroyOnLoad(this);
        try
        {

            Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
            Cloud.Initialize(false, true);
            
        }
        catch (Exception exception)
        {
            Debug.Log(exception);
        }
    }

    public void CloudOnceInitializeComplete()
    {
        Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
    }

    public static void AddScoreToLeaderboard()
    {
     Leaderboards.leaderboard_top_players.SubmitScore(PlayerPrefs.GetInt("record"));
    }                   

}
