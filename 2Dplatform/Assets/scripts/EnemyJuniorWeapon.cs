using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyJuniorWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float ColdTime;
    public float radius;
    bool IsShooting;
    float direction;
    private Transform Player;
    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public void Update()
    {
        if (Player != null)
        {
            float distance = (transform.position - Player.position).sqrMagnitude;
            direction = transform.position.x - Player.position.x;
            if (distance < radius && !IsShooting)
            {
                StartCoroutine(PrepareShoot(ColdTime));
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position , radius/4);
    }
    IEnumerator PrepareShoot(float time)
    {
        IsShooting = true;
        if (direction > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        yield return new WaitForSeconds(time);
        Shoot();
        IsShooting = false;
    }
    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
