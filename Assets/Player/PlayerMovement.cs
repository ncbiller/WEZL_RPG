using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float ClickToMoveRadius = 0.2f;

    ThirdPersonCharacter thirdPersonCharacter;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
    Transform cameraTransform;
    Vector3 cameraForward;
    Vector3 movement;

    bool isInDirectMode = false; 
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        cameraTransform = Camera.main.transform;
        //cameraRaycaster = FindObjectOfType<CameraRaycaster>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G)) // TODO allow player to map later or add to menu.
        {
            isInDirectMode = !isInDirectMode;
            currentClickTarget = transform.position; // reset target for click to move
        }

        if (isInDirectMode)
        {
            ProcessDirectMovement(); 
        }
        else
        {
            ProcessMouseMovement();
        }
    }

    private void ProcessDirectMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        movement = v * cameraForward + h * cameraTransform.right;

        thirdPersonCharacter.Move(movement, false, false);
    }

    private void ProcessMouseMovement()
    {
        if (Input.GetMouseButton(0))
        {   
            print("Cursor raycast hit" + cameraRaycaster.hit.collider.gameObject.name.ToString());

            switch (cameraRaycaster.currentLayerHit)
            {
                case Layer.Walkable:
                    currentClickTarget = cameraRaycaster.hit.point;
                    break;
                case Layer.Enemy:
                    print("Not Moving to enemy");
                    break;
                default:
                    print("I can't move here!!!");
                    return;
            }


        }

        if ((currentClickTarget - transform.position).magnitude < ClickToMoveRadius)
            currentClickTarget = transform.position;

        thirdPersonCharacter.Move(currentClickTarget - transform.position, false, false);
    }
}

