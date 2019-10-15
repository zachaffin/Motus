using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys object which go too far from the level area

public class DestroyOnLeave : MonoBehaviour {

    private void Awake()
    {
        StartCoroutine(CheckInBounds());
    }

    IEnumerator CheckInBounds()
    {
        while (true)
        {
            if (transform.position.sqrMagnitude > 100)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(3);
        }
    }
}
