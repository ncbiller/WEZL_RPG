using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    CameraRaycaster cr;
    // Use this for initialization
    void Start () {
        cr = FindObjectOfType<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update () {
        print(cr.layerHit);
	}
}
