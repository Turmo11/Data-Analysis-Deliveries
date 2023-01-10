using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public List<Vector3> pathPositionList = new List<Vector3>();
    public List<Vector3> jumpPositionList = new List<Vector3>();
    public List<Vector3> hitPositionList = new List<Vector3>();
    public List<Vector3> deathPositionList = new List<Vector3>();
    public GameObject player;

    void Start()
    {
        StartCoroutine(GetPathData());
        StartCoroutine(GetJumpData());
        StartCoroutine(GetHitData());
        StartCoroutine(GetDeathData());
    }

    //--- IMPORTING ---
    IEnumerator GetPathData()
    {
        WWW www = new WWW("https://citmalumnes.upc.es/~guillemtg1/importpath.php");

        yield return www;
        string[] pathData = www.text.Split("<br>");
        Vector3Int[] pathDataInt = new Vector3Int[pathData.Length - 3];

        for (int i = 2; i < (pathData.Length - 1); i++)
        {
            string[] parts = pathData[i].Split(" ");
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);

            Vector3Int vector = new Vector3Int(x, y, z);
            pathDataInt[i - 2] = vector;
        }


        for (int i = 0; i < pathDataInt.Length; i++)
        {
            pathPositionList.Add(pathDataInt[i]);
        }

    }

    IEnumerator GetJumpData()
    {
        WWW www = new WWW("https://citmalumnes.upc.es/~guillemtg1/importjump.php");

        yield return www;
        string[] jumpData = www.text.Split("<br>");
        Vector3Int[] jumpDataInt = new Vector3Int[jumpData.Length - 3];

        for (int i = 2; i < (jumpData.Length - 1); i++)
        {
            string[] parts = jumpData[i].Split(" ");
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);

            Vector3Int vector = new Vector3Int(x, y, z);
            jumpDataInt[i - 2] = vector;
        }


        for (int i = 0; i < jumpDataInt.Length; i++)
        {
            jumpPositionList.Add(jumpDataInt[i]);
        }
    }
    IEnumerator GetHitData()
    {
        WWW www = new WWW("https://citmalumnes.upc.es/~guillemtg1/importhit.php");

        yield return www;
        string[] hitData = www.text.Split("<br>");
        Vector3Int[] hitDataInt = new Vector3Int[hitData.Length - 3];

        for (int i = 2; i < (hitData.Length - 1); i++)
        {
            string[] parts = hitData[i].Split(" ");
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);

            Vector3Int vector = new Vector3Int(x, y, z);
            hitDataInt[i - 2] = vector;
        }


        for (int i = 0; i < hitDataInt.Length; i++)
        {
            hitPositionList.Add(hitDataInt[i]);
        }
    }
    IEnumerator GetDeathData()
    {
        WWW www = new WWW("https://citmalumnes.upc.es/~guillemtg1/importdeath.php");

        yield return www;
        string[] deathData = www.text.Split("<br>");
        Vector3Int[] deathDataInt = new Vector3Int[deathData.Length - 3];

        for (int i = 2; i < (deathData.Length - 1); i++)
        {
            string[] parts = deathData[i].Split(" ");
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);

            Vector3Int vector = new Vector3Int(x, y, z);
            deathDataInt[i - 2] = vector;
        }


        for (int i = 0; i < deathDataInt.Length; i++)
        {
            deathPositionList.Add(deathDataInt[i]);
        }
    }

    //--- LISTENER ---
    public void DataMessage(string type)
    {
        Vector3Int intPos = new Vector3Int((int)player.transform.position.x, (int)player.transform.position.y, (int)player.transform.position.z);

        if (type == "Damaged")
        {
            onHit(intPos);
        }
        if (type == "Death")
        {
            onDeath(intPos);
            Debug.Log("Died on: " + intPos);
        }
        if (type == "Jumping")
        {
            onJump(intPos);
        }
    }

    // Path
    public IEnumerator TrackPosition()
    {
        while (true)
        {
            Vector3Int intPos = new Vector3Int((int)player.transform.position.x, (int)player.transform.position.y, (int)player.transform.position.z);
            onMove(intPos);
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void onMove(Vector3 pos)
    {
        PositionData newPos = new PositionData(pos);
        //Debug.Log(newPos.GetUrl());
        StartCoroutine(SendToPHP(newPos));
    }

    IEnumerator SendToPHP(PositionData newPos)
    {
        WWW www = new WWW(newPos.GetUrl());
        yield return www;
    }

    // Jump
    private void onJump(Vector3 pos)
    {
        //Debug.Log("Jumped on: " + pos.x + ", " + pos.y + ", " + pos.z);
        JumpData newJump = new JumpData(pos);

        Debug.Log(newJump.GetUrl());
        StartCoroutine(SendToPHP(newJump));
    }

    IEnumerator SendToPHP(JumpData newJump)
    {
        WWW www = new WWW(newJump.GetUrl());
        yield return www;
        Debug.Log(www.text);
    }

    // Damage
    private void onHit(Vector3 pos)
    {
        HitData newHit = new HitData(pos);
        StartCoroutine(SendToPHP(newHit));
    }
    IEnumerator SendToPHP(HitData newHit)
    {
        WWW www = new WWW(newHit.GetUrl());
        yield return www;
    }

    // Death
    private void onDeath(Vector3 pos)
    {
        DeathData newDeath = new DeathData(pos);
        StartCoroutine(SendToPHP(newDeath));
    }
    IEnumerator SendToPHP(DeathData newDeath)
    {
        WWW www = new WWW(newDeath.GetUrl());
        yield return www;
    }
}

