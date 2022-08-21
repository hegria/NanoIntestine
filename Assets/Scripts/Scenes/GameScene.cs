using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{

    [SerializeField]
    Define.Scene mySceneType;

    
    protected override void Init()
    {
        base.Init();
        Managers.Game.Init();


        SceneType = mySceneType;
        Managers.Game.Stage = (int)mySceneType;
        Managers.Sound.Play($"main{Managers.Game.Stage}", Define.Sound.Bgm);
        //Managers.UI.ShowSceneUI<UI_Inven>();
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

    }
    
    private void Update()
    {
        if (Managers.Game.gameOvered&&Input.GetKeyDown(KeyCode.R))
        {
            Managers.Sound.Play("UI", Define.Sound.UI);
            Debug.Log("OKGO");
            Time.timeScale = 1f;
            Managers.Game.Level = 0;
            Managers.Game.gameOvered = false;
            Managers.Scene.LoadScene(mySceneType);
        }
        if (Managers.Game.gameCleared && Input.GetKeyDown(KeyCode.Return))
        {
            Managers.Sound.Play("UI", Define.Sound.UI);
            Debug.Log("OKGO");
            Time.timeScale = 1f;
            Managers.Game.Level = 0;
            Managers.Game.gameCleared = false;
            if (Managers.Game.Stage == 3)
            {
                Managers.Scene.LoadScene(Define.Scene.Lobby);
            }
            else
                Managers.Scene.LoadScene(++mySceneType);
        }
    }

    public override void Clear()
    {
        
    }
}
