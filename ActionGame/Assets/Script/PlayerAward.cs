using UnityEngine;
using System.Collections;

public class PlayerAward : MonoBehaviour
{
    public GameObject singleSwordGo;
    public GameObject dualSwordGo;
    public GameObject gunGo;

    private float dualTime;
    private float gunTime;
    private float timer;

    void Update()
    {
        if (dualTime <= 0 && gunTime <= 0 )
        {
            return;
        }
        timer += Time.deltaTime;
        if (dualTime > 0 && timer > gunTime)
        {
            SwitchToSingleSword();
            UIAttack._instance.SwitchToDoubleAttack();
        }
        if (gunTime > 0 && timer > gunTime)
        {
            SwitchToSingleSword();
            UIAttack._instance.SwitchToDoubleAttack();
        }
    }

    public void GetAward(AwardType type)
    {
        if (type == AwardType.SWORD)
        {
            SwitchToDualSword();
            UIAttack._instance.SwitchToDoubleAttack();
        }
        else if(type == AwardType.GUN)
        {
            SwitchToGun();
            UIAttack._instance.SwitchToSingleAttack();
        }
    }

    void SwitchToDualSword()
    {
        singleSwordGo.SetActive(false);
        dualSwordGo.SetActive(true);
        gunGo.SetActive(false);
        dualTime = 10;
        gunTime = 0;
    }

    void SwitchToSingleSword()
    {
        singleSwordGo.SetActive(true);
        dualSwordGo.SetActive(false);
        gunGo.SetActive(false);

        dualTime = 0;
        gunTime = 0;
    }

    void SwitchToGun()
    {
        singleSwordGo.SetActive(false);
        dualSwordGo.SetActive(false);
        gunGo.SetActive(true);

        dualTime = 0;
        gunTime = 10;
    }
}
