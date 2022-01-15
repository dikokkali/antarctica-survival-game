using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugInfoOverlayController : MonoBehaviour
{
    public BuildingContextController _bccRef;

    public Text MousePosText;
    public Text SelectedObjText;
    public Text PointedObjText;

    private string mptString;
    private string sotString;
    private string potString;

    private void Update()
    {
        mptString = $"Mouse Pos: {_bccRef._mousePos}";
        sotString = $"Selected Obj: <color=#0F66F7>{_bccRef._selectedObject}</color>";
        potString = $"Pointed Obj: {_bccRef._pointedObject}";

        MousePosText.text = mptString;
        SelectedObjText.text = sotString;
        PointedObjText.text = potString;
    }
}
