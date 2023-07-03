using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //角色旋转速度
    public float turnSpeed = 20f;


    Animator m_Animator;


    Rigidbody m_Rigidbody;

    //三维矢量，
    Vector3 m_Movement;

    //四元素，用来控制3D对象的旋转
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
        //准备四元素，RotateTowards（当前朝向，目标朝向，转速，受限角度）
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        //赋值四元素
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }
    //物理引擎调用使执行这个函数
    private void OnAnimatorMove()
    {
        //MovePosition 表示刚体要移动到的目标位置。能够让角色移动更符合动画逻辑，更具有连贯性
        // m_Rigidbody.position 当前的物理位置，m_Movement 标准化移动方向 * m_Animator.deltaPosition.magnitude动画变化量
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        //使用四元素，旋转
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
