using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AmmoCount : MonoBehaviour
{
    Text playerammo;
    public static int ammo;
    public GameObject drive;


    void Start()
    {
        ammo = 20;
        playerammo = GetComponent<Text>();
        //drive.gameObject.SetActive(false);
    }



    void Update()
    {
        playerammo.text = "Ammo: " + ammo.ToString();
    }
}
