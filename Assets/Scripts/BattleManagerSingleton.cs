using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleManagerSingleton : MonoBehaviour
{
    public GameObject m_PlayerPrefab;
    public GameObject m_RedEnemyPrefab;
    public GameObject m_BlueEnemyPrefab;

    public Transform m_PlayerStation;
    public Transform m_EnemyStation;

    public Character m_PlayerChar;
    public Character m_EnemyChar;

    public GameObject m_PlayerInst;
    public GameObject m_EnemyInst;

    public Text m_dialogueText;

    private string m_LastActionsName;

    public BattleState state;

    public BattleHUD m_PlayerHUD;
    public BattleHUD m_EnemyHUD;

    public GameObject m_PlayerActions;

    public CharacterAbilities m_CharacterAbilities;

    public static BattleManagerSingleton instance;

    public static BattleManagerSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<BattleManagerSingleton>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<BattleManagerSingleton>();
                    singleton.name = "(Singleton) BattleManageSingleton";
                }
            }
            return instance;
        }
    }

    public void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        m_CharacterAbilities = new CharacterAbilities();
    }

    IEnumerator SetupBattle()
    {
        m_PlayerActions.gameObject.SetActive(false);
        GameObject playerGO = Instantiate(m_PlayerPrefab, m_PlayerStation);
        m_PlayerChar = playerGO.GetComponent<Player>();
        m_PlayerInst = playerGO;

        GameObject enemyGO = Instantiate(m_RedEnemyPrefab, m_EnemyStation);
        m_EnemyChar = enemyGO.GetComponent<Enemy>();
        m_EnemyInst = enemyGO;

        m_dialogueText.text = "A wild " + m_EnemyChar.m_CharacterName + " wants to fight!";
        
        m_PlayerHUD.SetHUD(m_PlayerChar.GetComponent<Player>());
        m_EnemyHUD.SetHUD(m_EnemyChar.GetComponent<Enemy>());
        

        yield return new WaitForSeconds(2f);

        m_dialogueText.text = ("It's your move ") + m_PlayerChar.m_CharacterName;

        StateUpdate();

        m_PlayerActions.gameObject.SetActive(true);
    }

    IEnumerator PlayerFinishedTurn()
    {
        UIUpdate();
        m_dialogueText.text = m_PlayerChar.m_CharacterName + (" uses ") + m_PlayerChar.m_CharAbilities.m_LastAbility;
        m_PlayerActions.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        StateUpdate();
    }
    IEnumerator EnemyFisnihshedTurn()
    {
        m_dialogueText.text = m_EnemyChar.m_CharacterName + (" uses ") + m_EnemyChar.m_CharAbilities.m_LastAbility;
        yield return new WaitForSeconds(2f);
        
        UIUpdate();
        StateUpdate();
    }

    public void StateUpdate()
{

    if (m_EnemyChar.m_CurrentHP <= 0f)
    {
        state = BattleState.WON;
        StartCoroutine(WonBattle());
    }
    else if (m_PlayerChar.m_CurrentHP <= 0f)
    {
        state = BattleState.LOST;
        StartCoroutine(LostBattle());
    }
    if (state == BattleState.ENEMYTURN)
    {
        m_PlayerChar.m_IsDodging = false;
        state = BattleState.PLAYERTURN;
        if (m_PlayerChar.m_IsCharging)
        {
            m_PlayerChar.m_IsCharging = false;
            m_PlayerInst.GetComponent<Player>().ChargeAttack();     
            StartCoroutine(PlayerFinishedTurn());
        }
        else
        {
            m_dialogueText.text = " Your move !";
            m_PlayerChar.m_IsCharging = false;
            m_PlayerActions.SetActive(true);
        }
    }
    else if (state == BattleState.PLAYERTURN)
    {
        m_EnemyChar.m_IsDodging = false;
        m_dialogueText.text = " Enemy's move!";
        state = BattleState.ENEMYTURN;
        if (!m_EnemyChar.m_IsCharging)
        {
            m_EnemyInst.GetComponent<Enemy>().ChooseAbility();
            m_LastActionsName = ("Enemy use") + m_EnemyChar.m_CharAbilities.m_LastAbility;
            UIUpdate();
            StartCoroutine(EnemyFisnihshedTurn());
        }
        else
        {
            m_EnemyChar.m_IsCharging = false;
            m_LastActionsName = ("Enemy use") + m_EnemyChar.m_CharAbilities.m_LastAbility;
            m_EnemyInst.GetComponent<Enemy>().ChargeAttack();
            UIUpdate();
            StartCoroutine(EnemyFisnihshedTurn());
        }
    }
    else if(state == BattleState.START)
        {
            state = BattleState.PLAYERTURN;
        }
}

public GameObject GetTarget()
{
    if (state == BattleState.PLAYERTURN)
    {
        return m_EnemyInst;
    }
    else
    {
        return m_PlayerInst;
    }
}
public GameObject GetBuffTarget()
{
    if (state == BattleState.PLAYERTURN)
    {
        return m_PlayerInst;
    }
    else
    {
        return m_EnemyInst;

    }
}

IEnumerator WonBattle()
{
    m_dialogueText.text = "YOU WON THE BATTLE";
    yield return new WaitForSeconds(2f);
    SceneManager.LoadScene(0);
}

IEnumerator LostBattle()
{
    m_dialogueText.text = "YOU LOST THE BATTLE...";
    yield return new WaitForSeconds(2f);
    SceneManager.LoadScene(0);
}

public void UIUpdate()
{
    m_dialogueText.text = m_LastActionsName;
    m_PlayerActions.gameObject.SetActive(false);
    m_PlayerHUD.SetHP(m_PlayerChar.m_CurrentHP);
    m_EnemyHUD.SetHP(m_EnemyChar.m_CurrentHP);
}

public void AttackUI()
{
    m_PlayerActions.gameObject.SetActive(false);
    m_PlayerChar.GetComponent<Player>().FirstAbility();
    StartCoroutine(PlayerFinishedTurn());
}
public void HealUI()
{
    m_PlayerActions.gameObject.SetActive(false);
    m_PlayerInst.GetComponent<Player>().SecondAbility();
    StartCoroutine(PlayerFinishedTurn());
}
public void DodgeUI()
{
    m_PlayerActions.gameObject.SetActive(false);
    m_PlayerInst.GetComponent<Player>().ThirdAbility();
    StartCoroutine(PlayerFinishedTurn());
}
public void ChargeAttackUI()
{
    m_PlayerActions.gameObject.SetActive(false);
    m_PlayerInst.GetComponent<Player>().FourthAbility();
    StartCoroutine(PlayerFinishedTurn());
}
}
