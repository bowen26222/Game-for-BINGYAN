using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    bool IsAttack;
    bool IsUp;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Up") > 0)
        {
            IsUp = true;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
        }
        else if(IsUp)
        {
            IsUp = false;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
        if (Input.GetButtonDown("Fire1")&&!IsAttack)
        {
            Shoot();
        }
    } 
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    public void SwitchShoot(bool state)
    {
        IsAttack = state;
    }
}
