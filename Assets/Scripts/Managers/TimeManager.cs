using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager _instance;

    public static uint Day = 1;
    private static TycoonTime Time;

    private Dictionary<TycoonTime, List<Worker>> workersStartTimeMap;
    private Dictionary<TycoonTime, List<Worker>> workersEndTimeMap;
    private const float UPDATE_SPEED_CONST = 0.3f;
    private IEnumerator runGameCoroutine;

    //updateSpeed is inversely proportional to gameSpeed.
    //gameSpeed is an integer 0, 1 or 2
    public int gameSpeed;
    [Tooltip("Represent start time as HH:MM")]
    public string gameStartTime = "08:30";
    
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

    public TycoonTime GetCurrentTimeValue()
    {
        return new TycoonTime ( Time.hours, Time.minutes );
    }

    public TycoonTime GetCurrentTimeRef ( )
    {
        return Time;
    }

    private void OnEnable ( )
    {
        EventsManager.OnEmployeeAdded += OnEmployeeAdded;
    }

    private void OnDisable ( )
    {
        EventsManager.OnEmployeeAdded -= OnEmployeeAdded;
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
        Time = TycoonTime.GetTycoonTimeFromString ( gameStartTime );
        UpdateGameSpeed ( gameSpeed );
    }

    public void UpdateGameSpeed ( int gameSpeed )
    {
        this.gameSpeed = gameSpeed;

        UnityEngine.Time.timeScale = gameSpeed ;
        if (runGameCoroutine != null)
            StopCoroutine ( runGameCoroutine );
        runGameCoroutine = RunGameTime ( );
        StartCoroutine ( runGameCoroutine );
    }
    IEnumerator RunGameTime()
    {
        while(gameSpeed != 0)
        {
            yield return new WaitForSeconds ( UPDATE_SPEED_CONST );
            Time.AddMinutes ( 1 );

            if (Time.hours == 10 && Time.minutes == 0)
            {
                CheckForProjects ( );
            }
        }
    }

    void CheckForProjects()
    {
        if (ProjectsManager.Instance.projectsByDayDict.ContainsKey(Day))
        {
            EventsManager.ShowProjectOffer ( ProjectsManager.Instance.projectsByDayDict [ Day ] );
        }
    }

    public static bool IsWorkingTime(Worker worker)
    {
        if(Time > worker.DayStartTime && Time < worker.DayEndTime)
            return true;

        return false;
    }

    private void Update ( )
    {
        if (workersStartTimeMap.ContainsKey(Time))
        {
            for ( int i = 0 ; i < workersStartTimeMap[Time].Count ; i++ )
            {
                workersStartTimeMap [ Time ] [ i ].StartDay ( );
            }
        }

        if ( workersEndTimeMap.ContainsKey ( Time ) )
        {
            for ( int i = 0 ; i < workersEndTimeMap [ Time ].Count ; i++ )
            {
                workersEndTimeMap [ Time ] [ i ].EndDay ( );
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
