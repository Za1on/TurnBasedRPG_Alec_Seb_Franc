using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

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
}
