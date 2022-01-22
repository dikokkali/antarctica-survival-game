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
    private Vector3 snapPosition = Vector3.zero;
    private Material originalMaterial = null;

    private void Awake()
    {
        _heldObject = Instantiate(placeableStructure, new Vector3(_mousePos.x, _mousePos.y, _mousePos.z), placeableStructure.transform.rotation);

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

            snapPosition = MouseUtils.GetMousePositionToGround(_overheadCamera, LayerMask.NameToLayer(terrainLayer));
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
                PlaceStructure(_heldObject, snapPosition);
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

    public void PlaceStructure(GameObject structure, Vector3 pos)
    {
        if (IsStructurePlacementValid())
        {
            if (_heldObject != null)
            {
                Instantiate(placeableStructure, _mousePos, _heldObject.transform.rotation)
                    .transform.position = snapPosition;
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
            // If we hit a snap point with the mouse and it isn't the current object's snap transform
            if (mouseHitInfo.collider.GetComponent<SnapConnector>() != null && mouseHitInfo.transform.root != _heldObject.transform)
            {

                DebugUtils.Log("HIT OBJECT: " + mouseHitInfo.collider.GetComponent<SnapConnector>().name);

                SnapConnector hitConnector = mouseHitInfo.collider.GetComponent<SnapConnector>();
                SnapConnector closestConnector = null;

                // Find the held connector with opposite direction vector
                foreach (var connector in _heldObject.GetComponent<PlacedStructure>().snapConnectors)
                {
                    if (Mathf.Approximately(Vector3.Angle(connector.transform.forward, hitConnector.transform.forward), 180f))
                    {
                        DebugUtils.Log("FOUND" + connector.transform.name);
                        closestConnector = connector;
                    }
                }

                if (closestConnector != null)
                {
                    attachToMouse = false;

                    Vector3 connectorOffset = hitConnector.transform.position - closestConnector.transform.position;

                    // Offset the structure and update the correct snapPosition
                    _heldObject.transform.position += connectorOffset;
                    snapPosition = _heldObject.transform.position;
                }
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
                Ray mouseOverRay = _overheadCamera.ScreenPointToRay(_mousePos);
                RaycastHit mouseHitInfo;

                if (Physics.Raycast(mouseOverRay, out mouseHitInfo, Mathf.Infinity, LayerMask.NameToLayer(validBuildingContextLayers)))
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

