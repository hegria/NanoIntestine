using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlatform : Platform
{
    // Start is called before the first frame update
    protected override void Ondead()
    {
        base.Ondead();
        Destroy(gameObject);
    }
}
