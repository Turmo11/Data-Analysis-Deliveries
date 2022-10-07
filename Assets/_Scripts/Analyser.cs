using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyser : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnEnable() 
    {
        Simulator.OnNewPlayer+= OnNewPlayer;
        Simulator.OnNewSession+= OnNewSession;
        Simulator.OnEndSession+= OnEndSession;
        Simulator.OnBuyItem+= OnBuyItem;
        
    }

    private void OnNewPlayer(string name, string country, DateTime dateTime)
    {
        Debug.Log("New Player Event: " + name + " " + country + " " + dateTime);
        PlayerData newPlayerData = new PlayerData(name, country, dateTime);

        Debug.Log(newPlayerData.GetUrl());
        StartCoroutine(SendToPHP(newPlayerData));
    }

    IEnumerator SendToPHP(PlayerData newPlayerData) //need to make insert.php take this data. It is already properly serialized
    {
        WWW www = new WWW(newPlayerData.GetUrl());
        
            Debug.Log(www);
            yield return www;
        
    }


    private void OnNewSession(DateTime obj)
    {
        Debug.Log("New SessionStart Event");
    }

    private void OnEndSession(DateTime obj)
    {
        Debug.Log("New SessionEnd Event");
    }

    private void OnBuyItem(int arg1, DateTime arg2)
    {
        Debug.Log("New Item Event");
    }
}
