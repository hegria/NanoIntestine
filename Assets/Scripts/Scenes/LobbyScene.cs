using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScene : BaseScene
{

    GameObject howto;
    protected override void Init()
    {
        base.Init();
        howto = Util.FindChild(GameObject.Find("Canvas"), "HowTo");
        SceneType = Define.Scene.Lobby;
    }

    private void Update()
    {
        
    }

    public override void Clear()
    {
        Debug.Log("LoginScene Clear!");
    }

    public void Play()
    {
        Managers.Scene.LoadScene(Define.Scene.Game1);
    }

    public void HowToPlay()
    {
        howto.SetActive(true);
    }
    public void Close()
    {
        howto.SetActive(false);
    }
}
