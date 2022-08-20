using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAttack : MonoBehaviour
{
    [SerializeField]
    bool alive = false;


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().State = Define.State.Ouch;

            if (!alive)
                Destroy(gameObject);
        }
    }
}
