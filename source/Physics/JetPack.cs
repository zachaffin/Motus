using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Calculates and applies Jetpack's impulse on player

public class JetPack : MonoBehaviour {

    private Vector3 jetPackForce;
    public static Rigidbody playerBody;

    private void Awake()
    {
        Player.OnFireJetPack += FireJetPack;

        playerBody = GetComponent<Rigidbody>();
    }

    private void FireJetPack()
    {
        playerBody.AddForce(UpdateJetPackForce(), ForceMode.Impulse);
    }

    private Vector3 UpdateJetPackForce()
    {
        Vector3 mousePositionPixel = Input.mousePosition;
        Vector3 playerPositionPixel = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 diff = playerPositionPixel - mousePositionPixel; diff.z = 0;
        Vector3 direction = diff.normalized;
        float magnitude = Mathf.Clamp(diff.magnitude / 80, 0.01f, 2f);

        jetPackForce = magnitude * direction;
        return jetPackForce;
    }

    private void OnDestroy()
    {
        Player.OnFireJetPack -= FireJetPack;
    }
}
