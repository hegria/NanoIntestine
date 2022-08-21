using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitmePlatform : Platform
{

    Coroutine nowplay = null;


    [SerializeField]
    int maxhp = 1;

    protected override void Ondead()
    {
        Debug.Log("fuck");
        if (nowplay != null)
            StopCoroutine(nowplay);
        nowplay = StartCoroutine("Ouch");
    }

    IEnumerator Ouch()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        Hp = maxhp;
        transform.GetChild(0).gameObject.SetActive(false);
    }   
}
