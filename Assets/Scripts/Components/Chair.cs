using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public void NeedsPullingBack()
    {
        if ( Physics.Raycast ( transform.position + Vector3.up, 0.8f * transform.up ) )
        {
            transform.position -= 0.2f * transform.up;
        }
    }

    private void OnDrawGizmosSelected ( )
    {
        Gizmos.DrawRay ( transform.position + Vector3.up, 0.8f*transform.up );
    }
}
