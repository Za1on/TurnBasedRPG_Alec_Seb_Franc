﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public ParticleSystem m_Charge;
    public ParticleSystem m_Beam;
    public ParticleSystem m_HealingIndic;
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
    [SerializeField]
    float m_RealCurrentHp;

    public void Awake()
    {
        m_PlyrAnim = GetComponent<Animator>();
    }
    public void Update()
    {      
        ManageAnim();
        m_RealCurrentHp = m_CurrentHP;
        if(m_CurrentHP == m_RealCurrentHp)
        {
            //Play Damage Animation
        }
    }
    public void FirstAbility()
    {
        m_Attacking = true;
        m_CharAbilities.AttackAbility(m_Damage);
    }
    public void SecondAbility()
    {
        m_Healing = true;
        m_CharAbilities.HealAbility(m_HealValue);
    }
    public void ThirdAbility()
    {
        m_Dodging = true;
        m_CharAbilities.DodgeAbility();
    }
    public void FourthAbility()
    {
        m_Charging = true;
        m_CharAbilities.ChargingAbility();
    }
    public void ChargeAttack()
    {
        m_ReleaseChargeAttack = true;
        m_CharAbilities.ChargedAttack(m_ChargeDamage);
    }
    public void ManageAnim()
    {
        if(m_Charging)
        {
            m_Charging = false;
            m_Charge.gameObject.SetActive(true);
            m_Charge.Stop();
            m_Charge.Play();
        }
        if(m_ReleaseChargeAttack)
        {
            m_ReleaseChargeAttack = false;
            m_Beam.gameObject.SetActive(true);
            m_Beam.Stop();
            m_Beam.Play();
        }
        if(m_Healing)
        {
            m_Healing = false;
            m_HealingIndic.gameObject.SetActive(true);
            m_HealingIndic.Stop();
            m_HealingIndic.Play();
        }
        if(m_Dodging)
        {
            m_Dodging = false;
            m_PlyrAnim.SetTrigger("Evading");
            
        }    
        if(m_Damaged)
        {
            m_PlyrAnim.SetTrigger("Damaged");
        }
        if(m_Attacking)
        {
            m_Attacking = false;
            m_PlyrAnim.SetTrigger("AttackNow");
        }
    }
   
}
