using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public GameObject deathEffect;
    public GameObject Enemy;
    public GameObject Player;
    private Rigidbody2D rb;
    public float moveSpeed = 1f;

    public static int killcount = 0;

    private Vector2 movement;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }


    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    public void Die()
    {
      //  Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthScript.health -= 10f;
            EnemyCountDisplay.enemies -= 1;
            killcount += 1;
            Die();
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            EnemyCountDisplay.enemies -= 1;
            killcount += 1;
            TheShop.currency += 10;
            Die();
        }

    }
}