using UnityEngine;
using System.Collections;

public class UIAttack : MonoBehaviour {
    public static UIAttack _instance;

    public GameObject normalAttack;
    public GameObject rangeAttack;
    public GameObject gunAttack;

    void Awake()
    {
        _instance = this;
    }

    public void SwitchToSingleAttack()
    {
        normalAttack.SetActive(false);
        rangeAttack.SetActive(false);
        gunAttack.SetActive(true);
    }

    public void SwitchToDoubleAttack()
    {
        normalAttack.SetActive(true);
        rangeAttack.SetActive(true);
        gunAttack.SetActive(false);
    }

}
