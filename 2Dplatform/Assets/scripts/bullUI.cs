﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullUI : MonoBehaviour
{
    public int startPlayerlife;
    public Text Playerlife;
    public static int CurrentPlayerlife;
    void Start()
    {
        CurrentPlayerlife = startPlayerlife;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
