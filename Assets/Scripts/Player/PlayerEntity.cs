using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEntity : MonoBehaviour
{ 
    public PlayerInventory playerInventory;
    public PlayerInputModule playerInputModule;
    public Camera fpsCamera;

    private void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerInputModule = GetComponent<PlayerInputModule>(); 
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    void Interact()
    {
        Ray interactRay = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward);
        RaycastHit rHit;

        if (Physics.Raycast(interactRay,out rHit, 2f))
        {
            if (rHit.collider.gameObject.GetComponent<IInteractable>() != null)
            {
                rHit.collider.gameObject.GetComponent<IInteractable>().Interact();
            }
        }
    }

    #region Player Config

    void SetupPlayer()
    {

    }

    #endregion
}
