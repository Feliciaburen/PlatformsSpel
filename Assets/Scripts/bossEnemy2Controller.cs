using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossEnemy2Controller : MonoBehaviour
{
    [SerializeField]
    int health = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        // se till att fienderna rör sig till vänster mott karakären
        float speed = 1f;

        Vector2 movement = Vector2.left * speed * Time.deltaTime;

        transform.Translate(movement);
    }

    // när skottet kommer i kontakt med fienden så förstörs fienden (dör)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bolt")
        {
            currentHealth -= 10;

            if (currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
