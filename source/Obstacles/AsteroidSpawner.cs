using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Spawns asteroids or other debris
 * according to a given inital position and velocity
 */

public class AsteroidSpawner : MonoBehaviour {
    public float spawnFrequency;

    public float initialSpeed;
    public Vector3 initialDirection;

    public GameObject asteroid;

    private void Awake()
    {
        StartCoroutine("SpawnAsteroids");
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            asteroid = Instantiate(asteroid, transform.position, Quaternion.identity, this.transform);
            asteroid.GetComponent<Rigidbody>().velocity = initialSpeed * initialDirection;

            yield return new WaitForSeconds(1 / spawnFrequency);
        }
    }
}
