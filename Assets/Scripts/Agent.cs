using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Agent : MonoBehaviour
{
    private Animator anim;
    public NavMeshAgent navMeshAgent;
    private Vector3 destination;
    private Vector2 smoothDeltaPosition = Vector2.zero;
    private Vector2 velocity = Vector2.zero;

    public delegate void MoveCompleteCallback( );
    MoveCompleteCallback moveComplete;

    private void Awake ( )
    {
        navMeshAgent = GetComponent<NavMeshAgent> ( );
        anim = GetComponent<Animator> ( );
        navMeshAgent.updatePosition = false;
    }

    public void GoToPoint ( Vector3 point, MoveCompleteCallback moveCompleteCallback = null )
    {
        destination = new Vector3 ( point.x, 0, point.z );
        navMeshAgent.destination = destination;
        moveComplete = moveCompleteCallback;
    }

    private void OnAnimatorMove ( )
    {
        Vector3 position = anim.rootPosition;
        position.y = navMeshAgent.nextPosition.y;
        transform.position = position;
    }

    public void SetAgentRotation(bool state)
    {
        navMeshAgent.updateRotation = state;
    }

    private void Update ( )
    {
        if (navMeshAgent.enabled)
        {
            Vector3 worldDeltaPosition = navMeshAgent.nextPosition - transform.position;

            // Map 'worldDeltaPosition' to local space
            float dx = Vector3.Dot (transform.right, worldDeltaPosition);
            float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
            Vector2 deltaPosition = new Vector2 (dx, dy);

            // Low-pass filter the deltaMove
            float smooth = Mathf.Min(1.0f, Time.deltaTime/0.15f);
            smoothDeltaPosition = Vector2.Lerp ( smoothDeltaPosition, deltaPosition, smooth );

            // Update velocity if time advances
            if ( Time.deltaTime > 1e-5f )
                velocity = smoothDeltaPosition / Time.deltaTime;

            bool shouldMove = velocity.magnitude > 0.1f && navMeshAgent.remainingDistance > navMeshAgent.radius;

            // Update animation parameters
            anim.SetBool ( "move", shouldMove );
            anim.SetFloat ( "velocity", velocity.magnitude);
            anim.SetFloat ( "velx", velocity.x );
            anim.SetFloat ( "vely", velocity.y );

            if ( worldDeltaPosition.magnitude > navMeshAgent.radius )
                transform.position = navMeshAgent.nextPosition - 0.95f * worldDeltaPosition;

            if ( navMeshAgent.remainingDistance == 0 && moveComplete != null)
                moveComplete ( );
        }
    }

    private void OnDrawGizmos ( )
    {
        Gizmos.DrawRay ( destination, 5 * Vector3.up );
    }

}
