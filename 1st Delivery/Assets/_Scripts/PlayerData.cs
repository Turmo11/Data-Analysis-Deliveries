using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : MonoBehaviour
{
    private string p_name;
    private string p_country;
    private string p_creationTime;
    private string baseUrl = "citmalumnes.upc.es/paufl1";
    private string phpurl = "/AddPlayer.php/";
    private string url;

    public PlayerData (string name, string country, DateTime creationTime)
    {
      this.p_name = name;
      this.p_country = country;
      this.p_creationTime = creationTime.ToString();
      
      string dataUrl = "name" + name + "country" + country + "creationTime" + creationTime;
      
      this.url = baseUrl + phpurl + dataUrl;
    }

    public string GetUrl()
    {
        return url;
    }
}
