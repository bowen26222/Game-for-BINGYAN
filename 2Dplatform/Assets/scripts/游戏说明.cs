using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class 游戏说明 : MonoBehaviour
{
    bool Isopen;
    public GameObject Image;
    public void show()
    {
        if (!Isopen)
        {
            Image.SetActive(true);
            Isopen = true;
        }
    }
    public void vanish()
    {
        if (Isopen)
        {
            Image.SetActive(false);
            Isopen = false;
        }
    }
}
