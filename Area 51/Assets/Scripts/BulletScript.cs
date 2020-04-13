﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 500f;
    public int damage = 40;
    public Rigidbody2D rb;
    EnemyBehavior enemy;

    // Start is called before the first frame update
    void Start(){
        rb.velocity = transform.right * speed;
        enemy = GetComponent<EnemyBehavior>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("WE HIT");
            Destroy(gameObject);
            Scoring.score += 100;
            enemy.Die();
        }
        else if(col.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }

    }

}