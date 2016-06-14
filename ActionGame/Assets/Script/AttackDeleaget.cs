using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttackDeleaget : MonoBehaviour
{
    public delegate void AttackNormal();
    public event AttackNormal OnAttackNormal;

    public delegate void AttackRed();
    public event AttackRed OnAttackRed;

    public delegate void AttackRange();
    public event AttackRange OnAttackRange;

    public GameObject normalButton;
    public GameObject redButton;
    public GameObject rangeButton;

    void Start()
    {
        UIEventListener.Get(normalButton).onClick = OnNormalButtonClick;
        UIEventListener.Get(redButton).onClick = OnRedButtonClick;
        UIEventListener.Get(rangeButton).onClick = OnRangeButtonClick;
    }

    void OnNormalButtonClick(GameObject button)
    {
        if (this.OnAttackNormal != null)
        {
            this.OnAttackNormal();
        }
    }

    void OnRedButtonClick(GameObject button)
    {
        if (this.OnAttackRed != null)
        {
            this.OnAttackRed();
        }
    }

    void OnRangeButtonClick(GameObject button)
    {
        if (this.OnAttackRange != null)
        {
            this.OnAttackRange();
        }
    }
}
