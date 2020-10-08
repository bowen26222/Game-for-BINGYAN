using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
{ 
    public int nowgun;
    public bullUI bullUI;
    public GetGun GetGun;
    public int bullnumber;
    void Start()
    {
        GetGun = GameObject.FindGameObjectWithTag("Gunposition").GetComponent<GetGun>();
        bullUI = GameObject.FindGameObjectWithTag("BullUI").GetComponent<bullUI>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetGun.currentgun = nowgun;
            bullUI.CurrentBull = bullnumber;
            Destroy(gameObject);
        }
    }
}
