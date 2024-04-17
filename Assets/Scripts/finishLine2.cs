using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLine2 : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           SceneManager.LoadScene(2);
        }
    }
}
