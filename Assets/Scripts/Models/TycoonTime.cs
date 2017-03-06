using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TycoonTime : IComparable<TycoonTime>
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
        return string.Format("{0:00}:{1:00}{2}", hours > 12 ? hours % 12 : hours, minutes, hours < 12 ? "AM" : "PM");
    }

    public void AddMinutes(int minutes)
    {
        this.minutes += minutes;
        if(this.minutes >= 60)
            hours++;
        //Next Day
        if ( hours == 24 )
            TimeManager.day++;
        hours = hours % 24;
        this.minutes = this.minutes % 60;
    }

    public int CompareTo(TycoonTime obj)
    {
        if(hours > obj.hours)
            return 1;
        else if(hours < obj.hours)
            return -1;
        else if(minutes > obj.minutes)
            return 1;
        else if(minutes < obj.minutes)
            return -1;

        return 0;
    }

    public static TycoonTime GetTycoonTimeFromString(string timeAsString)
    {
        if(!timeAsString.Contains(":"))
            Debug.LogError("Invalid time");

        string[] hm = timeAsString.Split(':');
        int h, m;
        if(int.TryParse(hm[0], out h) && int.TryParse(hm[1], out m))
            return new TycoonTime(int.Parse(hm[0]), int.Parse(hm[1]));
        else
            Debug.LogError("Invalid time");

        return new TycoonTime(0, 0);
    }

    public static bool operator > (TycoonTime t1, TycoonTime t2)
    {
        return t1.CompareTo(t2) == 1;
    }

    public static bool operator < (TycoonTime t1, TycoonTime t2)
    {
        return t1.CompareTo(t2) == -1;
    }

    public static bool operator == (TycoonTime t1, TycoonTime t2)
    {
        return t1.CompareTo(t2) == 0;
    }

    public static bool operator !=(TycoonTime t1, TycoonTime t2)
    {
        return t1.CompareTo(t2) != 0;
    }

    public override bool Equals ( object obj )
    {
        return ( this as TycoonTime ) == ( obj as TycoonTime );
    }

    public override int GetHashCode ( )
    {
        return hours * 60 + minutes;
    }

    public override string ToString ( )
    {
        return string.Format ( "{0:00}:{1:00}", hours, minutes );
    }
}

