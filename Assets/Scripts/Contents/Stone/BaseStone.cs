using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStone : MonoBehaviour
{

    public int Hp {
        get
        {
            return _hp;
        }
        set
        {
            if(value <= 0)
            {
                Ondead();
                Destroy(gameObject);
            }
            _hp = value;
        }
    }

    [SerializeField]
    protected Vector3 spwanDir = new Vector3();
    [SerializeField]
    int _hp = 3;
    [SerializeField]
    protected float GenTime = 1f;
    [SerializeField]
    protected float nowTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        
        OnUpdate();
        if (nowTime >= GenTime)
        {
            SpwanAttack();
            nowTime = 0;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // look right
            if ((transform.position - collision.transform.position).x > 0)
                collision.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            else
                collision.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

            collision.gameObject.GetComponent<PlayerController>().State = Define.State.Ouch;

        }
    }

    protected virtual void OnUpdate() { }

    protected virtual void SpwanAttack() { }
    protected virtual void Ondead() { }
}
