using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    //添加主角的Transform，用来检测它
    public Transform Player;

    //引用 GameEnding 脚本
    public GameEnding gameEnding;

    //是否检测到主角
    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == Player)
        { 
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == Player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if(m_IsPlayerInRange)
        {
            //从 PointOfView 游戏对象到 JohnLemon 的方向 = JohnLemon 的位置减去 PointOfView 游戏对象的位置。
            //Vector3.up(0,1,0),因为JohnLemon 的 position 在两脚之间
            Vector3 direction = Player.position - transform.position + Vector3.up;
            
            //创建射线，（射线发出位置，方向）
            Ray ray = new Ray(transform.position, direction);

            RaycastHit raycastHit;

            //发出一条检测物理对象的射线，检测到物理对象返回true，否则false
            if (Physics.Raycast(ray,out raycastHit))
            {
                if(raycastHit.collider.transform == Player)
                {
                    gameEnding.CaughtPlayer();

                }

            }

        }
    }

}
