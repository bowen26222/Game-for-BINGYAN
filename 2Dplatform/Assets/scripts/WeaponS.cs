using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class WeaponS : Weapon
{
    float velocityX;
    bool IsShooting;
    public bullUI bullUI;
    public float AccelerateTime;
    public float DecelerateTime;
    private void Start()
    {
        bullUI = GameObject.FindGameObjectWithTag("BullUI").GetComponent<bullUI>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Up") > 0)
        {
            IsUp = true;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.SmoothDamp(transform.eulerAngles.z, 90, ref velocityX, AccelerateTime));
        }
        else if(IsUp)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.SmoothDamp(transform.eulerAngles.z, 0, ref velocityX, DecelerateTime));
            if (transform.eulerAngles.z == 0)
            {
                IsUp = false;
            }
        }
        if (Input.GetAxis("Fire1") == 1 && !IsAttack && !IsShooting)
        {
            IsShooting = true;
            bullUI.CurrentBull -= 1;
            Shoot();
            StartCoroutine(waittime(Cooltime));
        }
    }
    IEnumerator waittime(float time)
    {
        yield return new WaitForSeconds(time);
        IsShooting = false;
    }
}
