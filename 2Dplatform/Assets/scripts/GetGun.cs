using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GetGun : MonoBehaviour
{
    public GameObject [] Gun;
    private int nowgun;
    public int currentgun;
    public bullUI bullUI;
    // Start is called before the first frame update
    void Start()
    {
        bullUI = GameObject.FindGameObjectWithTag("BullUI").GetComponent<bullUI>();
        foreach (GameObject Gun in Gun)
        {
            Gun.SetActive(false);
        }
        nowgun = 0;
        currentgun = 0;
        Gun[currentgun].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(nowgun != currentgun)
        {
            Gun[nowgun].SetActive(false);
            Gun[currentgun].SetActive(true);
            nowgun = currentgun;
        }
        if(bullUI.CurrentBull == 0)
        {
            Gun[nowgun].SetActive(false);
            nowgun = 0;
            currentgun = 0;
            Gun[currentgun].SetActive(true);
            bullUI.CurrentBull = 999;
        }
    }

}
