using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("suicide");
    }

    // Update is called once per frame
    IEnumerator suicide()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            collision.gameObject.GetComponent<Platform>().Hp -= 1;
            return;
        }
        if (collision.gameObject.tag == "Stone")
        {
            BaseStone stone = collision.gameObject.GetComponent<BaseStone>();
            stone.Hp = stone.Hp - 1;
        }
        if (collision.gameObject.tag == "Player")
        {
            // look right
            if ((transform.position -= collision.transform.position).x > 0)
                collision.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            else
                collision.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

            collision.gameObject.GetComponent<PlayerController>().State = Define.State.Ouch;

        }
    }
}