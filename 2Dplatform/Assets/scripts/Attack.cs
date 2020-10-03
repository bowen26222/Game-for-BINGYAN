using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float time;
    bool IsAttack;
    private Animator Anim;
    private PolygonCollider2D Collider2D;
    void Awake()
    { 
        Anim = GetComponent<Animator>();
        Collider2D = GetComponent<PolygonCollider2D>();
    }
    private void FixedUpdate()
    {
        attack();
    }
    void attack()
    {
        if (Input.GetAxis("Attack") == 1&&!IsAttack)
        {        
            Anim.SetTrigger("Attack");
            IsAttack = true;
        }
    }void enableAttack()
    {
        Collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        Collider2D.enabled = false;
        IsAttack = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
