using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerbox : MonoBehaviour
{
    public GameObject[] Enemy;
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            foreach (GameObject enemy in Enemy)
            {
                enemy.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
