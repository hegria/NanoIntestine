using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideStone : BaseStone
{
    // Start is called before the first frame update


    float[] xdir = { 0.5f, 0.5f, 0.5f, 0, -0.5f, -0.5f, -0.5f, 0 };
    float[] ydir = { 0.5f, 0, -0.5f, -0.5f, -0.5f, 0, 0.5f, 0.5f };

    protected override void Ondead()
    {
        base.Ondead();

        for (int i =0; i < 8; i++)
        {
            Vector3 temp = new Vector3(xdir[i], ydir[i]);
            Managers.Resource.Instantiate("Suicide").transform.position = transform.position+ temp;
            
        }

    }
}
