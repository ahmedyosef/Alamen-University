using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CalculatePath : MonoBehaviour
{

    public Transform destinationObject;
    [SerializeField]
    private LineRenderer lineRenderer;
    NavMeshAgent meshAgent;
    NavMeshPath meshPath;

    // Define an offset value
    public Vector3 positionOffset = new Vector3(0, 1, 0); // Example: raise the path by 1 unit on the Y-axis

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        meshPath = new NavMeshPath();
    }

    void Update()
    {
        if (meshPath != null)
            meshPath.ClearCorners();

        meshAgent.CalculatePath(destinationObject.transform.position, meshPath);

        // Create a new array to hold the modified corners
        Vector3[] modifiedCorners = new Vector3[meshPath.corners.Length];

        // Apply the offset to each corner
        for (int i = 0; i < meshPath.corners.Length; i++)
        {
            modifiedCorners[i] = meshPath.corners[i] + positionOffset;
        }

        lineRenderer.positionCount = modifiedCorners.Length;
        lineRenderer.SetPositions(modifiedCorners);
    }
}
