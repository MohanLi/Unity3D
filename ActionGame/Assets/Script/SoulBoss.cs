using UnityEngine;
using System.Collections;

public class SoulBoss : MonoBehaviour
{
    public float attackDistance = 2;
    public float speed = 3;

    private CharacterController cController;
    private Transform player;
    private PlayerATKAndDamage atkAndDamage;
    private Animator bossAnim;

    private float attackTime = 3;
    private float attackTimer = 0;

    void Start()
    {
        cController = GetComponent<CharacterController>();
        bossAnim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        atkAndDamage = player.GetComponent<PlayerATKAndDamage>();
        attackTimer = attackTime;
    }

    void Update()
    {
        if (atkAndDamage.hp <= 0)
        {
            bossAnim.SetBool("walk", false);
            return;
        }

        transform.LookAt(player.position);
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < attackDistance)//在攻击范围之内
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackTime)
            {
                string attackName = Random.Range(0, 2) > 0 ? "attack1" : "attack2";
                bossAnim.SetTrigger(attackName);
                attackTimer = 0;
                Debug.Log(attackName);
            }
            else
            {
                bossAnim.SetBool("walk", false);
            }
        }
        else//不在攻击范围，向主角走去
        {
            bossAnim.SetBool("walk", true);
            if (bossAnim.GetCurrentAnimatorStateInfo(0).IsName("BossRun01"))
            {
                attackTimer = attackTime;
                cController.SimpleMove(transform.forward * speed);
            }
        }
    }
}
