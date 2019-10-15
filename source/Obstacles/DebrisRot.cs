using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Provides a random initial angular velocity
 * with a given magnitude
 */

public class DebrisRot : MonoBehaviour {

    public float magnitude;

    private Rigidbody debrisBody;

    private void Awake()
    {
        debrisBody = GetComponent<Rigidbody>();
        debrisBody.angularVelocity = Random.insideUnitSphere * magnitude;
    }
}
