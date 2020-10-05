using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int Blinks;
    public float time;
    private Renderer Render;
    bool IsDamage;
    public float invisibleTime;
    private void Start()
    {
        Render = GetComponent<Renderer>();
    }
    public void DamagePlayer(int damage)
    {
        if (!IsDamage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            BlinkPlayer(Blinks, time);
        }
    }
    void BlinkPlayer(int numBlink,float seconds)
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
        IsDamage = true;
    }
}
