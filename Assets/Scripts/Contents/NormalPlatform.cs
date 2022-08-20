using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlatform : Platform
{
    // Start is called before the first frame update
    protected override void Ondead()
    {
        base.Ondead();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Animator>().SetTrigger("Dead");
    }
}
