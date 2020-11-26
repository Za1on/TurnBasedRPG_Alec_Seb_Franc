using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody m_PlayerRigid;
    [SerializeField] private float m_MovementSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            m_PlayerRigid.AddForce(0, m_MovementSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.S))
            m_PlayerRigid.AddForce(0, -m_MovementSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.A))
            m_PlayerRigid.AddForce(-m_MovementSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            m_PlayerRigid.AddForce(m_MovementSpeed * Time.deltaTime, 0, 0);
        
    }
}
