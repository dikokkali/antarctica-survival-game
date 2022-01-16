using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapConnector : MonoBehaviour
{
    private Collider _collider;

    public PlacedStructure parentStructure;
    public PlacedStructure connectedStructure;

    private void Awake()
    {
        // Get the structure parent
        parentStructure = GetComponentInParent<PlacedStructure>();
    }
}
