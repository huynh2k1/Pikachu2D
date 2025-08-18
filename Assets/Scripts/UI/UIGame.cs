using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [SerializeField] Button _btnSetting;

    private void Awake()
    {
        _btnSetting.onClick.AddListener(OnClickSetting);
    }

    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }

    public void OnClickSetting()
    {
        GameCtrl.I.PauseGame();
    }
}
