using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //updateSpeed is inversely proportional to gameSpeed.
    //gameSpeed is an integer 0, 1 or 2
    public int gameSpeed;
    [Tooltip("Represent start time as HH:MM")]
    public string gameStartTime = "08:30";
    public static TycoonTime time;

    private Dictionary<TycoonTime, List<Worker>> workersStartTimeMap;
    private Dictionary<TycoonTime, List<Worker>> workersEndTimeMap;
    private float updateSpeed;
    private const float UPDATE_SPEED_CONST = 0.2f;
    private static TimeManager _instance;
    private IEnumerator runGameCoroutine;

    public static TimeManager Instance
    {
        get
        {
            if ( _instance == null )
            {
                _instance = FindObjectOfType<TimeManager> ( );
            }
            return _instance;
        }
    }

    private void OnEnable ( )
    {
        EventsManager.EmployeeAdded += OnEmployeeAdded;
    }

    private void OnDisable ( )
    {
        EventsManager.EmployeeAdded -= OnEmployeeAdded;
    }

    void OnEmployeeAdded(Worker employee)
    {
        if ( workersStartTimeMap.ContainsKey ( employee.DayStartTime ) )
            workersStartTimeMap [ employee.DayStartTime ].Add ( employee );
        else
            workersStartTimeMap.Add ( employee.DayStartTime, new List<Worker> { employee } );

        if ( workersEndTimeMap.ContainsKey ( employee.DayEndTime ) )
            workersEndTimeMap [ employee.DayEndTime ].Add ( employee );
        else
            workersEndTimeMap.Add ( employee.DayEndTime, new List<Worker> { employee } );

    }

    private void Start ( )
    {
        workersStartTimeMap = new Dictionary<TycoonTime, List<Worker>> ( );
        workersEndTimeMap = new Dictionary<TycoonTime, List<Worker>> ( );
        time = TycoonTime.GetTycoonTimeFromString ( gameStartTime );
        UpdateGameSpeed ( gameSpeed );
    }

    public void UpdateGameSpeed ( int gameSpeed )
    {
        this.gameSpeed = gameSpeed;
        updateSpeed = GetUpdateSpeedForGameSpeed ( this.gameSpeed );

        Time.timeScale = gameSpeed;
        if (runGameCoroutine != null)
            StopCoroutine ( runGameCoroutine );
        runGameCoroutine = RunGameTime ( );
        StartCoroutine ( runGameCoroutine );
    }

    float GetUpdateSpeedForGameSpeed ( int gameSpeed )
    {
        if ( gameSpeed == 0 )
            return 0;
        return UPDATE_SPEED_CONST / gameSpeed;
    }

    IEnumerator RunGameTime()
    {
        while(gameSpeed != 0)
        {
            yield return new WaitForSeconds ( updateSpeed );
            time.AddMinutes ( 1 );
        }
    }

    public static bool IsWorkingTime(Worker worker)
    {
        if(time > worker.DayStartTime && time < worker.DayEndTime)
            return true;

        return false;
    }

    private void Update ( )
    {
        if (workersStartTimeMap.ContainsKey(time))
        {
            for ( int i = 0 ; i < workersStartTimeMap[time].Count ; i++ )
            {
                workersStartTimeMap [ time ] [ i ].StartDay ( );
            }
        }

        if ( workersEndTimeMap.ContainsKey ( time ) )
        {
            for ( int i = 0 ; i < workersEndTimeMap [ time ].Count ; i++ )
            {
                workersEndTimeMap [ time ] [ i ].EndDay ( );
            }
        }


        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown ( KeyCode.Alpha0 ) )
            {
                UpdateGameSpeed ( 0 );
            }
            else if ( Input.GetKeyDown ( KeyCode.Keypad1 ) || Input.GetKeyDown ( KeyCode.Alpha1 ) )
            {
                UpdateGameSpeed ( 1 );
            }
            else if ( Input.GetKeyDown ( KeyCode.Keypad5 ) || Input.GetKeyDown ( KeyCode.Alpha5 ) )
            {
                UpdateGameSpeed ( 5 );
            }
        }
    }
}
