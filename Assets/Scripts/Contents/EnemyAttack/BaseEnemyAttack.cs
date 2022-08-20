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
            // look right
            if ((transform.position - collision.transform.position).x > 0)
                collision.transform.rotation = Quaternion.Euler(new  Vector3(0, 0, 0));
            else
                collision.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

            collision.gameObject.GetComponent<PlayerController>().State = Define.State.Ouch;

            if (!alive)
                Destroy(gameObject);
        }
    }
}
