using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject enemy;

    /*[SerializeField]
    Transform bulletSpawnPoint;

    [SerializeField]
    GameObject weapon;*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            gameObject.SetActive(false);

            //Instantiate(weapon, bulletSpawnPoint.position, Quaternion.identity);
            //gameObject.SetActive(false);
        }
    }
}
