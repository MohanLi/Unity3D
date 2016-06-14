using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    private CharacterController cController;
    private Animator animator;
    public float speed = 4;

    void Awake()
    {
        cController = gameObject.GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (JoyStick.h != 0 || JoyStick.v != 0)
        {
            h = JoyStick.h;
            v = JoyStick.v;
        }

        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
        {
            PlayAnim("walk");

            if(animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
            {
                Vector3 targetV3 = new Vector3(h, 0, v);
                transform.LookAt(targetV3 + transform.position);
                cController.SimpleMove(transform.forward * speed);
            }
        }
        else
        {
            StopAnim("walk");
        }
    }

    void PlayTrigger(string name)
    {
        animator.SetTrigger(name);
    }

    void PlayAnim(string name)
    {
        animator.SetBool(name, true);
    }

    void StopAnim(string name)
    {
        animator.SetBool(name, false);
    }
}
