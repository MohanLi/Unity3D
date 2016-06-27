using UnityEngine;
using System.Collections;

public class ATKAndDamage : MonoBehaviour
{
    public float hp = 100;
    public float attackDistance = 1;
    public float normalAttack = 50;
    public AudioClip deadClip;
    //public AudioClip damageClip;

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
            //AudioSource.PlayClipAtPoint(damageClip, transform.position, 0.8f);
            animator.SetTrigger("damage");
        }
        else
        {
            AudioSource.PlayClipAtPoint(deadClip, transform.position, 0.8f);
            animator.SetTrigger("dead");
            if (transform.tag == Tags.soulBoss || transform.tag == Tags.soulMonster)
            {
                //防止collide影响主角的移动
                transform.GetComponent<CharacterController>().enabled = false;

                int num = Random.Range(0, 2);
                if (num == 0)
                {
                    GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("item-dualSword"), transform.position + Vector3.up, Quaternion.identity);
                    Award ad = go.AddComponent<Award>();
                    ad.speed = 10;
                    ad.award = AwardType.SWORD;
                }
                else if (num == 1)
                {
                    GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("item-gun"), transform.position + Vector3.up, Quaternion.identity);
                    Award ad = go.AddComponent<Award>();
                    ad.speed = 10;
                    ad.award = AwardType.GUN;
                }

                SpawnManager._instance.enemyList.Remove(this.gameObject);
                Destroy(this.gameObject, 1);
            }
        }

        if (transform.tag == Tags.soulBoss)
        {
            GameObject.Instantiate(Resources.Load("HitBoss"), transform.position + Vector3.up, transform.rotation);
        }
        else if (transform.tag == Tags.soulMonster)
        {
            GameObject.Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up, transform.rotation);
        }
    }
}
