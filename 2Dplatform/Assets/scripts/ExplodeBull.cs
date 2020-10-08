using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBull : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage;
    public GameObject explodeRange;
    public int speed;
    public float delayExplodeTime;
    public float hitBoxTime;
    public float destroyBombTime;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
        Invoke("Explode", delayExplodeTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            rb.velocity = transform.right * speed*0;
            anim.SetTrigger("Explode");
            Invoke("GenExplosionRange", hitBoxTime);
            Invoke("DestroyThisBomb", destroyBombTime);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            rb.velocity = transform.right * speed * 0;
            anim.SetTrigger("Explode");
            Invoke("GenExplosionRange", hitBoxTime);
            Invoke("DestroyThisBomb", destroyBombTime);
        }
    }
    void Explode()
    {
        rb.velocity = transform.right * speed * 0;
        anim.SetTrigger("Explode");
        Invoke("GenExplosionRange", hitBoxTime);
        Invoke("DestroyThisBomb", destroyBombTime);
    }

    void GenExplosionRange()
    {
        Instantiate(explodeRange, transform.position, Quaternion.identity);
    }

    void DestroyThisBomb()
    {
        Destroy(gameObject);
    }
}