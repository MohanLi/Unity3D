using UnityEngine;
using System.Collections;

public class ATKAndDamage : MonoBehaviour
{
    public float hp = 100;
    public float attackDistance = 1;
    public float normalAttack = 50;

    protected Animator animator;
    public int num = 0;

    protected void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
        }

        if (hp > 0)
        {
            animator.SetTrigger("damage");

            //if (transform.tag  == Tags.soulBoss)
            //{
            //    GameObject.Instantiate(Resources.Load("HitBoss"), transform.position, transform.rotation);
            //}
            //else if (transform.tag == Tags.soulMonster)
            //{
            //    GameObject.Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up, transform.rotation);
            //}
        }
        else
        {
            animator.SetTrigger("dead");
            if (transform.tag == Tags.soulBoss || transform.tag == Tags.soulMonster)
            {
                //防止collide影响主角的移动
                transform.GetComponent<CharacterController>().enabled = false;

                SpawnManager._instance.enemyList.Remove(this.gameObject);
                Destroy(this.gameObject, 1);
            }
        }

        if (transform.tag == Tags.soulBoss)
        {
            GameObject.Instantiate(Resources.Load("HitBoss"), transform.position, transform.rotation);
        }
        else if (transform.tag == Tags.soulMonster)
        {
            GameObject.Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up, transform.rotation);
        }
    }
}
