using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controls "Moves" UI element

public class ManeuversText : MonoBehaviour {
    private Text textRef;

    private void Awake () {
        textRef = GetComponentInChildren<Text>();

        Player.OnFireJetPack += updateMovesCount;
    }

    private void updateMovesCount() {
        textRef.text = "Moves: " + LevelManager.Instance.MovesMade;
	}

    private void OnDestroy()
    {
        Player.OnFireJetPack -= updateMovesCount;
    }
}
