using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

//Calculates sum of forces on this object from black hole(s)

public class ForceGravity : MonoBehaviour
{
    private Rigidbody thisBody;

    private Vector3 gravitationalForce;

    private void Awake()
    {
        thisBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate () {

        foreach (GameObject blackHole in BlackHoleGun.blackHoles)
        {
            Vector3 diff = blackHole.transform.position - gameObject.transform.position;
            Vector3 dir = diff.normalized;

            float mass1 = thisBody.mass;
            float mass2 = blackHole.GetComponent<Rigidbody>().mass;
            gravitationalForce = dir * Mathf.Clamp(((mass1 * mass2) / diff.sqrMagnitude), 0, 12f);

            thisBody.AddForce(gravitationalForce);
        }
    }
}
