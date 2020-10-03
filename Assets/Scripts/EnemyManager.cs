using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Dictionary<EnemyType, GameObject> prefabDict;

    public void Awake()
    {
        prefabDict = new Dictionary<EnemyType, GameObject>();
        prefabDict.Add(EnemyType.BomberPlane, Resources.Load<GameObject>("Prefabs/Bomber"));
        prefabDict.Add(EnemyType.Viper, Resources.Load<GameObject>("Prefabs/Viper"));
    }

    public GameObject SpawnEnemyAtLocation(SpawnPackage sp)
    {
        GameObject newEnemy = GameObject.Instantiate(prefabDict[sp.enemyType]);
        newEnemy.GetComponent<Enemy>().InitializeEnemy(sp.GetPath());
        return newEnemy;
    }
}
