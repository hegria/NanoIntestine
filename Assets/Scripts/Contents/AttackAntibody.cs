using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAntibody : BaseAttack
{
    // Start is called before the first frame update


    [SerializeField]
    float power = 5f;

    public void Init(Define.Direction dir, Define.Direction lookdir)
    {
        Vector2 direction = new Vector2();
        switch (dir)
        {
            case Define.Direction.Up:
                direction.y = 2f;
                break;
            case Define.Direction.Down:
                direction.y = -2f;
                break;
            default:
                direction.y = 0.3f;
                break;
        }
        switch(lookdir)
        {
            case Define.Direction.Right:
                direction.x = 1f;
                break;
            case Define.Direction.Left:
                direction.x = -1f;
                break;
        }

        gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * power,ForceMode2D.Impulse);

    }

    // Update is called once per frame
    protected override void Onupdate()
    {
        
    }
}
