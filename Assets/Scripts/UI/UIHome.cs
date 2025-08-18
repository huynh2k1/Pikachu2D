using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHome : MonoBehaviour
{
    [SerializeField] private Button _btnPlay;
    [SerializeField] private Button _btnSetting;

    private void Awake()
    {
        _btnPlay.onClick.AddListener(OnClickPlay);
    }

    public void OnClickPlay()
    {
        GameCtrl.I.InitGame();
    }
    
    public void OnClickSetting()
    {
        Debug.Log("Click Setting");
    }

    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
}
