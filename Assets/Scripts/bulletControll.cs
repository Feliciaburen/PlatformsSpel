using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControll : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float speed = 5;

        Vector2 movement = new Vector2(speed, 0) * Time.deltaTime;

        transform.Translate(movement);

        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "bossEnemy" || other.gameObject.tag == "food")
        {
            Destroy(this.gameObject);
        }
    }
}
