using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyGameEnding : MonoBehaviour
{
    //UIͼ����ʱ��
    public float fadeDuration = 1f;

    //UIͼ����ȫ���ֺ���ʾ��ʱ��
    public float displayImageDuration = 1f;

    //��ȡ��ҽ�ɫ��Ŀ�����жϴ�����Ϸ��������
    public GameObject player;

    //��ȡCanvasGroup�����Ŀ�������� Alpha ֵ
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public Image image;
    //�˳���Ϸ��Ч
    public AudioSource exitSource;
    //��ץ��Ϸ��Ч
    public AudioSource caughtAudio;


    //�ж�����Ƿ��ߵ��յ㣬����������
    bool m_IsPlayerAtExit;

    //��� JohnLemon �Ƿ��ѱ�ץס
    bool m_IsPlayerCaught;
    //�����������󣬷ֱ��ʾ��Ӳ���л�ȡ��ͼƬ�ز�
    Sprite spriteCaught;
    Sprite spriteWon;



    //��ʱ���������ۻ�����ʱ��
    float m_Timer;
    //ȷ����Ƶ������һ��,��ץ����ʤ����Ϸ�����������ֵֻ�õ�һ��
    bool m_HasAudioPlayed;

    void Start()
    {
        //Resources.Load ֻ�ܼ��� Assests/Resources �ļ�����Դ
        //���ļ���Ϊ����
        spriteCaught = Resources.Load<Sprite>("Caught");
        spriteWon = Resources.Load<Sprite>("Won");
    }

    //�����Ҵ�����������Ϸ�Ĵ��������򴥷���Ϸʤ������
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        //��ץסʱ�����¼��س���
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            //���ѷ���
            EndLevel(spriteWon,false,exitSource);
        }
        else if (m_IsPlayerCaught)
        {
            //��ץ����
            EndLevel(spriteCaught,true,caughtAudio);
        }
    }

    void EndLevel(Sprite Sprite,bool doRestart,AudioSource audioSource)
    {
        //��Ƶ�����ж�������ȷ������һ�Σ����Ҿ���д�Ķ���
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        //��ʱ����ʼ���ۼƵ���ʱ��������ʱ����  +displayImageDuration ���Ƴ���Ϸ
        m_Timer += Time.deltaTime;
        //ָ��UI Image ��ͼƬԴ
        image.sprite = Sprite;

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
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
    }
}