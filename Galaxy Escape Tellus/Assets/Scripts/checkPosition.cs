using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPosition : MonoBehaviour
{
    public TrailRenderer tr;
    public float checkInterval = 1f; // How often to check for shapes (seconds)
    private float timeSinceLastCheck = 0f;
    public float tolerance = 1f; // tolerance for circle accuracy


    public Vector3[] positions;
    private float timeSinceLastCapture = 0f;
    // Start is called before the first frame update
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



    bool IsCircle(List<Vector3> points)
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

        return true;
    }
}
