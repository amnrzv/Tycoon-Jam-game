using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Serializable]
    public class TycoonTime
    {
        public int hours;
        public int minutes;

        public TycoonTime(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }

        public string GetPrettyPrintTime()
        {
            return string.Format ( "{0:00}:{1:00}{2}", hours > 12 ? hours % 12 : hours, minutes, hours < 12 ? "AM" : "PM");
        }

        public void AddMinutes(int minutes)
        {
            this.minutes += minutes;
            if ( this.minutes >= 60 )
                hours++;
            hours = hours % 24;
            this.minutes = this.minutes % 60;
        }
    }

    //updateSpeed is inversely proportional to gameSpeed.
    //gameSpeed is an integer 0, 1 or 2
    public int gameSpeed;
    public static TycoonTime time;
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

    private void Start ( )
    {
        time = new TycoonTime ( 6, 0 );
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
            return 10;
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
}
