using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float ClickToMoveRadius = 0.2f;

    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
    Transform m_Cam;
    Vector3 m_CamForward;
    Vector3 m_Move;

    bool isInDirectMode = false; 
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Cam = Camera.main.transform;
        //cameraRaycaster = FindObjectOfType<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G)) // TODO allow player to map later or add to menu.
        {
            isInDirectMode = !isInDirectMode;
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

        m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
        m_Move = v * m_CamForward + h * m_Cam.right;

        m_Character.Move(m_Move, false, false);
    }

    private void ProcessMouseMovement()
    {
        if (Input.GetMouseButton(0))
        {   
            print("Cursor raycast hit" + cameraRaycaster.hit.collider.gameObject.name.ToString());

            switch (cameraRaycaster.layerHit)
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

        m_Character.Move(currentClickTarget - transform.position, false, false);
    }
}

