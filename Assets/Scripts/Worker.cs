using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof( Agent ) )]
[RequireComponent ( typeof ( Animator ) )]
public class Worker : MonoBehaviour
{
    public Workspace workspace;

    private Chair chair;
    private Agent agent;
    private Animator anim;

    private void Awake ( )
    {
        agent = GetComponent<Agent> ( );
        anim = GetComponent<Animator> ( );
    }

    public void Spawn ( )
    {
        FindWorkspace ( );
    }

    void FindWorkspace ( )
    {
        workspace = WorkspaceManager.FindEmptyWorkspace ( );
        workspace.SetWorker ( this );
        GoToWorkspace ( );
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
