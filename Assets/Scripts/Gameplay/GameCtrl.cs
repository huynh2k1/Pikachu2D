using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : BaseGameCtrl
{
    public static GameCtrl I;
    [SerializeField] UICtrl uiCtrl;
    [SerializeField] GridCtrl gridCtrl;


    public override void Awake()
    {
        base.Awake();
        I = this;
        GameHome();
        gridCtrl.GameInit();
    }

    void GameHome()
    {
        uiCtrl.GameHome();  
    }

    public override void InitGame()
    {
        base.InitGame();
        uiCtrl.GameInit();
    }

    public override void StartGame()
    {
        base.StartGame();
    }

    public override void PauseGame()
    {
        base.PauseGame();
        GameHome();
    }

    public override void WinGame()
    {
        base.WinGame();
    }

    public override void LoseGame()
    {
        base.LoseGame();
    }

    public override void ResetGame()
    {
        base.ResetGame();
    }

}
