using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GoonRaccoon.Utils.DebugUtils
{
    public static class DebugUtils
    {
        public enum LogLevel
        {
            Off,
            On,
            Verbose,
            GizmosOnly,
            MessagesOnly
        }

        public static LogLevel LoggingLevel { get; set; } = LogLevel.On;

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

        #region Debug Messages
        public static void Log(object obj)
        {
            if (LoggingLevel == LogLevel.Off) return;

            if (obj is ICollection)
            {
                LogObjectCollection(obj as ICollection);
            }
            else Debug.Log(obj);
        }

        public static void LogWarning(object obj)
        {
            if (LoggingLevel == LogLevel.Off) return;

            if (obj is ICollection)
            {
                LogObjectCollection(obj as ICollection);
            }
            else Debug.LogWarning(obj);
        }

        public static void LogError(object obj)
        {
            if (LoggingLevel == LogLevel.Off) return;

            if (obj is ICollection)
            {
                LogObjectCollection(obj as ICollection);
            }
            else Debug.LogError(obj);
        }
        public static void LogObjectCollection(ICollection collection)
        {
            if (LoggingLevel == LogLevel.Off) return;

            if (collection.Count > 0)
            {
                foreach (var item in collection)
                {
                    Debug.Log(item);
                }
            }
            else if (collection.Count == 0)
            {
                Debug.Log(collection);
            }
            else Debug.LogWarning("DebugUtils: The collection you are trying to iterate has a negative index.");
        }
        #endregion
    }
}
