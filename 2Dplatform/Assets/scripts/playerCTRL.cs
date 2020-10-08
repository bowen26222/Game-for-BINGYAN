using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCTRL : MonoBehaviour
{
    [Header("移动")]
    public float WalkSpeed;
    public float AccelerateTime;
    public float DecelerateTime;
    [Header("跳跃")]
    public float JumpingSpeed;
    public float FallMultiplier;
    public float LowJumpMultiplier;
    [Header("触底判定")]
    public Vector2 PointOffset;
    public Vector2 Size;
    public LayerMask GroundLayerMask;
    [Header("菜单")]
    public 暂停按钮 stop;
    bool IsOnGround;
    bool IsJumping;
    bool IsSquat;
    float velocityX;
    private bool IfFacingRight=true;
    Animator Anim;
    Rigidbody2D Rig;
    SpriteRenderer SR;
    void Awake()
    {
        Rig = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        SwitchAnimation();
    }
    void FixedUpdate()
    {
        IsOnGround = OnGround();
        if (Input.GetAxis("Horizontal") > 0 )
        {
            Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x, WalkSpeed * Time.fixedDeltaTime * 60, ref velocityX, AccelerateTime), Rig.velocity.y);
            Anim.SetFloat("Walk", 1f);
        }
        else if (Input.GetAxis("Horizontal") < 0 )
        {
            Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x, WalkSpeed * Time.fixedDeltaTime * 60 * -1, ref velocityX, AccelerateTime) , Rig.velocity.y);
            Anim.SetFloat("Walk", 1f);
        }
        else
        {
            Rig.velocity = new Vector2(Mathf.SmoothDamp(Rig.velocity.x,0, ref velocityX, DecelerateTime), Rig.velocity.y);
            Anim.SetFloat("Walk", 0f);
        }

        if(Input.GetAxis("Jump")== 1&& !IsJumping&&!IsSquat)
        {
            Anim.SetBool("Jump",true);
            Rig.velocity = new Vector2(Rig.velocity.x, JumpingSpeed);
            IsJumping = true;
        }
        if (IsOnGround&& Input.GetAxis("Jump")==0)
        {
            IsJumping = false;
        }
        if (Rig.velocity.y < 0)
        {
            Rig.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if ( Rig.velocity.y > 0 && Input.GetAxis("Jump") != 1)
        {
            Rig.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
        if (Rig.velocity.x > 0.3&& !IfFacingRight)
        {
            flip();
        }
        else if(Rig.velocity.x < -0.3 && IfFacingRight)
        {
            flip();
        }

        if (Input.GetAxis("Squat") > 0 && IsSquat == false)
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.8151283f, 0.577193f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0.005381584f, -0.5f);
            GameObject.FindGameObjectWithTag("Gunposition").transform.localPosition = new Vector3(0.76f, -0.85f,0);
            Anim.SetBool("Squat", true);
            IsSquat = true;
            WalkSpeed *= (float)0.5f;
        }
        else if(IsSquat == true && Input.GetAxis("Squat") == 0)
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.8151283f, 1.39697f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0.005381584f, -0.1956443f);
            GameObject.FindGameObjectWithTag("Gunposition").transform.localPosition = new Vector3(0.76f, -0.37f, 0);
            Anim.SetBool("Squat", false);
            IsSquat = false;
            WalkSpeed *= 2;
        }
    }
    void SwitchAnimation()
    {
        Anim.SetBool("Idle", false);
        if (Anim.GetBool("Jump"))
        {
            if (Rig.velocity.y < 0.0f)
            {
                Anim.SetBool("Jump", false);
                Anim.SetBool("Fall", true);
            }
        }
        else if (IsOnGround)
        {
            Anim.SetBool("Fall", false);
            Anim.SetBool("Idle", true);
        }
    }
    bool OnGround()
    {
        Collider2D Coll = Physics2D.OverlapBox((Vector2)transform.position + PointOffset, Size, 0, GroundLayerMask);
        if (Coll)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + PointOffset, Size);
    }
    private void flip()
    {
        IfFacingRight = !IfFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
