using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEA : BaseEnemyAttack
{

    Vector3 gotodir = new Vector3();
    [SerializeField]
    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init()
    {
        if (Player.player != null)
            gotodir = (Player.player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += gotodir * speed * Time.deltaTime;
        //TODO 사라지는판정
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);


        Debug.Log("I'mchild mofucker");

        if (collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }

    }
}
