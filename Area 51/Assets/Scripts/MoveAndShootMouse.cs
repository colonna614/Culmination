using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndShootMouse : MonoBehaviour
{
  public Transform firePoint;

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

        if (Input.GetKeyDown(KeyCode.Space)){
          ShootBullet();
          AmmoCount.ammo -= 1;
        }

      }

    }

    public void ShootBullet(){
      GameObject firedBullet = Instantiate(bulletToRight, firePoint.position, firePoint.rotation);
      firedBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right;
    }



}
