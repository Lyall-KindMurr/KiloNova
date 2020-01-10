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
    public void LoadLevel2()
    {
        SceneManager.LoadScene("LoadLevel2");
    }
    public void LoadWinArea()
    {
        SceneManager.LoadScene("Victory");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
