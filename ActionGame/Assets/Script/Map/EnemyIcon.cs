using UnityEngine;
using System.Collections;

public class EnemyIcon : MonoBehaviour
{
    private Transform enemyIcon;
    private Transform player;

    void Start()
    {
        enemyIcon = MiniMap._instance.GetEnemyIcon().transform;
        if(this.tag == Tags.soulBoss)
        {
            enemyIcon.GetComponent<UISprite>().spriteName = "BossIcon";
        }
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    void Update()
    {
        Vector3 offset = transform.position - player.position;
        offset *= 10;
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > 10)
        {
            enemyIcon.gameObject.SetActive(false);
        }
        else
        {
            enemyIcon.gameObject.SetActive(true);
        }
        enemyIcon.localPosition = new Vector3(offset.x, offset.z, 0);
    }

    void OnDestroy()
    {
        if (enemyIcon != null)
        {
            Destroy(enemyIcon.gameObject);
        }
    }
}
