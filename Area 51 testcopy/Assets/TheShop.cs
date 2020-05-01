using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheShop : MonoBehaviour
{
    public static int currency = 0;
    public GameObject theShopOBJ;
    public Image ShotgunSprite;
    public Text Number3;
    public Image ShotSoldOut;
    public Image healthSoldOut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (theShopOBJ.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.H) && currency >=60 && HealthScript.health <100)
            {
                HealthScript.health += 10;
                currency -= 60;
            }
            if (Input.GetKeyDown(KeyCode.B) && currency >= 80)
            {
                AmmoCount.ammo += 15;
                currency -= 80;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && currency >= 200 && MoveAndShootMouse.purchasedShotgun == false)
            {
                MoveAndShootMouse.purchasedShotgun = true;
                ShotgunSprite.enabled = true;
                Number3.enabled = true;
                ShotSoldOut.enabled = true;
                currency -= 200;
            }
            if (HealthScript.health >= 100)
            {
                healthSoldOut.enabled = true;
            }
            else
            {
                healthSoldOut.enabled = false;
            }
        }
    }
}
