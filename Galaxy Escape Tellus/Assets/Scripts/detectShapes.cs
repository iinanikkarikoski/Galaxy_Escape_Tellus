using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectShapes : MonoBehaviour
{
    public TrailRenderer tr;
    public float checkInterval = 1f; // How often to check for shapes (seconds)
    private float timeSinceLastCheck = 0f;
    public float tolerance = 1f; // tolerance for circle accuracy
    public float minRadius = 10f;
    //public float angleTolerance = 5f;
    public float distanceTolerance = 1f;


    public Vector3[] positions;
    private float timeSinceLastCapture = 0f;
    // Start is called before the first frame update
    /*
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastCheck += Time.deltaTime;

        if (timeSinceLastCheck >= checkInterval && tr.positionCount > 10)
        {
            //Debug.Log(tr.positionCount);
            positions = new Vector3[tr.positionCount];

            //Debug.Log("checking shape...");
            tr.GetPositions(positions); //get trace positions
            if (IsCircle(new List<Vector3>(positions)))
            {
                Debug.Log("Circle shape detected!!!!!!!!!!--------");
            } else {
                //Debug.Log("not a circle");
            }
            
            timeSinceLastCheck = 0f;
        }
    }

*/

    public bool IsCircle(List<Vector3> points)
    {
        if (points.Count < 3)
            return false;

        // Calculate the centroid
        Vector3 centroid = Vector3.zero;
        foreach (var point in points)
        {
            centroid += point;
        }
        centroid /= points.Count;

        // Calculate average distance from centroid and standard deviation
        float averageDistance = 0;
        foreach (var point in points)
        {
            averageDistance += Vector3.Distance(point, centroid);
        }
        averageDistance /= points.Count;

        // Check if all points are within the tolerance range
        foreach (var point in points)
        {
            if (Mathf.Abs(Vector3.Distance(point, centroid) - averageDistance) > tolerance)
                return false;
        }
        // Ensure the radius is greater than the minimum allowed radius
        if (averageDistance < minRadius)
            return false;

        return true;
    }
/*
    public bool IsLine(List<Vector3> points)
    {
        if (points == null || points.Count < 3)
        {
            //Debug.LogWarning("Need at least three points to check linearity.");
            return false;
        }

        // Get the initial direction
        Vector3 initialDirection = (points[1] - points[0]).normalized;

        for (int i = 1; i < points.Count - 1; i++)
        {
            // Calculate the direction of the current segment
            Vector3 currentDirection = (points[i + 1] - points[i]).normalized;

            // Check the angle between the initial direction and the current direction
            float angle = Vector3.Angle(initialDirection, currentDirection);

            if (angle > angleTolerance)
            {
                return false; // Deviation exceeds tolerance
            }

            // Update the initial direction to the current one
            initialDirection = currentDirection;
        }

        return true; // All segments are within the angle tolerance
    }*/
    public bool IsLine(List<Vector3> points)
{
    if (points == null || points.Count < 2)
    {
        return false; // Need at least two points to define a line
    }

    // Vector from the first to the last point
    Vector3 lineDirection = (points[points.Count - 1] - points[0]).normalized;
    Vector3 startPoint = points[0];

    // Check each point's distance to the line
    for (int i = 1; i < points.Count - 1; i++) // Skip first and last points
    {
        Vector3 pointToStart = points[i] - startPoint;

        // Project the point-to-start vector onto the line direction
        Vector3 projection = Vector3.Dot(pointToStart, lineDirection) * lineDirection;

        // Calculate the shortest distance from the point to the line
        float distanceToLine = (pointToStart - projection).magnitude;

        // If the distance exceeds the tolerance, return false
        if (distanceToLine > distanceTolerance)
        {
            return false;
        }
    }

    return true; // All points are within the tolerance distance
}
}
