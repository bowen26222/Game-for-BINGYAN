using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwbomb : MonoBehaviour
{
    public GameObject bomb;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetButtonDown("Bomb"))
        {
            Instantiate(bomb, transform.position, transform.rotation);
        }
    }
}