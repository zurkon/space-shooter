using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> pathChilds;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Main Camera view area
        Gizmos.DrawLine(new Vector3(2.8f, 5, 0), new Vector3(-2.8f, 5, 0));
        Gizmos.DrawLine(new Vector3(-2.8f, 5, 0), new Vector3(-2.8f, -5, 0));
        Gizmos.DrawLine(new Vector3(-2.8f, -5, 0), new Vector3(2.8f, -5, 0));
        Gizmos.DrawLine(new Vector3(2.8f, -5, 0), new Vector3(2.8f, 5, 0));

        Gizmos.color = Color.red;

        Vector3 newPosition;

        // Draw Line between points with Bezier Curve
        for (float progress = 0f; progress <= 1; progress += 0.03f)
        {
            if (pathChilds.Count == 3)
            {
                newPosition = QuadBezier(progress);
            }
            else
            {
                newPosition = LinearBezier(progress);
            }

            Gizmos.DrawSphere(newPosition, 0.1f);

        }
    }

    private Vector3 LinearBezier(float progress)
    {
        Vector3 nextPosition = Vector3.Lerp(pathChilds[0].transform.position, pathChilds[1].transform.position, progress);
        return nextPosition;
    }

    private Vector3 QuadBezier(float progress)
    {
        Vector3 pathAtoB = Vector3.Lerp(pathChilds[0].transform.position, pathChilds[1].transform.position, progress);
        Vector3 pathBtoC = Vector3.Lerp(pathChilds[1].transform.position, pathChilds[2].transform.position, progress);
        Vector3 nextPosition = Vector3.Lerp(pathAtoB, pathBtoC, progress);
        return nextPosition;
    }
}
