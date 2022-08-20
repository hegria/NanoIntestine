using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    public int Stage = 0;
    public int Level = 0;
    public float Size = 5.5f;

    public bool gameEnd =false;

    public void Init()
    {
        Stage = 0;
        Level = 0;
    }

    public void NextLevel()
    {
        Level = 0;
        Stage++;
    }

    
    public void OnUpdate()
    {
        if(Player.player != null)
        {
            if( Player.player.transform.position.y >= Level * 10 + Size - 0.5f)
            {
                Level++;
                Camera.main.transform.Translate(new Vector3(0, 10f, 0));
            }
        }
    }


    public bool WillIDie(Vector3 position)
    {
        if (position.x <= -Size || position.x >= Size ||
            position.y <= Level * 10 - Size)
            return true;
        return false;
    }

    public void RestartGame()
    {
        Util.FindChild(GameObject.Find("Canvas"), "Restart").SetActive(true);
        Debug.Log("OKGO");
        gameEnd = true;
        Time.timeScale = 0.01f;
    }

}
