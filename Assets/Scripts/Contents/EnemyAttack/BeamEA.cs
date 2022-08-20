using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamEA : BaseEnemyAttack
{

    bool nowAttacked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(float length)
    {
        Vector3 nowscale = transform.localScale;
        nowscale.x = length;
        transform.localScale = nowscale;
        transform.Translate(new Vector3(length / 2 - 0.5f/2, 0));

        StartCoroutine("GrowUp");
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
            if (nowAttacked)
            {

                Debug.Log("WTF");
                return;
            }
            nowAttacked = true;
        }
        base.OnTriggerEnter2D(collision);
    }

    IEnumerator GrowUp()
    {
        int GrowSize = 200;
        for (int i = 0; i<GrowSize; i++)
        {
            Vector3 nowscale = transform.localScale;
            nowscale.y = (0.5f - 0.05f) / GrowSize * i + 0.05f;
            transform.localScale = nowscale;
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
