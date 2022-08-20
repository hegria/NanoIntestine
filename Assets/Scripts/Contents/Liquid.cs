using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]
    float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime));
    }

    // 카메라 바뀔때 호출
    public void SetLiquid()
    {
        transform.position += Vector3.up * (Managers.Game.Level * 10f - 10f);
    }

    
}
