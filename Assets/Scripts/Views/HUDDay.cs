﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HUDDay : MonoBehaviour
{
    Text textbox;

    private void Start ( )
    {
        textbox = GetComponent<Text> ( );
    }

    private void Update ( )
    {
        textbox.text = string.Format ( "DAY {0}", TimeManager.Day );
    }
}
