using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightSelecTrigger : MonoBehaviour
{
    public GameObject m_CanvasOpen;
    public GameObject m_PlayerMove;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_CanvasOpen.SetActive(true);
            m_PlayerMove.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("BlueMonster"))
        {
            SceneManager.LoadScene(2);
        }
        else if(this.CompareTag("RedMonster"))
        {
            SceneManager.LoadScene(1);
        }    
    }
    public void QuitFightSelector()
    {
        m_CanvasOpen.SetActive(false);
        m_PlayerMove.SetActive(true);
    }

    public void FightRedMonster()
    {
        SceneManager.LoadScene(1);
    }
    public void FightBlueMonster()
    {
        SceneManager.LoadScene(2);
    }
}
