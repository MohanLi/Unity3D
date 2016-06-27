using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour 
{
    public static MiniMap _instance;
    private Transform playerIcon;
    public GameObject enemyPrefab;

    void Awake()
    {
        _instance = this;
        playerIcon = transform.Find("PlayerIcon");
    }

    public Transform GetPlayerIcon()
    {
        return playerIcon;
    }

    public GameObject GetEnemyIcon()
    {
        GameObject go = NGUITools.AddChild(this.gameObject, enemyPrefab);
        return go;
    }
}
