using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoonRaccoon.Utils.DebugUtils
{
    public static class DebugUtils 
    {
        /// <summary>
        /// Takes the active camera and relevant layers and returns the projected position of the mouse on the ground
        /// </summary>
        /// <param name="cam"></param>
        /// <param name="layers"></param>
        /// <returns></returns>
        public static Vector3 GetMousePositionToGround(Camera cam, int layers)
        {
            Vector3 mousePosToGnd = Vector3.zero;

            Ray toGround = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit toGroundHitInfo;

            if (Physics.Raycast(toGround, out toGroundHitInfo, Mathf.Infinity, ~layers))
            {
                mousePosToGnd = toGroundHitInfo.point;

                return mousePosToGnd;
            }

            else return Input.mousePosition;
        }

        /// <summary>
        /// Takes the active camera and returns the projected position of the mouse on the ground for all layers
        /// </summary>
        /// <param name="cam"></param>
        /// <param name="layers"></param>
        /// <returns></returns>
        public static Vector3 GetMousePositionToGround(Camera cam)
        {
            Vector3 mousePosToGnd = Vector3.zero;

            Ray toGround = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit toGroundHitInfo;

            if (Physics.Raycast(toGround, out toGroundHitInfo, Mathf.Infinity))
            {
                mousePosToGnd = toGroundHitInfo.point;

                return mousePosToGnd;
            }

            else return Input.mousePosition;
        }
    }
}
