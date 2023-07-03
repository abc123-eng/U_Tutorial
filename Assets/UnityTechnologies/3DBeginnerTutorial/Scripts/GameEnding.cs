using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    //UIͼ����ʱ��
    public float fadeDuration = 1f;

    //UIͼ����ȫ���ֺ���ʾ��ʱ��
    public float displayImageDuration = 1f;

    //��ȡ��ҽ�ɫ��Ŀ�����жϴ�����Ϸ��������
    public GameObject player;

    //��ȡCanvasGroup�����Ŀ�������� Alpha ֵ
    public CanvasGroup exitBackgroundImageCanvasGroup;

    //�ж�����Ƿ��ߵ��յ㣬����������
    bool m_IsPlayerAtExit;

    //��ʱ���������ۻ�����ʱ��
    float m_Timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        //��ʱ����ʼ���ۼƵ���ʱ��������ʱ����  +displayImageDuration ���Ƴ���Ϸ
        m_Timer += Time.deltaTime;
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            //��Ϸ�������������Ҫ�� BUild ��Żᴥ����Ŀǰ���� Edit �׶β��ᴥ��
            Application.Quit();
        }
        //����ÿһ֡��  ֡ʱ���ۼ� / �������ʱ�� = alpha �ı仯ֵ
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
    }
}