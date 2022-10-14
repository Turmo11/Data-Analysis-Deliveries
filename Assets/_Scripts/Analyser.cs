using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Analyser : MonoBehaviour
{
    private string current_playerID;
    private string current_sessionID;
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
        
           
        yield return www;

        Debug.Log(www.text);

        current_playerID = Regex.Replace(www.text, "[^0-9]", "");

        CallbackEvents.OnAddPlayerCallback.Invoke(uint.Parse(current_playerID));
        Debug.Log(current_playerID);
    }


    private void OnNewSession(DateTime obj)
    {
        NewSessionData newSessionData = new NewSessionData(current_playerID, obj);

        Debug.Log(newSessionData.GetUrl());
        
        StartCoroutine(SendToPHP(current_playerID, newSessionData));
    }

    IEnumerator SendToPHP(string playerID, NewSessionData newSessionData) //need to make insert.php take this data. It is already properly serialized
    {
        WWW www = new WWW(newSessionData.GetUrl());
        
           
        yield return www;

        Debug.Log(www.text);

        current_sessionID = Regex.Replace(www.text, "[^0-9]", "");

        CallbackEvents.OnNewSessionCallback.Invoke(uint.Parse(current_sessionID));
        Debug.Log(current_sessionID);
    }

    private void OnEndSession(DateTime obj)
    {
        EndSessionData endSessionData = new EndSessionData(current_sessionID, obj);

        Debug.Log(endSessionData.GetUrl());
        
        StartCoroutine(SendToPHP(current_sessionID, endSessionData));
    }

    IEnumerator SendToPHP(string sessionID, EndSessionData endSessionData) //need to make insert.php take this data. It is already properly serialized
    {
        WWW www = new WWW(endSessionData.GetUrl());
        
           
        yield return www;

        Debug.Log(www.text);

        string idk = Regex.Replace(www.text, "[^0-9]", "");

        CallbackEvents.OnNewSessionCallback.Invoke(uint.Parse(idk));
        Debug.Log(idk);
    }


    private void OnBuyItem(int arg1, DateTime arg2)
    {
        Debug.Log("New Item Event");
    }
}
