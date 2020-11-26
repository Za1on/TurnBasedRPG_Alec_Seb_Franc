using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text m_NameText;
    public Text m_LevelText;
    public Slider m_HPSlider;

    public void SetHUD(Character character)
    {
        m_NameText.text = character.m_CharacterName;
        m_LevelText.text = "Lvl " + character.m_Level;
        m_HPSlider.maxValue = character.m_MaxHP;
        m_HPSlider.value = character.m_CurrentHP;
    }
    public void SetHP(int _HP)
    {
        m_HPSlider.value = _HP;
    }

}
