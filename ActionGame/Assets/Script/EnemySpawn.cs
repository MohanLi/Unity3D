using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject CreateEnemy()
    {
        return GameObject.Instantiate(enemyPrefab, transform.position, transform.rotation) as GameObject;
    }
}
