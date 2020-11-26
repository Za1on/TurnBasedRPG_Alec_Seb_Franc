using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
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
