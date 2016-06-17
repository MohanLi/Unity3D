using UnityEngine;
using System.Collections;

public class SoulBossATKAndDamage : ATKAndDamage 
{
    public float thumpAttack = 90;
    private Transform player;

    void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    //重击
    public void SoulBossAttack1()
    {
        if (IsCanAttack())
        {
           // player.GetComponent<ATKAndDamage>().TakeDamage(thumpAttack);
        }
        player.GetComponent<ATKAndDamage>().TakeDamage(thumpAttack);
    }

    //普通攻击
    public void SoulBossAttack2()
    {
        if (IsCanAttack())
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }

    //是否在攻击范围之内
    private bool IsCanAttack()
    {
        Debug.Log("==============" + Vector3.Distance(player.position, transform.position));
        return Vector3.Distance(player.position, transform.position) <= attackDistance;
    }
}
