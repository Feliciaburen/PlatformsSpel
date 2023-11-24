using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // se till att fienderna rör sig till vänster mott karakären
        float speed = 1;

        Vector2 movement = Vector2.left * speed * Time.deltaTime;

        transform.Translate(movement);
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
