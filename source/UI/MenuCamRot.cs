using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotates main menu camera

public class MenuCamRot : MonoBehaviour {

	private void Update () {
        Camera.main.transform.Rotate(Vector3.up * 0.75f * Time.deltaTime);
	}
}
