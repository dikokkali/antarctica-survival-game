using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEntity : MonoBehaviour
{ 
    private PlayerInputModule playerInputModule;
    private EntityStatus playerStatus;

    [HideInInspector] public PlayerInventory playerInventory;

    [SerializeField] private Camera fpsCamera;

    private void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerInputModule = GetComponent<PlayerInputModule>();
        playerStatus = GetComponent<EntityStatus>();
        
        if (fpsCamera == null)
        {
            Debug.LogWarning("Player camera has not been assigned");
        }
    }  

    #region Environment Interactions

    public void Interact()
    {
        Debug.Log("Interacting");

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

    #endregion
}
