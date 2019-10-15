using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Keeps the camera focused on the player

public class CamaraPan : MonoBehaviour {

    public Player player;
    private Vector3 playerPos;
    private Vector3 cameraPos;
    private GameObject backGround;

    private void Awake()
    {
        playerPos = player.transform.position;
        cameraPos = transform.position;
        backGround = GameObject.Find("BackGround");
    }

    void Update ()
    {
        if (player == null)
        {
            Destroy(this);
        }
        else
        {
            playerPos = player.transform.position;

            if (playerPos.x > 7)
            {
                cameraPos = new Vector3(playerPos.x - 7, cameraPos.y, -10);
            }
            if (playerPos.x < -7)
            {
                cameraPos = new Vector3(playerPos.x + 7, cameraPos.y, -10);
            }
            if (playerPos.y > 4)
            {
                cameraPos = new Vector3(cameraPos.x, playerPos.y - 4, -10);
            }
            if (playerPos.y < -4)
            {
                cameraPos = new Vector3(cameraPos.x, playerPos.y + 4, -10);
            }

            transform.position = cameraPos;
            backGround.transform.position = new Vector3(cameraPos.x, cameraPos.y, 0);
        }
	}
}
