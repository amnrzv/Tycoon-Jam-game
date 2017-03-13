using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectsManager : MonoBehaviour
{
    private static ProjectsManager _instance;

    public List<Project> projects;
    public Dictionary<uint, Project> projectsByDayDict = new Dictionary<uint, Project>();

    public static ProjectsManager Instance
    {
        get
        {
            if ( _instance == null )
                _instance = FindObjectOfType<ProjectsManager> ( );
            return _instance;
        }
    }

    private void Awake ( )
    {
        Init ( );
    }

    void Init()
    {
        projects.AddRange ( Resources.LoadAll<Project> ( "Projects" ) );

        for ( int i = 0 ; i < projects.Count ; i++ )
        {
            projectsByDayDict.Add ( projects [ i ].dayStart, projects [ i ] );
        }
    }
}
