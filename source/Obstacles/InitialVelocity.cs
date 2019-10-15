using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to an object to provide an initial velocity

public class InitialVelocity : MonoBehaviour {

    [SerializeField]private Vector3 initialVelocity;

    private Rigidbody thisBody;

	void Start () {
        thisBody = GetComponent<Rigidbody>();
        thisBody.velocity = initialVelocity;
	}
}
