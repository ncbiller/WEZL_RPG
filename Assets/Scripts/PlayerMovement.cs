using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
    [SerializeField] float ClickToMoveRadius = 0.2f;
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        //cameraRaycaster = FindObjectOfType<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            print("Cursor raycast hit" + cameraRaycaster.hit.collider.gameObject.name.ToString());

            if (cameraRaycaster.layerHit == Layer.Walkable)
                currentClickTarget = cameraRaycaster.hit.point;  // So not set in default case
        }

        if ((currentClickTarget - transform.position).magnitude < ClickToMoveRadius)
            currentClickTarget = transform.position;

        m_Character.Move(currentClickTarget - transform.position, false, false);
    }
}

