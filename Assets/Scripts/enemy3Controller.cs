using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3Controller : MonoBehaviour
{
    void Update()
    {
        // se till att fienderna rör sig till vänster mott karakären
        float speed = 1;

        Vector2 movement = Vector2.left * speed * Time.deltaTime;

        transform.Translate(movement);

        /*shotTimer += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && shotTimer > timeBetweenShots)
        {
            Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            shotTimer = 0;
        }*/
    }

    // när skottet kommer i kontakt med fienden så förstörs fienden (dör)
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "bolt")
        {
            Destroy(this.gameObject);

        }
    }
}
