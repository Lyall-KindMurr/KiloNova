using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadWinArea()
    {
        SceneManager.LoadScene("Victory");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadDead()
    {
        SceneManager.LoadScene("Defeat");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
