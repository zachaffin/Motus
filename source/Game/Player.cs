using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player controls

public class Player : MonoBehaviour
{
    #region fields
    private Vector3 mousePosWorld;

    private LineRenderer jetPackLine;
    private bool mousedOn = false;
    public static bool begunGravity = false;

    private ForceGravity forceGravity = null;

    [SerializeField]
    private Material lineMaterial;

    #endregion

    public static event System.Action<Vector3> OnCreateBlackHole;
    public static event System.Action OnFireJetPack;

    private void Awake()
    {
        jetPackLine = transform.GetChild(0).gameObject.GetComponent<LineRenderer>();
        jetPackLine.material = lineMaterial;
    }

    void Update()
    {
        //Keep player facing forward
        if (JetPack.playerBody.velocity.magnitude != 0f){
		transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(-JetPack.playerBody.velocity + Vector3.up + Vector3.forward),
            Time.deltaTime
        );
		}
	
        mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition); mousePosWorld.z = -1;

        mousedOn = ((mousePosWorld - transform.position).sqrMagnitude < 1);

        if (Input.GetMouseButton(0))
        {
            if (mousedOn)
            {
                jetPackLine.gameObject.SetActive(true);
            }
            jetPackLine.SetPosition(0, mousePosWorld);
            jetPackLine.SetPosition(1, transform.position);
        }

        if (Input.GetMouseButtonUp(0) && jetPackLine.gameObject.activeSelf)
        {
            jetPackLine.gameObject.SetActive(false);

            if(OnFireJetPack != null)
            {
                OnFireJetPack();
            }
            mousedOn = false;
            begunGravity = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if(OnCreateBlackHole != null)
            {
                OnCreateBlackHole(mousePosWorld);
            }

            begunGravity = true;
        }

        if (begunGravity && forceGravity == null)
        {
            forceGravity = gameObject.AddComponent<ForceGravity>();
        }

        if (Input.GetButton("ScrollFast"))
        {
            Camera.main.orthographicSize += -3 * Input.GetAxis("Mouse ScrollWheel");
        }
        else
        {
            Camera.main.orthographicSize += -Input.GetAxis("Mouse ScrollWheel");
        }

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 3F, 8F);
    }
}
