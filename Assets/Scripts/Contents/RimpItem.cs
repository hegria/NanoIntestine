using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimpItem : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            Managers.Sound.Play("ItemGetBubble");
            collision.gameObject.GetComponent<PlayerController>().Antibodynum = 5;
            Destroy(gameObject);
        }
    }
}
