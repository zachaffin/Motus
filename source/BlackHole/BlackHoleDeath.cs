using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Defines black holes' reactions with other objects
 * Absorbs asteroids or other black hole's mass, or kills the player
 */
public class BlackHoleDeath : MonoBehaviour
{
    private bool isDestroyed = false;

    private void OnTriggerEnter(Collider col)
    {
        float m1 = gameObject.GetComponent<Rigidbody>().mass, m2 = col.GetComponent<Rigidbody>().mass;
        Vector3 v1 = gameObject.GetComponent<Rigidbody>().velocity, v2 = col.GetComponent<Rigidbody>().velocity;

        switch (col.gameObject.tag){
            case "BlackHole":
                if (!isDestroyed)
                {
                    BlackHoleGun.blackHoles.Remove(col.gameObject);
                    gameObject.transform.localScale += col.transform.localScale;
                    gameObject.GetComponent<Light>().range += col.GetComponent<Light>().range;
                    gameObject.transform.position = (gameObject.transform.position + col.transform.position) / 2;

                    gameObject.GetComponent<Rigidbody>().velocity = ((m1 * v1) + (m2 * v2)) / (m1 + m2);
                    gameObject.GetComponent<Rigidbody>().mass += m2;
                    col.GetComponent<BlackHoleDeath>().isDestroyed = true;
                    Destroy(col.gameObject);
                }
                break;
            case "Asteroid":
                gameObject.GetComponent<Rigidbody>().velocity = ((m1 * v1) + (m2 * v2)) / (m1 + m2);
                gameObject.GetComponent<Rigidbody>().mass += m2;
                Destroy(col.gameObject);
                break;
            case "Player":
                Destroy(col.gameObject);
                break;
            default:
                break;
        }
    }
}