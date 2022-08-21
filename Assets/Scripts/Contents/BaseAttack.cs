using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{


    public int Damage
    {
        get { return _damage;  }
        set
        {
            if (value <= 0)
            {
                Destroy(gameObject);
            }
            _damage = value;
        }
    }

    [SerializeField]
    int _damage = 1;

    private void Update()
    {
        Onupdate();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Managers.Sound.Play("AttackCrush",Define.Sound.Enemy);
            while (Damage >= 1 && collision.gameObject.GetComponent<Platform>().Hp >= 1)
            { 
                collision.gameObject.GetComponent<Platform>().Hp -= 1;
                Damage -= 1;
            }
            collision.gameObject.GetComponent<Platform>().Hp -= 1;
            Damage -= 1;
            return;
        }
        if(collision.gameObject.tag == "Stone")
        {
            Managers.Sound.Play("AttackCrush", Define.Sound.Enemy);
            BaseStone stone = collision.gameObject.GetComponent<BaseStone>();
            while (Damage >= 1 && stone.Hp >= 1)
            {
                stone.Hp -= 1;
                Damage -= 1;
            }
            Damage -= 1;
            stone.Hp = stone.Hp - 1;
        }
        
    }

    protected virtual void Onupdate()  { }
}
