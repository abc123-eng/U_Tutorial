using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //包含 AI 命名空间将让您能够访问 NavMeshAgent 类。

public class WaypointPatrol : MonoBehaviour
{

    //设置NavMeshAgent 组件对象，来获取当前游戏的导航网格代理组件
    public NavMeshAgent navMeshAgent;

    //声明幽灵要经过的路径点位，用数组表示
    public Transform[] waypoints;

    //当前索引指针
    int m_CurrentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        //设置 Nav Mesh Agent 的初始目标
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        //判断是否到达目标点位，到达去下一个点位
        //当前游戏对象到指定路径点（目标点）的距离 < 接近目标点距离
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        { 
            //通过取余，获取 0 - 数组length-1的数字，作为 路径点位数组的索引
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            //SetDestination(vector3 target) 移动到 target 位置 
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
