using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour 
{
    public static SpawnManager _instance;

    public EnemySpawn[] monsterArray;
    public EnemySpawn[] bossArray;

    public List<GameObject> enemyList = new List<GameObject>();

    void Awake()
    {
        _instance = this;
    }

	void Start () 
    {
        StartCoroutine(StartSpwan());
	}

    IEnumerator StartSpwan()
    {
        //创建第一波敌人
        foreach (EnemySpawn monster in monsterArray)
        {
            enemyList.Add(monster.CreateEnemy());
            yield return new WaitForSeconds(0.4f);
        }
        yield return new WaitForSeconds(0.5f);
        while(enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        //创建第二波敌人
        foreach (EnemySpawn boss in bossArray)
        {
            enemyList.Add(boss.CreateEnemy());
        }
        yield return new WaitForSeconds(0.5f);
        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        //创建第三波敌人
        foreach (EnemySpawn monster in monsterArray)
        {
            enemyList.Add(monster.CreateEnemy());
        }
        yield return new WaitForSeconds(0.5f);

        foreach (EnemySpawn monster in monsterArray)
        {
            enemyList.Add(monster.CreateEnemy());
        } 
        yield return new WaitForSeconds(0.5f);

        foreach (EnemySpawn boss in bossArray)
        {
            enemyList.Add(boss.CreateEnemy());
        }

        yield return 0;
    }
}