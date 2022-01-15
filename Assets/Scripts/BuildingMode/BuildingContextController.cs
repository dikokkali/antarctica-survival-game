using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingContextController : MonoBehaviour
{
    public GameObject placeableStructure; // TODO: Change to abstract object

    public Camera _overheadCamera;

    public string validBuildingContextLayers = "Everything"; // TODO: Change to appropriate layers
    public string terrainLayer = "Terrain";

    // Read-only information, do not modify!
    [Header("Debug Configuration")]
    [SerializeField] public Vector3 _mousePos;
    [SerializeField] public GameObject _heldObject;
    [SerializeField] public GameObject _pointedObject;
    [SerializeField] public GameObject _selectedObject;

    private void Awake()
    {
        _heldObject = Instantiate(placeableStructure, _mousePos, Quaternion.identity);
    }

    private void Update()
    {
        // Update the mouse position at runtime
        _mousePos = Input.mousePosition;

        GetPointedEntity(_mousePos);

        // Carry the structure at mouse pos
        if (_heldObject != null)
        {    
            _heldObject.transform.position = GetMousePositionToGround();
        }

        // Input detection
        if (Input.GetButtonDown("Fire1"))
        {
            if (placeableStructure == null)
            {
                SelectPointedEntity(_pointedObject);
            }
            else
            {
                PlaceStructure(_heldObject);
            }
        }


    }

    #region Structure Placement

    public void PlaceStructure(GameObject structure)
    {
        if (IsStructurePlacementLegal())
        {
            if (_heldObject != null)
            {
                Instantiate(placeableStructure, _mousePos, Quaternion.identity).transform.position = GetMousePositionToGround();
                //_heldObject = null;
            }
            else
            {
                Debug.LogError("Object doesn't have the requested component.");
            }            
        }
        else
        {
            Debug.LogWarning("Invalid placement");
        }
    }

    public Vector3 GetMousePositionToGround()
    {
        Vector3 mousePosToGnd = Vector3.zero;

        Ray toGround = _overheadCamera.ScreenPointToRay(_mousePos);
        RaycastHit toGroundHitInfo;

        if (Physics.Raycast(toGround, out toGroundHitInfo, Mathf.Infinity, ~LayerMask.NameToLayer(terrainLayer)))
        {
            mousePosToGnd = toGroundHitInfo.point;

            return mousePosToGnd;
        }

        else return _mousePos;
    }

    public bool IsStructurePlacementLegal()
    {
        return true;
    }

    public void CheckAdjacentSnappingStructures()
    {

    }

    #endregion

    #region Placement Information
    public void GetPointedEntity(Vector3 mousePos, bool buildableOnly = false)
    {
        if (!buildableOnly)
        {
            Ray mouseOverRay =_overheadCamera.ScreenPointToRay(_mousePos);
            RaycastHit mouseHitInfo;

            if (Physics.Raycast(mouseOverRay,out mouseHitInfo, Mathf.Infinity, LayerMask.NameToLayer(validBuildingContextLayers)))
            {
                // If the object is composite, always get the parent
                _pointedObject = mouseHitInfo.collider.gameObject;

                if (_pointedObject.transform.parent != null)
                {
                    _pointedObject = _pointedObject.transform.parent.gameObject;
                }
            }
            else
            {
                _pointedObject = null;
            }
        }
    }

    public void SelectPointedEntity(GameObject entity)
    {
        if (entity == null)
        {
            Debug.Log("Nothing detected at pos: " + _mousePos);
            _selectedObject = null;

            return;
        }
        else
        {
            _selectedObject = entity;
        }
    }
    #endregion

}
