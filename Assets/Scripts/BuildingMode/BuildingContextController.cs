using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoonRaccoon.Utils;
using GoonRaccoon.Utils.DebugUtils;

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

    [Header("Building Mode Options")]
    [SerializeField] public float structureRotationAngle;

    private void Awake()
    {
        _heldObject = Instantiate(placeableStructure, _mousePos, Quaternion.identity);
    }

    private void Update()
    {
        _mousePos = Input.mousePosition;

        GetPointedEntity(_mousePos);

        // Carry the structure at mouse pos
        // TODO: Change this to accept any structure
        if (_heldObject != null)
        {    
            _heldObject.transform.position = 
                DebugUtils.GetMousePositionToGround(_overheadCamera, LayerMask.NameToLayer(terrainLayer));
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            _heldObject.transform.Rotate(_heldObject.transform.up, structureRotationAngle);
        }
    }

    #region Structure Placement

    public void PlaceStructure(GameObject structure)
    {
        if (IsStructurePlacementValid())
        {
            if (_heldObject != null)
            {
                Instantiate(placeableStructure, _mousePos, _heldObject.transform.rotation).transform.position = 
                    DebugUtils.GetMousePositionToGround(_overheadCamera, LayerMask.NameToLayer(terrainLayer));                
            }
            else
            {
                Debug.LogError("Object doesn't have the requested component.");
            }            
        }        
    }    

    public bool IsStructurePlacementValid()
    {       

        // Check for invalid overlapping geometry
        var colliderArray = Physics.OverlapBox(_heldObject.transform.position, _heldObject.transform.localScale / 2, Quaternion.identity, LayerMask.NameToLayer(terrainLayer));

        DebugUtils.LogObjectCollection(colliderArray);
        
        if (colliderArray.Length > 0)
        {
            DebugUtils.Log("Invalid placement");
            return false;
        }
        else
        {
            return true;
        }
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
