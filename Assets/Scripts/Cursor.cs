using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    CameraRaycaster cameraRaycaster;
    // Use this for initialization
    void Start () {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
    }
	
	// Update is called once per frame
	void Update () {
       // print(cameraRaycaster.layerHit);
	}
}
