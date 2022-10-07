using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : MonoBehaviour
{
    private string p_name;
    private string p_country;
    private string p_creationDatetime;
    private string baseUrl = "citmalumnes.upc.es/~paufl1";
    private string phpurl = "/insertplayer.php";
    private string url;

    public PlayerData (string name, string country, DateTime creationDatetime)
    {
      this.p_name = name;
      this.p_country = country;
      this.p_creationDatetime = creationDatetime.ToString("yyyy-MM-dd HH:mm:ss"); //mySQL DateTime format
      
      string dataUrl = "?name=" + this.p_name + "&country=" + this.p_country + "&creationDatetime=" + this.p_creationDatetime; //PHP friendly string
      
      this.url = baseUrl + phpurl + dataUrl;
    }

    public string GetUrl()
    {
        return url;  
    }
}
