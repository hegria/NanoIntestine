using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodStone : BaseStone
{
    // Start is called before the first frame update
    protected override void Ondead()
    {
        base.Ondead();
        GameObject go = Managers.Resource.Instantiate("RimpItem");
        go.transform.position = gameObject.transform.position;
    }
}
