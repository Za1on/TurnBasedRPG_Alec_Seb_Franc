using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities
{
    public string m_LastAbility;

    public void AttackAbility(int dmg)
    {
        GameObject targetGameObject = BattleManagerSingleton.Instance.GetTarget();
        Character targetCharacter = targetGameObject.GetComponent<Character>();
        if (!targetCharacter.m_IsDodging)
        {
            targetCharacter.m_CurrentHP -= dmg;
            //targetCharacter.TakeDmg();
            m_LastAbility = " Attack ability";
            if(targetCharacter.tag == "Player")
            {
                targetCharacter.GetComponent<Player>().TakeDmg();
            }
            else
            {
                targetCharacter.GetComponent<Enemy>().TakeDmg();
            }
        }
        else
        {
            targetCharacter.m_IsDodging = false;
            m_LastAbility = " Attack ability but the enemy dodged!";
        }
    }
    public void HealAbility(int _amount)
    {
        GameObject targetGameObject = BattleManagerSingleton.Instance.GetBuffTarget();
        Character targetCharacter = targetGameObject.GetComponent<Character>();
        targetCharacter.m_CurrentHP += _amount;
        if (targetCharacter.m_MaxHP <= targetCharacter.m_CurrentHP)
        {
            targetCharacter.m_CurrentHP = targetCharacter.m_MaxHP;
        }
        m_LastAbility = " heal ability";

    }
    public void DodgeAbility()
    {
        GameObject targetGameObject = BattleManagerSingleton.Instance.GetBuffTarget();
        Character targetCharacter = targetGameObject.GetComponent<Character>();
        targetCharacter.m_IsDodging = true;
        m_LastAbility = " it's dodge ability, the next attack will be dodged!";
    }
    public void ChargingAbility()
    {
        GameObject targetGameObject = BattleManagerSingleton.Instance.GetBuffTarget();
        Character targetCharacter = targetGameObject.GetComponent<Character>();
        targetCharacter.m_IsCharging = true;
        m_LastAbility = " charge attack, it's now charging...";
    }
    public void ChargedAttack(int _CDmg)
    {
        GameObject targetGameObject = BattleManagerSingleton.Instance.GetTarget();
        Character targetCharacter = targetGameObject.GetComponent<Character>();
        if (!targetCharacter.m_IsDodging)
        {
            targetCharacter.m_CurrentHP -= _CDmg;
            m_LastAbility = " Charge attack unleashed!";
            if (targetCharacter.tag == "Player")
            {
                targetCharacter.GetComponent<Player>().TakeDmg();
            }
            else
            {
                targetCharacter.GetComponent<Enemy>().TakeDmg();
            }
        }
        else
        {
            targetCharacter.m_IsDodging = false;
            m_LastAbility = " Attack ability but the opposing dodged!";
        }
       
    }
}
