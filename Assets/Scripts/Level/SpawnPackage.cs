using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/SpawnPackage", order = 1)]
public class SpawnPackage : ScriptableObject
{
    public EnemyType enemyType;
    //GameObject enemyResource;
    public float timeSpacing;
    public int numberToSpawn;
    public GameObject pathObject;

    public List<Vector2> GetPath()
    {
        List<Vector2> path = new List<Vector2>();
        foreach(Transform t in pathObject.transform)
        {
            path.Add(t.position);
        }
        return path;
    }

    public override string ToString()
    {
        return "EnemyType: " + enemyType + ", timespacing: " + timeSpacing + ", numToSpawn: " + numberToSpawn;
    }
}
