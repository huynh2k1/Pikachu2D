using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameCtrl : MonoBehaviour, IGameCtrl
{
    public virtual void Awake()
    {

    }

    public virtual void InitGame()
    {
        Debug.Log("GameCtrl Log: Init Game");
    }

    public virtual void LoseGame()
    {
        Debug.Log("GameCtrl Log: Lose Game");

    }

    public virtual void PauseGame()
    {
        Debug.Log("GameCtrl Log: Pause Game");

    }

    public virtual void ResetGame()
    {
        Debug.Log("GameCtrl Log: Reset Game");

    }

    public virtual void StartGame()
    {
        Debug.Log("GameCtrl Log: Start Game");

    }

    public virtual void WinGame()
    {
        Debug.Log("GameCtrl Log: Win Game");

    }
}
public interface IGameCtrl
{
    void InitGame();

    void StartGame();

    void PauseGame();

    void WinGame();

    void ResetGame();

    void LoseGame();
}

