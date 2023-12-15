using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
            RestartGame();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
