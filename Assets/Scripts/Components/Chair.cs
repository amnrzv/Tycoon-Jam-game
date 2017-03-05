using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    Vector3 startPos;

    public void NeedsPullingBack()
    {
        startPos = transform.position;
        if ( Physics.Raycast ( transform.position + Vector3.up, 0.8f * transform.up ) )
        {
            transform.position -= 0.2f * transform.up;
        }
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }

    private void OnDrawGizmosSelected ( )
    {
        Gizmos.DrawRay ( transform.position + Vector3.up, 0.8f*transform.up );
    }
}
