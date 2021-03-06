﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EmployeeRole
{
    Programmer,
    Artist
}

[RequireComponent(typeof( Agent ) )]
[RequireComponent ( typeof ( Animator ) )]
public class Worker : MonoBehaviour
{
    private enum WorkMode
    {
        Working,
        Walking,
        Chatting
    }

    public Workspace workspace;
    [Header("Employee Details")]
    public string employeeName;
    public float hourlyRate;
    public EmployeeRole role;

    [Header("Enter work times as HH:MM")]
    [SerializeField]
    private string timeStart = "09:30";
    [SerializeField]
    private string timeEnd = "18:00";

    [Header("Employee Skills")]
    [SerializeField]
    private int codeSkills;
    [SerializeField]
    private int designSkills;

    public TycoonTime DayStartTime { get { return TycoonTime.GetTycoonTimeFromString ( timeStart ); } }
    public TycoonTime DayEndTime { get { return TycoonTime.GetTycoonTimeFromString ( timeEnd ); } }

    private WorkMode workMode;
    private Chair chair;
    private Agent agent;
    private Animator anim;
    private Transform spawnPoint;

    private void Awake ( )
    {
        agent = GetComponent<Agent> ( );
        anim = GetComponent<Animator> ( );
    }

    //If the prefabs are active by default,
    //when you hire a worker they spawn right away
    //irrespective of the current game time
    private void OnEnable()
    {
        agent.enabled = true;
        if (workspace == null)
            FindWorkspace ( );
        GoToWorkspace ( );
    }

    public void Spawn ( )
    {
        if ( spawnPoint == null)
            spawnPoint = GameManager.Instance.spawnPoint;
        if (TimeManager.IsWorkingTime(this))
            StartDay ( );
    }

    private TycoonTime currentStartDayTime;
    private TycoonTime timeAtWorkToday;
    public void StartDay()
    {
        //Worker is already activated
        if ( gameObject.activeInHierarchy )
            return;

        transform.position = spawnPoint.position + Random.insideUnitSphere;
        transform.rotation = spawnPoint.rotation;
        gameObject.SetActive ( true );
        if ( !agent.enabled )
            agent.enabled = true;
        if ( workspace == null )
            FindWorkspace ( );
        currentStartDayTime = TimeManager.Instance.GetCurrentTimeValue();
        GoToWorkspace ( );
    }

    public void EndDay()
    {
        if ( isActiveAndEnabled && workMode == WorkMode.Working)
        {
            GoHome ( );
            ChargeWage ( );
        }
    }

    void FindWorkspace ( )
    {
        workspace = WorkspaceManager.FindEmptyWorkspace ( );
        workspace.SetWorker ( this );
    }

    void ChargeWage()
    {
        timeAtWorkToday = TimeManager.Instance.GetCurrentTimeRef() - currentStartDayTime;
        GameDataManager.Instance.ConsumeMoney ( ( uint ) Mathf.RoundToInt ( ( timeAtWorkToday.hours + timeAtWorkToday.minutes / 60f ) * hourlyRate ) );
    }

    void GoHome ( )
    {
        agent.enabled = true;
        agent.SetAgentRotation ( true );
        anim.SetTrigger ( "stand" );
        workspace.chair.ResetPosition ( );
        agent.GoToPoint ( GameManager.Instance.spawnPoint.position, Deactivate );
        workMode = WorkMode.Walking;
    }

    void Deactivate ( )
    {
        gameObject.SetActive ( false );
    }

    public void GoToWorkspace ( )
    {
        if ( workspace == null )
        {
            Debug.LogErrorFormat ( "No workspace assigned to {0}", name );
            return;
        }

        agent.GoToPoint ( workspace.chair.transform.position, SitOnChair );
        workMode = WorkMode.Walking;
    }

    void SitOnChair ( )
    {
        this.chair = workspace.chair;
        chair.NeedsPullingBack ( );
        agent.enabled = false;
        agent.SetAgentRotation ( false );
        transform.position = workspace.GetSeatingPosition();
        transform.LookAt ( new Vector3(workspace.computer.transform.position.x, 0, workspace.computer.transform.position.z) );
        anim.SetTrigger ( "sit" );
        workMode = WorkMode.Working;
    }
}
