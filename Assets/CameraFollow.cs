using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        print(player.ToString());
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float x = player.transform.position.x;
        float z = player.transform.position.y;
        print(x);

        transform.position = player.transform.position;
    }

    
}
