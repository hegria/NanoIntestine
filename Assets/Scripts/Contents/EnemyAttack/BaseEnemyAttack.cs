using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAttack : MonoBehaviour
{
    bool alive = false;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag  == "Player")
        {
            //Hit event
            if (!alive)
                Destroy(gameObject);
        }
    }
}
