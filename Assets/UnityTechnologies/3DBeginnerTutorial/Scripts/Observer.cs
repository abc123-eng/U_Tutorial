using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    //������ǵ�Transform�����������
    public Transform Player;

    //���� GameEnding �ű�
    public GameEnding gameEnding;

    //�Ƿ��⵽����
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
            //�� PointOfView ��Ϸ���� JohnLemon �ķ��� = JohnLemon ��λ�ü�ȥ PointOfView ��Ϸ�����λ�á�
            //Vector3.up(0,1,0),��ΪJohnLemon �� position ������֮��
            Vector3 direction = Player.position - transform.position + Vector3.up;
            
            //�������ߣ������߷���λ�ã�����
            Ray ray = new Ray(transform.position, direction);

            RaycastHit raycastHit;

            //����һ����������������ߣ���⵽������󷵻�true������false
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
