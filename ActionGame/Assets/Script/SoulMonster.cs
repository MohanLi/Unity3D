using UnityEngine;
using System.Collections;

public class SoulMonster : MonoBehaviour
{
    private Transform player;
    private PlayerATKAndDamage atkAndDamage;
    private Animator monsterAnim;
    private CharacterController cController;

    public float speed = 2f;
    public float attackDistance = 0.9f;
    public float attackTime = 3;
    private float attackTimer;

    void Start()
    {
        cController = GetComponent<CharacterController>();
        monsterAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        atkAndDamage = player.GetComponent<PlayerATKAndDamage>();
        attackTimer = attackTime;
    }

    void Update()
    {
        if (atkAndDamage.hp <= 0)
        {
            monsterAnim.SetBool("walk", false);
            return;
        }

        transform.LookAt(player);
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= attackDistance)
        {
            monsterAnim.SetBool("walk", false);
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackTime)
            {
                monsterAnim.SetTrigger("attack");
                attackTimer = 0;
            }
        }
        else
        {
            attackTimer = attackTime;
            monsterAnim.SetBool("walk", true);
            if (monsterAnim.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
            {
                //Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
                //transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
                cController.SimpleMove(transform.forward * speed);
            }
        }
    }
}
