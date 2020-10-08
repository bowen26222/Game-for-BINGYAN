using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullUI : MonoBehaviour
{
    public int startBull;
    public Text Bullnumber;
    public static int CurrentBull;
    void Start()
    {
        CurrentBull = startBull;
    }

    // Update is called once per frame
    void Update()
    {
        Bullnumber.text = CurrentBull.ToString();
    }
}
