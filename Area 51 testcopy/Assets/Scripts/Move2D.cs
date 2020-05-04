﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    public GameObject MainCharacter;
    //public float jumpVelocity = 50f;
    public GameObject Player;
    public GameObject deathEffect;
    public GameObject bulletToRight, bulletToLeft;
    public GameObject GameOver;
    public GameObject StatsBar;
    //Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    private Vector2 bulletPos;
    private float lookAngle;

    //bool bulletfacingRight = true;
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;


  private float movementInputDirection;
  private float movementInputDirectionUp;
  bool isFacingRight = true;
  public bool isFacingUp = true;

  public float moveSpeed;
  private bool isMoving;
  public bool isShooting;
  public bool isKnifeState;
  public bool isKnifeAttacking;
  public bool isKnifeMoving;
  public bool isShotgunState;
  public bool isShotgunShooting;
  public bool isShotgunMoving;
  public bool isIdle;
    public static bool OutOfShop =true;
    
    public bool isShotgunActive = false;
    public bool isPistolActive =true;
    public bool isKnifeActive =false;
    public bool isKnifeSwing =false;
    //public bool isGrounded = false;

    private Rigidbody2D rb;
  private Animator anim;

    public GameObject KnifeBox;
    int knifetimer = 0;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){

      bulletPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
      lookAngle = Mathf.Atan2(bulletPos.y, bulletPos.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);

        CheckInput();
        CheckInputUp();
        CheckMovementDirection();
        CheckMovementDirectionUp();
        UpdateAnimations();
        ApplyMovement();
        ApplyMovementUp();
        // CheckCrouch();
        // CheckAttackRun();
        State1();
        //State2();
        //waitForMousePress();
    }


    private void UpdateAnimations()
    {
        // State 1
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isPistolActive", isPistolActive);
        // State 2
        anim.SetBool("isKnifeActive", isKnifeActive);
        anim.SetBool("isKnifeSwing", isKnifeSwing);
        // State 3
        anim.SetBool("isShotgunActive", isShotgunActive);
        //anim.SetBool("isShotgunShooting", isShotgunShooting);
    }

    //
    private void ApplyMovement(){
          Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
          transform.position += movement * Time.deltaTime * moveSpeed;

        }

        //
        private void ApplyMovementUp(){
            Vector3 movement = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;

          }


    // STATE 1 = Knife State
    //
    public void State1()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            isPistolActive = true;
            isKnifeActive = false;
            isShotgunActive = false;   
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            isPistolActive = false;
            isKnifeActive = true;
            isShotgunActive = false;
            isKnifeSwing = false;

        }
        if (Input.GetKey(KeyCode.Alpha3) && MoveAndShootMouse.purchasedShotgun)
        {
            isPistolActive = false;
            isKnifeActive = false;
            isShotgunActive = true;
        }
        if (isKnifeActive && OutOfShop)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                SoundManagerScript.PlaySound("SFX/Knife");
                isKnifeSwing = true;
                KnifeBox.SetActive(true);
            }
            else
            {
                isKnifeSwing = false;
            }
        }
        if (KnifeBox.activeSelf ==true)
        {
            knifetimer += 1;
        }
        if (knifetimer >= 100)
        {
            KnifeBox.SetActive(false);
            knifetimer = 0;
        }
        //Debug.Log(knifetimer + "knife timer");
    }
    /*
          public void State2(){
            if (Input.GetKey(KeyCode.Alpha1)){
              isKnifeState = true;




            } else if(Input.GetKey(KeyCode.Alpha2)){
                isKnifeState = false;
                isMoving = true;
                //waitForMousePress();
            }
          }
          */
    // Movement Left and Right
    private void CheckMovementDirection(){
          if (isFacingRight && movementInputDirection < 0){
              Flip();
          }
          else if (!isFacingRight && movementInputDirection > 0){
              Flip();
          }

          if (movementInputDirection != 0){
              isMoving = true;

          }
          else{
              isMoving = false;

          }
      }

      // Movement Up and Down
      private void CheckMovementDirectionUp(){
          if (isFacingUp && movementInputDirectionUp < 0){
              //Flip();
          }
          else if (!isFacingUp && movementInputDirectionUp > 0){
              //Flip();
          }

          if (movementInputDirectionUp != 0){
              isMoving = true;

          }
          else{
              isMoving = false;

          }
      }

      private void CheckInput(){
          movementInputDirection = Input.GetAxis("Horizontal");
      }

      private void CheckInputUp(){
          movementInputDirectionUp = Input.GetAxis("Vertical");
      }


      private void Flip(){
          isFacingRight = !isFacingRight;
          transform.Rotate(0.0f, 180.0f, 0.0f);
      }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Obstacle")
        {
            SoundManagerScript.PlaySound("SFX/GetHit");
            Debug.Log("OUCH!");
            HealthScript.health -= 10f;
        }

        if (HealthScript.health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            GameOver.SetActive(true);
            StatsBar.SetActive(false);
            Time.timeScale = 0;
            MainCharacter.SetActive(false);
        }
    }
    

}
