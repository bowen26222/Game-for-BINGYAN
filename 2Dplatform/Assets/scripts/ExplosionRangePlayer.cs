using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRangePlayer : MonoBehaviour
{
    public int damage;
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}