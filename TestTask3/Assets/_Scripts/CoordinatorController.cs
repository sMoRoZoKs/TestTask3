using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatorController
{
    private Vector3 lastTapCoordinate = new Vector3();
    public void SetLastCoordinate(Vector3 coordinate)
    {
        lastTapCoordinate = coordinate;
    }
    public Vector3 LastTapCoordinate => lastTapCoordinate;
}
