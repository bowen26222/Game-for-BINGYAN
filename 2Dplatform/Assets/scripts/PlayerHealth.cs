using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int Blinks;
    public float time;
    private Renderer Render;
    public PlayerUI PlayerUI;
    public GameObject Player;
    public GameObject Panel;
    bool IsDamage;
    public int Health; 
    public int health;
    public float invisibleTime;
    public Transform Playertrans;
    private void Start()
    {
        Health = health;
        Render = GetComponent<Renderer>();
        PlayerUI = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUI>();
    }
    public void DamagePlayer(int damage)
    {
        if (!IsDamage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = health;
                PlayerUI.CurrentPlayerlife -= 1;
                Playertrans = GetComponent<Transform>();
                Playertrans.position = new Vector3(Playertrans.position.x, Playertrans.position.y + 10, Playertrans.position.z);
                BlinkPlayer(Blinks, time);
                if (PlayerUI.CurrentPlayerlife == 0)
                {               
                    Panel.SetActive(true);
                    Destroy(gameObject);
                }
            }
            BlinkPlayer(Blinks, time);
        }
    }
    public void BlinkPlayer(int numBlink,float seconds)
    {
        StartCoroutine(DoBlinks(numBlink,seconds));
    }
    IEnumerator DoBlinks(int numBlink,float seconds)
    {
        IsDamage = true;
        for(int i = 1; i <= numBlink * 2; i++)
        {
            Render.enabled = !Render.enabled;
            yield return new WaitForSeconds(seconds);
        }
        Render.enabled = true;
        IsDamage = false;
    }
/*    void start()
    {
        CapsuleCollider2D C2d = GetComponent<CapsuleCollider2D>();
        C2d.enabled = true;
        playerCTRL playerCTRL = GetComponent<playerCTRL>();
        playerCTRL.enabled = true;
        Animator Anim = GetComponent<Animator>();
        Anim.enabled = true;
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        playerHealth.enabled = true;
    }*/
}
