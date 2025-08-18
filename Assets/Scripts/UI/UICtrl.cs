using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour
{
    [SerializeField] UIHome _uiHome;
    [SerializeField] UIGame _uiGame;

    public void GameHome()
    {
        ShowUIHome(true);
        ShowUIGame(false);
    }

    public void GameInit()
    {
        ShowUIHome(false);
        ShowUIGame(true);
    }


    public void ShowUIHome(bool isShow)
    {
        _uiHome.Show(isShow);
    }

    public void ShowUIGame(bool isShow)
    {
        _uiGame.Show(isShow);
    }
}
