using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public float speed = 3;
    private Vector3 offSet;
    public Transform player;

    void Start()
    {
        //使用tag有时候找不到，求解
        //player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        offSet = transform.position - player.position;
        //offSet = new Vector3(0.1f, 2.67f, -4.89f);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offSet, Time.deltaTime * speed);
        Quaternion qt = Quaternion.LookRotation(player.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, qt, Time.deltaTime * speed);
        transform.LookAt(transform.position, player.position);
    }
}
