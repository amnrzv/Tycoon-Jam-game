using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof( Agent ) )]
[RequireComponent ( typeof ( Animator ) )]
public class Worker : MonoBehaviour
{
    public Workspace workspace;

    [Header("Enter work times as HH:MM")]
    public string timeStart;
    public string timeEnd;
    public TycoonTime DayStartTime { get { return dayStartTime; } }
    public TycoonTime DayEndTime { get { return dayEndTime; } }

    private Chair chair;
    private Agent agent;
    private Animator anim;
    private TycoonTime dayStartTime;
    private TycoonTime dayEndTime;

    private void Awake ( )
    {
        agent = GetComponent<Agent> ( );
        anim = GetComponent<Animator> ( );
        dayStartTime = TycoonTime.GetTycoonTimeFromString(timeStart);
        dayEndTime = TycoonTime.GetTycoonTimeFromString(timeEnd);
    }

    private void OnEnable()
    {
        agent.enabled = true;
        if (workspace == null)
            FindWorkspace ( );
        GoToWorkspace ( );
    }

    public void Spawn ( )
    {
        if (TimeManager.IsWorkingTime(this))
        {
            if (workspace == null)
                FindWorkspace ( );
            GoToWorkspace ( );
        }
    }

    void FindWorkspace ( )
    {
        workspace = WorkspaceManager.FindEmptyWorkspace ( );
        workspace.SetWorker ( this );
    }

    public void GoToWorkspace ( )
    {
        if ( workspace == null )
        {
            Debug.LogErrorFormat ( "No workspace assigned to {0}", name );
            return;
        }

        agent.GoToPoint ( workspace.chair.transform.position, SitOnChair );
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
    }
}
