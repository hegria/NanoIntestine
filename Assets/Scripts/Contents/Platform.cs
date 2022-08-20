using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public int Hp {
        get { return _hp; }

        set
        {
            if (value <= 0)
                Ondead();
            _hp = value;
        }
    }

    [SerializeField]
    int _hp = 1;

    protected virtual void Ondead() {

    }
    
}
