using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player = null;


    public int Hp
    {
        get { return _hp; }
        set
        {
            //Gameoverscene
        }
    }

    int _hp;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Dieing()
    {
        player = null;
        Destroy(gameObject);
    }
}
