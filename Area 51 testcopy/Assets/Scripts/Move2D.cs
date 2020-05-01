using System.Collections;
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
  //public bool isGrounded = false;

  private Rigidbody2D rb;
  private Animator anim;


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
        //UpdateAnimations();
        ApplyMovement();
        ApplyMovementUp();
        // CheckCrouch();
        // CheckAttackRun();
       // State1();
        //State2();
        //waitForMousePress();
    }


    /*private void UpdateAnimations(){
          // State 1
          anim.SetBool("isMoving", isMoving);
          anim.SetBool("isShooting", isShooting);
          // State 2
          anim.SetBool("isKnifeState", isKnifeState);
          anim.SetBool("isKnifeAttacking", isKnifeAttacking);
          // State 3
          anim.SetBool("isShotgunState", isShotgunState);
          anim.SetBool("isShotgunShooting", isShotgunShooting);
        }
        */
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
      public void State1(){
        if (Input.GetKey(KeyCode.Alpha3)){
          isShotgunState = true;

            //waitForMousePress();


        } else if(Input.GetKey(KeyCode.Alpha2)){
            isShotgunState = false;
            isMoving = true;
        }
      }

      public void State2(){
        if (Input.GetKey(KeyCode.Alpha1)){
          isKnifeState = true;




        } else if(Input.GetKey(KeyCode.Alpha2)){
            isKnifeState = false;
            isMoving = true;
            //waitForMousePress();
        }
      }

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
