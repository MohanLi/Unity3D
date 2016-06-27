using UnityEngine;
using System.Collections;

public enum AwardType
{
    GUN,
    SWORD
}

public class Award : MonoBehaviour {
    public AwardType award;
    public float speed = 20;
    private Rigidbody m_rigidbody;
    private Transform m_player;
    private bool m_startMove;

	void Start () {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
	}

    void Update()
    {
        if(m_startMove)
        {
            transform.position = Vector3.Lerp(transform.position, m_player.position + Vector3.up, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, m_player.position + Vector3.up) < 0.8)
            {
                m_player.GetComponent<PlayerAward>().GetAward(award);
                Destroy(this.gameObject);
            }
        }
    }

    void  OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tags.ground)
        {
            m_rigidbody.useGravity = false;
            m_rigidbody.isKinematic = true;

            SphereCollider spc = GetComponent<SphereCollider>();
            spc.isTrigger = true;
            spc.radius = 2;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.player)
        {
            //transform.position = Vector3.Lerp(transform.position, col.transform.position, Time.deltaTime * speed);
            m_player = col.transform;
            m_startMove = true;
        }
    }
}
