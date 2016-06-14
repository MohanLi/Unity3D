using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour 
{
    public static float h;
    public static float v;

    private Transform button;
    private Vector3 buttonPosition;
    private bool isPress = false;
    private Vector2 size;
    
    void Awake()
    {
        button = transform.FindChild("Button");
        buttonPosition = button.localPosition;

        size = transform.GetComponent<UIWidget>().localSize;
    }

    void OnPress(bool isPress)
    {
        this.isPress = isPress;
    }

    void Update () 
    {
	    if (this.isPress)
        {
            Vector2 touchPos = UICamera.lastEventPosition;
            //为了让按钮要遥感背景初始位置一致；
            touchPos -= size / 2;

            float distance = Vector2.Distance(touchPos, Vector2.zero);

            if (distance > 74)
            {
                touchPos = touchPos.normalized * 74;
            }
            button.localPosition = touchPos;

            //h、v 值的范围[-1, 1]
            h = touchPos.x / 74;
            v = touchPos.y / 74;
        }
        else
        {
            h = 0;
            v = 0;
            button.localPosition = buttonPosition;
        }
	}
}
