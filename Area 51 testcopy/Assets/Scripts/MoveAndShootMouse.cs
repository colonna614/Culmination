using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndShootMouse : MonoBehaviour
{
  public Transform firePoint;
  public Transform firePoint1;
  public Transform firePoint2;

    bool pistolState = true;
  public bool isShotgunState = false;
    public static bool purchasedShotgun = false;

  public GameObject bulletToRight;

  private Vector2 bulletPos;
  private float lookAngle;


    void Update()
    {
      bulletPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
      lookAngle = Mathf.Atan2(bulletPos.y, bulletPos.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);

      if (AmmoCount.ammo > 0){
        bulletPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (pistolState == true)
                {
                    ShootBullet();
                    AmmoCount.ammo -= 1;
                }

        }

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space) )
        {
                if (isShotgunState == true && AmmoCount.ammo>=3)
                {
                    ShootBulletSpread();
                    AmmoCount.ammo -= 3;
                }
        }

      }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistolState = true;
            isShotgunState = false;
            Debug.Log("Pistol active" + pistolState);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && purchasedShotgun)
        {
            pistolState = false;
            isShotgunState = true;
            Debug.Log("shotgun active" + isShotgunState);
        }

    }

    public void ShootBullet(){
      GameObject firedBullet = Instantiate(bulletToRight, firePoint.position, firePoint.rotation);
      firedBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right;
    }

     public void ShootBulletSpread(){
       GameObject firedBullet = Instantiate(bulletToRight, firePoint.position, firePoint.rotation);
       GameObject firedBullet2 = Instantiate(bulletToRight, firePoint1.position, firePoint1.rotation);
       GameObject firedBullet3 = Instantiate(bulletToRight, firePoint2.position, firePoint2.rotation);
       firedBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right;
       firedBullet2.GetComponent<Rigidbody2D>().velocity = firePoint1.right;
       firedBullet3.GetComponent<Rigidbody2D>().velocity = firePoint2.right;
     }



}
