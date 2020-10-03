using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    bool IsFindPlayer;
    private Transform Player;
    private Vector2 gunDirection;
    // Update is called once per frame
    void Update()
    {   
        if (IsFindPlayer)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            gunDirection = (Player.position - transform.position).normalized;
            float angle = (Mathf.Atan2(gunDirection.x, gunDirection.y) * Mathf.Rad2Deg + 90) * -1;
            transform.eulerAngles = new Vector3(0, 0, angle);
            Shoot();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            IsFindPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsFindPlayer = false;
        }
    }
    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
