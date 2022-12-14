using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerEx
{
    public int Stage = 0;
    public int Level = 0;
    public float Size = 5.5f;
    public int ellminatedstone;
    public int numOfstone;

    float TImeellipsed;

    public bool gameOvered =false;
    public bool gameCleared = false;

    GameObject stageobj;

    public void Init()
    {
        Level = 0;
        numOfstone = GameObject.FindObjectsOfType<BaseStone>().Length;
        ellminatedstone = 0;
        TImeellipsed = 0;
        stageobj = GameObject.Find("Stage");
    }


    
    public void OnUpdate()
    {
        if(Player.player != null)
        {
            TImeellipsed += Time.deltaTime;
            if( Player.player.transform.position.y >= Level * 10 + Size - 0.5f)
            {
                stageobj.transform.GetChild(Level).gameObject.SetActive(false);
                Level++;
                if((Stage != 3 &&Level == 4) || (Stage == 3 && Level == 5))
                {
                    Cleared();
                }
                GameObject.Find("Liquid").GetComponent<Liquid>().SetLiquid();
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
        Managers.Sound.StopMove();
        Managers.Sound.Play("PlayerDead", Define.Sound.UI);
        Util.FindChild(GameObject.Find("Canvas"), "Restart").SetActive(true);
        gameOvered = true;
        Time.timeScale = 0;
    }

    public void Cleared()
    {
        Managers.Sound.StopMove();
        Managers.Sound.StopBgm();
        Managers.Sound.Play("StageClaar", Define.Sound.UI);
        GameObject cleared = Util.FindChild(GameObject.Find("Canvas"), "Cleared");
        cleared.SetActive(true);
        gameCleared = true;
        if (Stage == 3)
        {
            Util.FindChild<Text>(cleared, "Press").text = $"Press Enter To Title";
        }
        Util.FindChild<Text>(cleared, "Time").text = $"{TImeellipsed:0.00} s";
        Util.FindChild<Text>(cleared, "TotalElliminated").text = $"{ellminatedstone} / {numOfstone}";
        Time.timeScale = 0;
    }

}

