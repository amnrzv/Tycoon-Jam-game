using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HUDTime : MonoBehaviour
{
    Text textbox;

    private void Start ( )
    {
        textbox = GetComponent<Text> ( );
    }

    private void Update ( )
    {
        textbox.text = TimeManager.Instance.GetCurrentTimeRef().GetPrettyPrintTime ( );
    }
}
