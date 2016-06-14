using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float attack = 100;
    public float speed = 10;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.soulBoss || col.tag == Tags.soulMonster)
        {
            col.GetComponent<ATKAndDamage>().TakeDamage(attack);
        }
    }
}
