using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void OnClickReStart()
    {
        Ret();
        MainManager.Instance.RestartGame();
    }

    public void OnClickLobby()
    {
        Ret();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lobby");
    }

    private void Ret()
    {
        if (!MainManager.Instance.dontClick || !MainManager.Instance.stageChange)
            return;

        MainManager.Instance.dontMov = true;
        MainManager.Instance.gameOver = false;
        MainManager.Instance.timetime = 0f;
        MainManager.Instance.speed = 0.04f;
        MainManager.Instance.playerAttack = false;
    }
}
