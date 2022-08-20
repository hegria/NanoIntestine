using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDrill : BaseAttack
{
    [SerializeField]
    float speed = 10f;
    Vector3 dir = new Vector3(1.0f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }


    protected override void Onupdate()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (Managers.Game.WillIDie(transform.position))
            Destroy(gameObject);
    }
}
