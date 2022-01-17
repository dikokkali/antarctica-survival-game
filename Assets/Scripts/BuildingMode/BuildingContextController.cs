using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoonRaccoon.Utils;

using GoonRaccoon.Utils.DebugUtils;
using GoonRaccoon.Utils.MouseUtils;

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

    [SerializeField] public Material buildingModeMaterial;

    [Header("Building Mode Options")]
    [SerializeField] public float structureRotationAngle;

    [SerializeField] public bool snapToGrid;
    [SerializeField] public Vector3 gridIncrements;

    // Private variables
    private bool attachToMouse = true;
    private Material originalMaterial = null;

    private void Awake()
    {
        _heldObject = Instantiate(placeableStructure, new Vector3(_mousePos.x, _mousePos.y, _mousePos.z), Quaternion.identity);

        originalMaterial = _heldObject.GetComponentInChildren<Renderer>().material;

        _heldObject.GetComponentInChildren<Renderer>().material = buildingModeMaterial;

    }

    private void Update()
    {
        _mousePos = Input.mousePosition;

        //GetPointedEntity(_mousePos);

        // Carry the structure at mouse pos
        // TODO: Change this to accept any structure
        if (attachToMouse && _heldObject != null)
        {
            _heldObject.transform.position =
                 MouseUtils.GetMousePositionToGround(_overheadCamera, LayerMask.NameToLayer(terrainLayer));
        }

        CheckAdjacentSnappingStructures();

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

    public bool IsStructurePlacementValid()
    {
        return true;
    }

    public void PlaceStructure(GameObject structure)
    {
        if (IsStructurePlacementValid())
        {
            if (_heldObject != null)
            {
                Instantiate(placeableStructure, _mousePos, _heldObject.transform.rotation).transform.position = 
                    MouseUtils.GetMousePositionToGround(_overheadCamera, LayerMask.NameToLayer(terrainLayer));                
            }
            else
            {
                DebugUtils.LogError("Object doesn't have the requested component.");
            }            
        }        
    }   


    public void CheckAdjacentSnappingStructures()
    {
        // TODO: Find method that relies on proximity/colliders
        Ray mouseOverRay = _overheadCamera.ScreenPointToRay(_mousePos);
        RaycastHit mouseHitInfo;

        if (Physics.Raycast(mouseOverRay, out mouseHitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer("SnapConnectors")))
        {
            // If we hit a snap point with the mouse and it isn't the current object
            if (mouseHitInfo.collider.GetComponent<SnapConnector>() != null && mouseHitInfo.transform.root != _heldObject.transform)
            {
                DebugUtils.Log("HIT OBJECT: " + mouseHitInfo.collider.GetComponent<SnapConnector>().name);

                attachToMouse = false;

                SnapConnector hitConnector = mouseHitInfo.collider.GetComponent<SnapConnector>();
                SnapConnector closestConnector = null;

                float closestDistance = Mathf.Infinity;

                // TODO: Extract into a function (utils?)
                // TODO: Different method: check connector orientations and choose the one with OPPOSITE of target
                // Find the closest snap point of the held object to the placed object
                foreach (SnapConnector connector in _heldObject.GetComponent<PlacedStructure>().snapConnectors)
                {
                    float checkedDistance = Vector3.Distance(connector.transform.position, hitConnector.transform.position);

                    if (checkedDistance < closestDistance)
                    {
                        closestDistance = checkedDistance;
                        closestConnector = connector;
                    }
                }

                // Orient the object
                float angleBetweenPivotAndConnector = Vector3.Angle(hitConnector.transform.forward, _heldObject.transform.forward);
                Vector3 anglePolarity = Vector3.Cross( _heldObject.transform.forward, -hitConnector.transform.forward);

                DebugUtils.Log("Angle: " + angleBetweenPivotAndConnector);
                DebugUtils.Log("Polarity: " + anglePolarity);

                // TODO: This method won't work for structures where the pivot/connectors aren't perp. or parallel!                
                if (anglePolarity.y > 0)
                {
                    _heldObject.transform.Rotate(_heldObject.transform.up, -angleBetweenPivotAndConnector);
                }
                else if (anglePolarity.y < 0)
                {
                    _heldObject.transform.Rotate(_heldObject.transform.up, angleBetweenPivotAndConnector);
                }
                // Offset the object
                Vector3 connectorOffset = hitConnector.transform.position - closestConnector.transform.position;

                _heldObject.transform.position += connectorOffset;
            }
        }
        else
        {
            attachToMouse = true;
        }
        
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
            DebugUtils.Log("Nothing detected at pos: " + _mousePos);
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
