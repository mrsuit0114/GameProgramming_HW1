using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    instance = singletonObject.AddComponent<GameManager>();
                    //DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }
    public int EnemyCount = 0;  // 처치한 적
    public void GameOver()
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
