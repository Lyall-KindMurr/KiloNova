using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public GameObject gamemanager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Victory");
    }
}
