using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireEmployeeRow : MonoBehaviour
{
    public Text employeeName;
    public Text rate;
    public Text role;

    private Worker employee;

    private void OnEnable ( )
    {
        GetComponent<Toggle> ( ).isOn = true;
    }

    public void Populate ( Worker employee )
    {
        this.employee = employee;
        employeeName.text = employee.employeeName;
        rate.text = string.Format ( "{0} p.h.", employee.hourlyRate );
        role.text = employee.role.ToString ( );
    }

    public void OnSelect()
    {
        EventsManager.OnEmployeeSelected ( this.employee );
    }
}
