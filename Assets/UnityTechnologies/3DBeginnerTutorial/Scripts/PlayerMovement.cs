using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //��ɫ��ת�ٶ�
    public float turnSpeed = 20f;


    Animator m_Animator;


    Rigidbody m_Rigidbody;

    //��άʸ����
    Vector3 m_Movement;

    //��Ԫ�أ���������3D�������ת
    Quaternion m_Rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerzontalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerzontalInput;
        m_Animator.SetBool("IsWalking", isWalking);
        //׼����Ԫ�أ�RotateTowards����ǰ����Ŀ�곯��ת�٣����޽Ƕȣ�
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        //��ֵ��Ԫ��
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }
    //�����������ʹִ���������
    private void OnAnimatorMove()
    {
        //MovePosition ��ʾ����Ҫ�ƶ�����Ŀ��λ�á��ܹ��ý�ɫ�ƶ������϶����߼���������������
        // m_Rigidbody.position ��ǰ������λ�ã�m_Movement ��׼���ƶ����� * m_Animator.deltaPosition.magnitude�����仯��
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        //ʹ����Ԫ�أ���ת
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
