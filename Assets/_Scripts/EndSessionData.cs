using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndSessionData : MonoBehaviour
{
    private string s_sessionEnd;
    private string s_current_sessionID;
    private string baseUrl = "citmalumnes.upc.es/~paufl1";
    private string phpurl = "/updatesession.php";
    private string url;

    public EndSessionData (string current_sessionID, DateTime sessionEnd)
    {
      this.s_current_sessionID = current_sessionID;
      this.s_sessionEnd = sessionEnd.ToString("yyyy-MM-dd HH:mm:ss"); //mySQL DateTime format
      
      string dataUrl = "?sessionID=" + s_current_sessionID + "&sessionEnd=" + s_sessionEnd; //PHP friendly string
      
      this.url = baseUrl + phpurl + dataUrl;
    }

    public string GetUrl()
    {
        return url;  
    }
}
