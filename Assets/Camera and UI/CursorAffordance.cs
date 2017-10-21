﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour {

    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D attackCursor = null;
    [SerializeField] Texture2D errorCursor = null;

    [SerializeField] Vector2 cursorOffset = new Vector2(0, 0);

    Texture2D cursorTexture;

    CameraRaycaster cameraRaycaster;
    // Use this for initialization
    void Start () {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        switch(cameraRaycaster.currentLayerHit)
        {
            case Layer.Walkable:
                cursorTexture = walkCursor;
                break;
            case Layer.Enemy:

                cursorTexture = attackCursor;
                break;

            case Layer.RaycastEndStop:

                cursorTexture = errorCursor;
                break;


            default:
                cursorTexture = errorCursor;
                return;
        }

        Cursor.SetCursor(cursorTexture, cursorOffset, CursorMode.Auto);
        print(cameraRaycaster.currentLayerHit);
       
	}
}
