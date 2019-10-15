using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The player's black hole device
 * Creates, grows, and keeps track of black holes
 */

public class BlackHoleGun : MonoBehaviour
{
    [SerializeField]
    private GameObject blackHolePrefab;

    private GameObject newBlackHole;
    private Light newBlackHoleHalo;
    private Rigidbody newBlackHoleBody;

    public static List<GameObject> blackHoles;

    public float growRate = 0.05f;

    private void Awake()
    {
        Player.OnCreateBlackHole += CreateBlackHole;
        blackHoles = new List<GameObject>();
        blackHoles.AddRange(GameObject.FindGameObjectsWithTag("BlackHole"));
    }

    private void CreateBlackHole(Vector3 blackHolePos)
    {
        newBlackHole = Instantiate(blackHolePrefab, blackHolePos, Quaternion.identity);
        newBlackHoleHalo = newBlackHole.GetComponent<Light>();
        newBlackHoleBody = newBlackHole.GetComponent<Rigidbody>();

        blackHoles.Add(newBlackHole);

        StartCoroutine("GrowBlackHole");
    }

    IEnumerator GrowBlackHole()
    {
        
        while (!Input.GetMouseButtonUp(1))
        {
            newBlackHole.transform.localScale += new Vector3(growRate, growRate, growRate);
            newBlackHoleHalo.range += growRate * 1.25f;
            newBlackHoleBody.mass += growRate * 30;
            yield return null;
        }
    }

    private void OnDestroy()
    {
        Player.OnCreateBlackHole -= CreateBlackHole;
    }
}