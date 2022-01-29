using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        if(!m_Input.Equals(Vector3.zero))
        {
            m_Rigidbody.rotation = Quaternion.LookRotation(m_Input);
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }
    }
}
