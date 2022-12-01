using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstacne;

    public bool gameState = false;
    void Start()
    {
        if(gameManagerInstacne == null)
        {
            gameManagerInstacne = this;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        gameState = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
