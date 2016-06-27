using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerATKAndDamage : ATKAndDamage 
{
    public float attackB = 80;
    public float attackRange = 100;
    public WeaponGun gun;
    public AudioClip attackClip;
    public AudioClip gunClip;

    public void AttackA()
    {
        PlayAttackEffect();
        GameObject enemy = null;
        float distance = attackDistance;

        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float temp = Vector3.Distance(transform.position, go.transform.position);
            if (temp <= distance)
            {
                enemy = go;
                distance = temp;
            }
        }

        if (enemy != null)
        {
            //player 看向即将攻击的敌人f
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);

            //敌人受击
            enemy.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }

    public void AttackB()
    {
        PlayAttackEffect();

        GameObject enemy = null;
        float distance = attackDistance;

        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float temp = Vector3.Distance(transform.position, go.transform.position);
            if (temp <= distance)
            {
                enemy = go;
                distance = temp;
            }
        }

        if (enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);

            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackB);
        }

    }

    public void AttackRange()
    {
        PlayAttackEffect();
        List<GameObject> temp = new List<GameObject>();
        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float distance = Vector3.Distance(go.transform.position, transform.position);
            if (distance <= attackDistance)
            {
                temp.Add(go);
            }
        }

        //使用临时变量，是为了防止enemyList中途被修改
        foreach (GameObject go in temp)
        {
            go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
        }
    }

    public void AttackGun()
    {
        PlayGunAttackEffect();
        gun.Shot();
    }

    void PlayAttackEffect()
    {
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 0.8f);
    }

    void PlayGunAttackEffect()
    {
        AudioSource.PlayClipAtPoint(gunClip, transform.position, 0.8f);
    }
}
