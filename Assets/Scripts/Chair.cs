using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public void NeedsPullingBack()
    {
        Debug.Log(Physics.Raycast ( transform.position + Vector3.up, 5 * transform.up ));
        if ( Physics.Raycast ( transform.position + Vector3.up, 5 * transform.up ) )
        {
            transform.position -= 0.2f * transform.up;
        }
    }

    private void OnDrawGizmosSelected ( )
    {
        Gizmos.DrawRay ( transform.position + Vector3.up, 5 * transform.up );
    }
}
