using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpV2 : MonoBehaviour
{
    public Text pickUpText;
    public bool pickUpAllowed = false;
    public GameObject crate;
    public GameObject drive;

    void Start()
    {
        crate.gameObject.SetActive(true);
        //drive.gameObject.SetActive(false);
       //pickUpText.GetComponent<Text>().enabled = false;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickUpCrate();
        }
    }
    

    public void PickUpCrate()
    {
        if (gameObject.tag == "Health")
        {
            HealthScript.health += 10f;
            Destroy(gameObject);
        }
        if (gameObject.tag == "Ammo")
        {
            AmmoCount.ammo += 10;
            Destroy(gameObject);
        }

    }

   /* public void WinCondition()
    {
        if (Scoring.score >= 500)
        {
            drive.gameObject.SetActive(true);

        }
    }
    */
}