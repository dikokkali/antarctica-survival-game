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
