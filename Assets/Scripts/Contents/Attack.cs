using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;
    Vector3 dir = new Vector3(1.0f, 0, 0);



    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform" ) {
            if (collision.gameObject.GetComponent<BreakAble>() != null)
                Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
