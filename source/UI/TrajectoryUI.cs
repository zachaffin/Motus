using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

// Predicts player trajectory by calculating acceleration/velocity/position at some small time step, many times over

public class TrajectoryUI : MonoBehaviour {
    private Rigidbody thisBody;

    private Vector3 gravitationalForce;

    private void Awake()
    {
        thisBody = gameObject.GetComponent<Rigidbody>();
        StartCoroutine("ShowTrajectory");
    }

    private Vector3 updateForce(Vector3 position)
    {
        foreach (GameObject blackHole in BlackHoleGun.blackHoles)
        {
            Vector3 diff = blackHole.transform.position - position;
            Vector3 dir = diff.normalized;

            float mass1 = thisBody.mass;
            float mass2 = blackHole.GetComponent<Rigidbody>().mass;
            gravitationalForce = dir * Mathf.Clamp(((mass1 * mass2) / diff.sqrMagnitude), 0, 10f);
            
        }

        return gravitationalForce;
    }

    IEnumerator ShowTrajectory()
    {
        while (true)
        {
            if (Player.begunGravity)
            {
                UpdateTrajectory(transform.position, GetComponent<Rigidbody>().velocity, updateForce(transform.position));
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void UpdateTrajectory(Vector3 initialPosition, Vector3 initialVelocity, Vector3 acceleration)
    {
        Profiler.BeginSample("Euler");
        int numSteps = 1000;
        float timeDelta = 0.005f;

        LineRenderer lineRenderer = transform.Find("Trajectory").GetComponent<LineRenderer>();
        lineRenderer.positionCount = numSteps;

        Vector3 position = initialPosition;
        Vector3 velocity = initialVelocity;
        for (int i = 0; i < numSteps; ++i)
        {
            lineRenderer.SetPosition(i, position);

            position += velocity * timeDelta + 0.5f * acceleration * timeDelta * timeDelta;
            velocity += acceleration * timeDelta;
            acceleration = updateForce(position) / thisBody.mass;
        }
        Profiler.EndSample();
    }
}
