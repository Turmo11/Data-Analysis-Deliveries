using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TransactionData : MonoBehaviour
{
    private string t_purchaseDatetime;
    private string t_current_sessionID;
    private string t_itemID;
    private string baseUrl = "citmalumnes.upc.es/~paufl1";
    private string phpurl = "/inserttransaction.php";
    private string url;

    public TransactionData (int itemID, string current_sessionID, DateTime purchaseDatetime)
    {
      this.t_itemID = itemID.ToString();
      this.t_current_sessionID = current_sessionID;
      this.t_purchaseDatetime = purchaseDatetime.ToString("yyyy-MM-dd HH:mm:ss"); //mySQL DateTime format
      
      string dataUrl = "?itemID=" + t_itemID + "&sessionID=" + t_current_sessionID + "&purchaseDatetime=" + t_purchaseDatetime; //PHP friendly string
      
      this.url = baseUrl + phpurl + dataUrl;
    }

    public string GetUrl()
    {
        return url;  
    }
}
