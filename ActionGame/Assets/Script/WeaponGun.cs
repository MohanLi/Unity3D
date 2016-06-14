using UnityEngine;
using System.Collections;

public class WeaponGun : MonoBehaviour {
    public GameObject bullet;
    public Transform bulletPos;
    public float attack = 100;

    public void Shot()
    {
        GameObject go = GameObject.Instantiate(bullet, bulletPos.position, transform.root.rotation) as GameObject;
        go.GetComponent<Bullet>().attack = attack;
    }
}
