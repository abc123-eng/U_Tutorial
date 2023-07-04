using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    //添加主角的Transform，用来检测它
    public Transform Player;

    //引用 GameEnding 脚本
    public MyGameEnding myGameEnding;

    //是否检测到主角
    bool m_IsPlayerInRange;

    //有物体进入触发器，射线开始每帧检测
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == Player)
        { 
            m_IsPlayerInRange = true;
        }
    }

    //物体离开触发器，射线停止检测，省运行开销
    void OnTriggerExit(Collider other)
    {
        if (other.transform == Player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        //有物体进入触发器，可能是玩家可能是墙，通过射线检测
        if(m_IsPlayerInRange)
        {
            //从 PointOfView 游戏对象到 JohnLemon 的方向 = JohnLemon 的位置减去 PointOfView 游戏对象的位置。
            //Vector3.up(0,1,0),因为JohnLemon 的 position 在两脚之间
            Vector3 direction = Player.position - transform.position + Vector3.up;
            
            //创建射线，（射线发出位置，方向）因为三维矢量是带有方向和大小的量，给 Vector3 能表示方向
            Ray ray = new Ray(transform.position, direction);

            //用于存储射线碰撞信息的变量
            RaycastHit raycastHit;

            //发出一条检测物理对象的射线，检测到物理对象返回true，否则false
            // 碰撞信息会存储在raycastHit对象中，可以通过该对象访问和使用碰撞信息
            if (Physics.Raycast(ray,out raycastHit))
            {
                if(raycastHit.collider.transform == Player)
                {
                    myGameEnding.CaughtPlayer();

                }

            }

        }
    }

}
