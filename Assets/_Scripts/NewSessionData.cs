using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewSessionData : MonoBehaviour
{
    private string s_sessionStart;
    private string s_current_playerID;
    private string baseUrl = "citmalumnes.upc.es/~paufl1";
    private string phpurl = "/insertsession.php";
    private string url;

    public NewSessionData (string current_playerID, DateTime sessionStart)
    {
      this.s_current_playerID = current_playerID;
      this.s_sessionStart = sessionStart.ToString("yyyy-MM-dd HH:mm:ss"); //mySQL DateTime format
      
      string dataUrl = "?playerID=" + s_current_playerID + "&sessionStart=" + s_sessionStart; //PHP friendly string
      
      this.url = baseUrl + phpurl + dataUrl;
    }

    public string GetUrl()
    {
        return url;  
    }
}
