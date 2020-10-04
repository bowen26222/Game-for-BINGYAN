using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnife : Enemy
{
    [Header("Move")]
    public float radius;
    public float Speed;
    float velocityX;
    public float AccelerateTime;
    public float DecelerateTime;
    private bool IfFacingRight=false;
    Rigidbody2D Rig;
    private Transform Player;
    private float direction;
    private void Start()
    {
        base.Start();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Rig = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Player != null)
        {
            float distance = (transform.position - Player.position).sqrMagnitude;
            direction = transform.position.x - Player.position.x;
            if (distance < radius && direction < 0)
            {
                Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x, Speed * Time.fixedDeltaTime * 60, ref velocityX, AccelerateTime), Rig.velocity.y);
            }
            else if(distance < radius && direction > 0)
            {
                Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x, Speed * Time.fixedDeltaTime * 60 * -1, ref velocityX, AccelerateTime), Rig.velocity.y);
            }
            else
            {
                Rig.velocity = new Vector2(0, Rig.velocity.y);
            }
        }
        if (Rig.velocity.x > 0 && !IfFacingRight)
        {
            flip();
        }
        else if (Rig.velocity.x < 0 && IfFacingRight)
        {
            flip();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position, radius / 4);
    }
    private void flip()
    {
        IfFacingRight = !IfFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
