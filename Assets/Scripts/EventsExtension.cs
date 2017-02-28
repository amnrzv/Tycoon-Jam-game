using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsExtension
{
    public static void SafeInvoke(this Action _event)
    {
        if ( _event != null )
            _event ( );
    }

    public static void SafeInvoke<T>(this Action<T> _event, T _arg)
    {
        if(_event != null)
            _event(_arg);
    }
}
