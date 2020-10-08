using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTriggerbox : MonoBehaviour
{
    public bullUI bullUI;
    public GetGun GetGun;
    public PlayerUI PlayerUI;
    public GameObject Panel;
    void Start()
    {
        GetGun = GameObject.FindGameObjectWithTag("Gunposition").GetComponent<GetGun>();
        bullUI = GameObject.FindGameObjectWithTag("BullUI").GetComponent<bullUI>();
        PlayerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            GetGun.currentgun = 0;
            bullUI.CurrentBull = 999;
            playerHealth.Health = playerHealth.health;
            PlayerUI.CurrentPlayerlife -= 1;
            playerHealth.Playertrans = other.GetComponent<Transform>();
            playerHealth.Playertrans.position = new Vector3(playerHealth.Playertrans.position.x-4, playerHealth.Playertrans.position.y + 10, playerHealth.Playertrans.position.z);
            playerHealth.BlinkPlayer(playerHealth.Blinks,playerHealth.time);
            if (PlayerUI.CurrentPlayerlife == 0)
            {
                Panel.SetActive(true);
                Destroy(playerHealth.gameObject);
            }
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
