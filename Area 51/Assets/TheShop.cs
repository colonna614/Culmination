using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheShop : MonoBehaviour
{
    public static int currency = 0;
    public GameObject theShopOBJ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (theShopOBJ.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.H) && currency >=60)
            {
                HealthScript.health += 10;
                currency -= 60;
            }
            if (Input.GetKeyDown(KeyCode.B) && currency >= 80)
            {
                AmmoCount.ammo += 10;
                currency -= 80;
            }
        }
    }
}
