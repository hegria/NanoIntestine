using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamStone : BaseStone
{
    [SerializeField]
    float genSize;
    [SerializeField]
    Define.Direction dir;
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
        GameObject beamAttack = Managers.Resource.Instantiate("BeamEA");

        Managers.Sound.Play("EnemyLasser", Define.Sound.Enemy);
        beamAttack.transform.position = transform.position + spwanDir;
        beamAttack.transform.rotation = Util.SetRotation(dir);
        beamAttack.GetComponent<BeamEA>().Init(genSize);
    }
}
