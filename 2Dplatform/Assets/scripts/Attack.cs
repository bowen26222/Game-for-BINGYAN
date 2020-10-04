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
    public List<Transform> targets;
    void Awake()
    { 
        Anim = GetComponent<Animator>();
        Collider2D = GetComponent<PolygonCollider2D>();
        render = GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        targets = new List<Transform>();
        addAllElements();
        if (targets.Count != 0)
        {
            targetEnemy();
        }
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
            if(distance > radius )
            {
                render.GetComponent<Weapon>().SwitchShoot(false);
            }
        }
        else
        {
            render.GetComponent<Weapon>().SwitchShoot(false);
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
#pragma warning disable IDE0051 // 删除未使用的私有成员
    }void enableAttack()
#pragma warning restore IDE0051 // 删除未使用的私有成员
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
    public void addAllElements()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in go)
        {
            addTarget(enemy.transform);
        }
        sortTargetByDistance();
    }

    private void addTarget(Transform enemy)
    {
        targets.Add(enemy);
    }

    private void sortTargetByDistance()
    {
        targets.Sort(delegate (Transform t1, Transform t2) {
            return Vector3.Distance(t1.position, transform.position).CompareTo(Vector3.Distance(t2.position, transform.position));
        });
    }
    public void targetEnemy()
    {
        if (Enemy != targets[0])
        {
            Enemy = targets[0];
        }
    }
}
