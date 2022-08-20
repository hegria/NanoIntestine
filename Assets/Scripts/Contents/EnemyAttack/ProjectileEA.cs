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
        gotodir = (Player.player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(gotodir * speed * Time.deltaTime);
        //TODO 사라지는판정
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.tag == "Platfrom")
        {
            Destroy(gameObject);
        }

    }
}
