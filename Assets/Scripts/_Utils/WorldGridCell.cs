using System.Collections.Generic;
using UnityEngine;

#nullable enable
public class WorldGridCell
{
    public int Size { get; set; }
    public bool IsBuildable { get; set; }
    public IPlaceableEntity? CellEntities { get; set; }
    public Vector3 CellPosition { get; set; }

    public WorldGridCell(int size, Vector3 pos)
    {
        Size = size;
        CellPosition = pos;
    }
    
}
#nullable disable

