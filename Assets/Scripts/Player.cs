using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Transform m_PlayerPosition;
    public GameObject m_ChargePrefab;
    public GameObject m_BeamPrefab;
    public GameObject m_HealingIndic;
    public Animator m_PlyrAnim;
    [SerializeField]
    bool m_Attacking;
    [SerializeField]
    bool m_Charging;
    [SerializeField]
    bool m_ReleaseChargeAttack;
    [SerializeField]
    bool m_Dodging;
    [SerializeField]
    bool m_Healing;
    [SerializeField]
    bool m_Damaged;



    public void Awake()
    {
        m_PlyrAnim = GetComponent<Animator>();
    }
    public void FirstAbility()
    {
        m_Attacking = true;
        m_CharAbilities.AttackAbility(m_Damage);
    }
    public void SecondAbility()
    {
        m_CharAbilities.HealAbility(m_HealValue);
    }
    public void ThirdAbility()
    {
        m_CharAbilities.DodgeAbility();
    }
    public void FourthAbility()
    {
        m_CharAbilities.ChargingAbility();
    }
    public void ChargeAttack()
    {
        m_CharAbilities.ChargedAttack(m_ChargeDamage);
    }
    public void ManageAnim()
    {
        if(m_Charging)
        {
            Instantiate(m_ChargePrefab,m_PlayerPosition);
        }
        if(m_ReleaseChargeAttack)
        {
            Instantiate(m_BeamPrefab, m_PlayerPosition);
        }
        if(m_Dodging)
        {
            m_PlyrAnim.SetTrigger("Evading");
        }    
        if(m_Damaged)
        {
            m_PlyrAnim.SetTrigger("Damaged");
        }
        if(m_Attacking)
        {
            m_PlyrAnim.SetTrigger("AttackNow");
        }
    }
}
