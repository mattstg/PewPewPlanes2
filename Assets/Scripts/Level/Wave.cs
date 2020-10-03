using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave 
{
    public float timeToActivate;
    public SpawnPackage spawnPkg;

    public override string ToString()
    {
        return "Wave, TimeToActivate: " + timeToActivate + ", SpwnPkg: " + spawnPkg;
    }
}
