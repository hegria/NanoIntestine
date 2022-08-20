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

        SceneType = mySceneType;
        //Managers.UI.ShowSceneUI<UI_Inven>();
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

    }
    private void Update()
    {
        if (Managers.Game.gameEnd&&Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("OKGO");
            Time.timeScale = 1f;
            Managers.Game.Level = 0;
            Managers.Scene.LoadScene(mySceneType);
            Managers.Game.gameEnd = false;
        }
    }

    public override void Clear()
    {
        
    }
}
