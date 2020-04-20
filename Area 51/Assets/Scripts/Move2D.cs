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
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    //bool bulletfacingRight = true;


  private float movementInputDirection;
  private float movementInputDirectionUp;
  bool isFacingRight = true;
  public bool isFacingUp = true;

  public float moveSpeed;
  private bool isMoving;
  private bool isShooting;
  private bool isKnifeState;
  private bool isKnifeAttacking;
  private bool isKnifeMoving;
  private bool isShotgunState;
  private bool isShotgunShooting;
  private bool isShotgunMoving;
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
    }


    private void UpdateAnimations(){
          // State 1
          anim.SetBool("isMoving", isMoving);
          anim.SetBool("isShooting", isShooting);
          // State 2
          anim.SetBool("isKnifeState", isKnifeState);
          //anim.SetBool("isKnifeMoving", isKnifeMoving);
          anim.SetBool("isKnifeAttacking", isKnifeAttacking);
          // State 3
          anim.SetBool("isShotgunState", isShotgunState);
          //anim.SetBool("isShotgunMoving", isShotgunMoving);
          anim.SetBool("isShotgunShooting", isShotgunShooting);
        }

      private void ApplyMovement(){
          Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
          transform.position += movement * Time.deltaTime * moveSpeed;

        }

        private void ApplyMovementUp(){
            Vector3 movement = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;

          }


      private void State1(){
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            //isShooting = true;
            //fire();


        } else if(Input.GetKeyUp(KeyCode.Space)){
            isShooting = false;
        }
      }

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

    // void fire ()
    // {
    //     if (AmmoCount.ammo > 0)
    //     {
    //         bulletPos = transform.position;
    //         AmmoCount.ammo -= 1;
    //         if (isFacingRight)
    //         {
    //
    //             bulletPos += new Vector2(+1f, -0.30f);
    //             Instantiate(bulletToRight, bulletPos, Quaternion.identity);
    //         }
    //         else
    //         {
    //             bulletPos += new Vector2(-1f, -0.30f);
    //             Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
    //         }
    //     }
    // }

}
