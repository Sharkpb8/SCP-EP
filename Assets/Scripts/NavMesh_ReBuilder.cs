using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class NavMesh_ReBuilder : MonoBehaviour
{
    public  NavMeshSurface[] agent;

    public void RebuildMesh()
    {
        foreach (NavMeshSurface surface in agent)
        {
            surface.BuildNavMesh();
        }
    }
}
