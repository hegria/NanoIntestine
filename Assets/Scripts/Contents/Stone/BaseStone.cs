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

    protected virtual void OnUpdate() { }

    protected virtual void SpwanAttack() { }
}
