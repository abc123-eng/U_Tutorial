using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //���� AI �����ռ佫�����ܹ����� NavMeshAgent �ࡣ

public class WaypointPatrol : MonoBehaviour
{

    //����NavMeshAgent �����������ȡ��ǰ��Ϸ�ĵ�������������
    public NavMeshAgent navMeshAgent;

    //��������Ҫ������·����λ���������ʾ
    public Transform[] waypoints;

    //��ǰ����ָ��
    int m_CurrentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        //���� Nav Mesh Agent �ĳ�ʼĿ��
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        //�ж��Ƿ񵽴�Ŀ���λ������ȥ��һ����λ
        //��ǰ��Ϸ����ָ��·���㣨Ŀ��㣩�ľ��� < �ӽ�Ŀ������
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        { 
            //ͨ��ȡ�࣬��ȡ 0 - ����length-1�����֣���Ϊ ·����λ���������
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            //SetDestination(vector3 target) �ƶ��� target λ�� 
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
