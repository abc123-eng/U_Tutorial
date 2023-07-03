using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    //��һ����Ϸ������ʽ�����Ǳ�ץ
    public CanvasGroup caughtBackgroundImageGroup;

    //�ж�����Ƿ��ߵ��յ㣬����������
    bool m_IsPlayerAtExit;

    //��� JohnLemon �Ƿ��ѱ�ץס
    bool m_IsPlayerCaught;

    //��ʱ���������ۻ�����ʱ��
    float m_Timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {

        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup,false);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageGroup,true);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup,bool doRestart)
    {
        //��ʱ����ʼ���ۼƵ���ʱ��������ʱ����  +displayImageDuration ���Ƴ���Ϸ
        m_Timer += Time.deltaTime;
        if (m_Timer > fadeDuration + displayImageDuration)
        {

            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
        //����ÿһ֡��  ֡ʱ���ۼ� / �������ʱ�� = alpha �ı仯ֵ
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
    }
}