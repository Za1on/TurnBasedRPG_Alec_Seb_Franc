using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public ParticleSystem m_Charge;
    public ParticleSystem m_Beam;
    public ParticleSystem m_HealingIndic;
    public Animator m_EnemyAnim;
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
    public void Update()
    {
        ManageAnim();
    }
    public virtual void ChooseAbility()
    {
        int rng = Random.Range(1, 4);
        switch (rng)
        {
            case 1:
                FirstAbility();
                break;
            case 2:
                SecondAbility();
                break;
            case 3:
                ThirdAbility();
                break;
            case 4:
                FourthAbility();
                break;
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
        if(m_Attacking)
        {
            m_Attacking = false;
            m_EnemyAnim.SetTrigger("Charge");
        }
        if(m_Dodging)
        {
            m_Dodging = false;
            m_EnemyAnim.SetTrigger("Dodge");
        }
        if (m_Charging)
        {
            m_Charging = false;
            m_Charge.gameObject.SetActive(true);
            m_Charge.Stop();
            m_Charge.Play();
        }
        if (m_ReleaseChargeAttack)
        {
            m_ReleaseChargeAttack = false;
            m_Beam.gameObject.SetActive(true);
            m_Beam.Stop();
            m_Beam.Play();
        }
        if (m_Healing)
        {
            m_Healing = false;
            m_HealingIndic.gameObject.SetActive(true);
            m_HealingIndic.Stop();
            m_HealingIndic.Play();
        }
    }
    public void TakeDmg()
    {
        m_EnemyAnim.SetTrigger("Dmged");
    }
}
