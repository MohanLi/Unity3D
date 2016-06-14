using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
    private Animator playerAnim;
    private AttackDeleaget attackDeleaget;
    private bool isCanAttackB;

    void Start()
    {
        playerAnim = GetComponent<Animator>();

        attackDeleaget = GameObject.FindObjectOfType<AttackDeleaget>();
        attackDeleaget.OnAttackNormal += NormalAttack;
        attackDeleaget.OnAttackRange += RangeAttack;
        attackDeleaget.OnAttackRed += RedAttack;
    }

    /// <summary>
    /// 普通攻击
    /// </summary>
    void NormalAttack()
    {
        if (isCanAttackB && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA"))
        {
            playerAnim.SetTrigger("attackb");
        }
        else
        {
            playerAnim.SetTrigger("attacka");
        }
    }

    /// <summary>
    /// 巨人状态下普通攻击
    /// </summary>
    void RedAttack()
    {
        playerAnim.SetTrigger("attacka");
    }

    /// <summary>
    /// 大范围攻击
    /// </summary>
    void RangeAttack()
    {
        playerAnim.SetTrigger("attackrange");
    }

    public void AttackBEvent1()
    {
        isCanAttackB = true;
    }

    public void AttackBEvent2()
    {
        isCanAttackB = false;
    }

    void OnDestroy()
    {
        attackDeleaget.OnAttackNormal -= NormalAttack;
        attackDeleaget.OnAttackRange -= RangeAttack;
        attackDeleaget.OnAttackRed -= RedAttack;
    }
}
