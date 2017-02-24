using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceManager : MonoBehaviour
{
    public static List<Workspace> workspaces;

    private void Awake ( )
    {
        workspaces = new List<Workspace> ( FindObjectsOfType<Workspace> ( ) );
    }

    public static Workspace FindEmptyWorkspace ()
    {
        for ( int i = 0 ; i < workspaces.Count ; i++ )
        {
            if ( !workspaces [ i ].HasWorker ( ) )
                return workspaces [ i ];
        }

        return null;
    }
}
