using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    public int maxHealth = 4;
    public int currentHealth;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    float jumpForce = 3000;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    float groundRadius = 0.2f;

    Rigidbody2D rBody;
    bool hasReleasedJumpButton = true;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform gunPosition;

    float shotTimer = 0;

    [SerializeField]
    float timeBetweenShots = 0.5f;

    void Awake()
    {
        currentHealth = maxHealth;
        rBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.DrawLine(Vector2.zero, Vector2.down * 8, Color.green);

        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveX, 0) * speed * Time.deltaTime;

        transform.Translate(movement);

        bool isGrounded = Physics2D.OverlapBox(GetFootPosition(), GetFootSize(), 0, groundLayer);

        if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpButton == true && isGrounded)
        {
            Debug.Log("JUMP!");
            rBody.AddForce(Vector2.up * jumpForce);
            hasReleasedJumpButton = false;
        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasReleasedJumpButton = true;
        }

        shotTimer += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && shotTimer > timeBetweenShots)
        {
            Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            shotTimer = 0;
        }
    }

    private Vector2 GetFootPosition()
    {
        float height = GetComponent<Collider2D>().bounds.size.y;
        return transform.position + Vector3.down * height / 2;
    }

    private Vector2 GetFootSize()
    {
        return new Vector2(GetComponent<Collider2D>().bounds.size.x * 0.9f, 0.1f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(GetFootPosition(), GetFootSize());

        //Gizmos.DrawWireSphere(Vector2.zero, 1);
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(Vector2.zero, Vector2.one);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            currentHealth -= 25;

            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(1);
            }

        }
    }
}
