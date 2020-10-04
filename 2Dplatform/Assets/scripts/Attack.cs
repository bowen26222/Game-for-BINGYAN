using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float time;
    bool IsAttack;
    public float radius;
    private Animator Anim;
    private PolygonCollider2D Collider2D;
    private Transform Enemy;
    private SpriteRenderer render;
    void Awake()
    { 
        Anim = GetComponent<Animator>();
        Collider2D = GetComponent<PolygonCollider2D>();
        render = GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>();
        Enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if (Enemy != null)
        {
            float distance = (transform.position - Enemy.position).sqrMagnitude;
            if (distance < radius && !IsAttack)
            {
                render.GetComponent<Weapon>().SwitchShoot(true);
                attack();
            }
            if(distance > radius)
            {
                render.GetComponent<Weapon>().SwitchShoot(false);
            }
        }
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position, radius / 4);
    }
    void attack()
    {
        if (Input.GetAxis("Fire1") == 1&&!IsAttack)
        {
            render.enabled = false;
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
        yield return new WaitForSeconds(0.5f);
        render.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
