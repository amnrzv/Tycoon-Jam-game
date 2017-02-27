using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTimeView : MonoBehaviour
{
    public ToggleGroup toggleGroup;

    public void OnSpeedUpdated(int speed)
    {
        TimeManager.Instance.UpdateGameSpeed ( speed );
    }

    private void Start ( )
    {
        foreach(Toggle toggle in toggleGroup.ActiveToggles())
        {
            toggle.Select ( );
        }
    }
}
