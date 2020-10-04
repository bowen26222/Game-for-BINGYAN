using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySeniorWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float ColdTime;
    public float radius;
    bool IsShooting;
    private Transform Player;
    private Vector2 gunDirection;
    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    public void Update()
    {
        if (Player != null)
        {
            gunDirection = (Player.position - transform.position).normalized;
            float angle = (Mathf.Atan2(gunDirection.x, gunDirection.y) * Mathf.Rad2Deg + 90) * -1;
            transform.eulerAngles = new Vector3(0, 0, angle);
            float distance = (transform.position - Player.position).sqrMagnitude;
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
