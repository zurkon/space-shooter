using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private WaveConfig waveConfig;
    private List<Transform> waypoints;
    private float moveSpeed;

    private float progress = 0f;
    private float movementPerFrame = 0f;

    // Called when the object becomes enabled and active.
    void OnEnable()
    {
        // Every Time this object gets Active again, we need to reset progress value
        progress = 0f;

        if( waveConfig )
        {
            // Get waypoint positions
            waypoints = waveConfig.GetWaypoints();

            // Set Enemy moveSpeed
            moveSpeed = waveConfig.moveSpeed;

            // Set Enemy initial position
            transform.position = waypoints[0].transform.position;

            // Get distance between Enemy inital position to final waypoint
            float distance = Vector3.Distance(transform.position, waypoints[waypoints.Count - 1].transform.position);

            // Set the movement of this enemy to final waypoint per frame
            movementPerFrame = moveSpeed / distance;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig newConfig)
    {
        waveConfig = newConfig;
    }

    private void Move()
    {
        progress += Time.deltaTime * movementPerFrame;

        Vector3 newPosition;

        if (waypoints.Count == 3)
        {
            newPosition = QuadBezier();
        } else
        {
            newPosition = LinearBezier();
        }

        transform.position = newPosition;

        if (progress >= 1f)
        {
            gameObject.SetActive(false);
        }

    }

    private Vector3 LinearBezier()
    {
        Vector3 nextPosition = Vector3.Lerp(waypoints[0].transform.position, waypoints[1].transform.position, progress);
        return nextPosition;
    }

    private Vector3 QuadBezier()
    {
        Vector3 pathAtoB = Vector3.Lerp(waypoints[0].transform.position, waypoints[1].transform.position, progress);
        Vector3 pathBtoC = Vector3.Lerp(waypoints[1].transform.position, waypoints[2].transform.position, progress);
        Vector3 nextPosition = Vector3.Lerp(pathAtoB, pathBtoC, progress);
        return nextPosition;
    }

    /*
    private Vector3 CubicBezier()
    {
        Vector3 pathAtoB = Vector3.Lerp(waypoints[0].transform.position, waypoints[1].transform.position, progress);
        Vector3 pathBtoC = Vector3.Lerp(waypoints[1].transform.position, waypoints[2].transform.position, progress);
        Vector3 pathCtoD = Vector3.Lerp(waypoints[2].transform.position, waypoints[3].transform.position, progress);

        Vector3 pathABC = Vector3.Lerp(pathAtoB, pathBtoC, progress);
        Vector3 pathBCD = Vector3.Lerp(pathBtoC, pathCtoD, progress);

        Vector3 newPosition = Vector3.Lerp(pathABC, pathBCD, progress);

        return newPosition;
    }
    */

    #region Old Move Method region
    /*
    private void Move()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].transform.position;
            float movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    */
    #endregion
}
