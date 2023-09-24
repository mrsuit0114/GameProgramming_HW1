using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int EnemyCount = 0;  // 처치한 적
    public void LoadLoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void WinCheck()
    {
        if(EnemyCount >= 10)
        {
            LoadWinScene();
        }
    }
}
