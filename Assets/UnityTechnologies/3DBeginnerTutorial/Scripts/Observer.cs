using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    //������ǵ�Transform�����������
    public Transform Player;

    //���� GameEnding �ű�
    public MyGameEnding myGameEnding;

    //�Ƿ��⵽����
    bool m_IsPlayerInRange;

    //��������봥���������߿�ʼÿ֡���
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == Player)
        { 
            m_IsPlayerInRange = true;
        }
    }

    //�����뿪������������ֹͣ��⣬ʡ���п���
    void OnTriggerExit(Collider other)
    {
        if (other.transform == Player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        //��������봥��������������ҿ�����ǽ��ͨ�����߼��
        if(m_IsPlayerInRange)
        {
            //�� PointOfView ��Ϸ���� JohnLemon �ķ��� = JohnLemon ��λ�ü�ȥ PointOfView ��Ϸ�����λ�á�
            //Vector3.up(0,1,0),��ΪJohnLemon �� position ������֮��
            Vector3 direction = Player.position - transform.position + Vector3.up;
            
            //�������ߣ������߷���λ�ã�������Ϊ��άʸ���Ǵ��з���ʹ�С�������� Vector3 �ܱ�ʾ����
            Ray ray = new Ray(transform.position, direction);

            //���ڴ洢������ײ��Ϣ�ı���
            RaycastHit raycastHit;

            //����һ����������������ߣ���⵽������󷵻�true������false
            // ��ײ��Ϣ��洢��raycastHit�����У�����ͨ���ö�����ʺ�ʹ����ײ��Ϣ
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
