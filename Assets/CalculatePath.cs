using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CalculatePath : MonoBehaviour
{
    [SerializeField]
    private Transform destinationObject;
    [SerializeField]
    private LineRenderer lineRenderer;
    NavMeshAgent meshAgent;
    NavMeshPath meshPath; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        meshPath = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (meshPath != null)
            meshPath.ClearCorners();

        meshAgent.CalculatePath(destinationObject.transform.position,meshPath);

        lineRenderer.positionCount = meshPath.corners.Length;
        lineRenderer.SetPositions(meshPath.corners);
    }
}
