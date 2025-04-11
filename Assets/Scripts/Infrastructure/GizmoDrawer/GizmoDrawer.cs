using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawer : MonoBehaviour
{
    [SerializeField] private GizmoType _gizmoType = GizmoType.SPHERE;
    [SerializeField] private float _gizmoRange = 5f;    
    
    [SerializeField] private Color _color;
    [SerializeField] private bool _draw = false;

    private void OnDrawGizmos()
    {
        if (!_draw)
            return;
        
        Gizmos.color = _color;
        DrawGizmo();
    }

    private void DrawGizmo()
    {
        switch (_gizmoType)
        {
            case GizmoType.SPHERE:
                Gizmos.DrawSphere(transform.position, _gizmoRange);
                break;
            
            case GizmoType.CUBE:
                Gizmos.DrawCube(transform.position, new Vector3(_gizmoRange, _gizmoRange, _gizmoRange));
                break;
            
            case GizmoType.WIRED_SPHERE:
                Gizmos.DrawWireSphere(transform.position, _gizmoRange);
                break;
                        
            case GizmoType.WIRED_CUBE:
                Gizmos.DrawWireCube(transform.position, new Vector3(_gizmoRange, _gizmoRange, _gizmoRange));
                break;
            
            case GizmoType.LINE:
                Gizmos.DrawRay(transform.position, transform.up.normalized * _gizmoRange);
                break;
        }
    }
}
