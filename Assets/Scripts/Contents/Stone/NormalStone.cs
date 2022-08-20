using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStone : BaseStone
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        base.OnUpdate();
    }

    protected override void SpwanAttack()
    {
        
        GameObject projectattack = Managers.Resource.Instantiate("ProjectileEA");
        projectattack.transform.position = transform.position + spwanDir;
        Vector3 dir = Player.player.transform.position - projectattack.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        projectattack.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        projectattack.GetComponent<ProjectileEA>().Init();
        
    }
}
