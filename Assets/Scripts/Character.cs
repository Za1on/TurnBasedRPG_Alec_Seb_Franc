using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterAbilities m_CharAbilities;

    public int m_MaxHP;
    public int m_CurrentHP;

    public int m_Damage;
    public int m_ChargeDamage;

    public int m_HealValue;

    public int m_Level;

    public string m_CharacterName;

    public bool m_IsDodging;
    public bool m_IsCharging;

    public void Start()
    {
        m_CharAbilities = new CharacterAbilities();
    }

}
