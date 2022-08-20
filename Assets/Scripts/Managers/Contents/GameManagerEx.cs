using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{

    public int Level = 0;
    public float Size = 5.5f;

    public void Init()
    {

    }

    

    public bool WillIDie(Vector3 position)
    {
        if (position.x <= -Size || position.x >= Size ||
            position.y <= Level * 10 - Size)
            return true;
        return false;
    }
}
