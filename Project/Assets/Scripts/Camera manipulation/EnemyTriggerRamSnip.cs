using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerRamSnip : MonoBehaviour
{
    private void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            child.GetComponent<EnemyFindPlayer>().enabled = true;
        }
        Debug.Log("Enabled children");
        this.GetComponent<Scrolling>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}
