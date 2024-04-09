using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        Vector2 movement = Vector2.left * speed * Time.deltaTime;

        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject-tag == "bolt" || other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
