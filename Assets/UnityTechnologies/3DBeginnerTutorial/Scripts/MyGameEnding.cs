using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyGameEnding : MonoBehaviour
{
    //UI图像淡入时长
    public float fadeDuration = 1f;

    //UI图像完全出现后显示的时长
    public float displayImageDuration = 1f;

    //获取玩家角色，目的是判断触发游戏结束条件
    public GameObject player;

    //获取CanvasGroup组件，目的是设置 Alpha 值
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public Image image;
    //退出游戏音效
    public AudioSource exitSource;
    //被抓游戏音效
    public AudioSource caughtAudio;


    //判断玩家是否走到终点，碰到触发器
    bool m_IsPlayerAtExit;

    //检查 JohnLemon 是否已被抓住
    bool m_IsPlayerCaught;
    //创建两个对象，分别表示从硬盘中获取的图片素材
    Sprite spriteCaught;
    Sprite spriteWon;



    //计时器，用来累积淡入时长
    float m_Timer;
    //确保音频仅播放一次,被抓或者胜利游戏都结束，这个值只用到一次
    bool m_HasAudioPlayed;

    void Start()
    {
        //Resources.Load 只能加载 Assests/Resources 文件夹资源
        //以文件名为参数
        spriteCaught = Resources.Load<Sprite>("Caught");
        spriteWon = Resources.Load<Sprite>("Won");
    }

    //如果玩家触碰到结束游戏的触发器，则触发游戏胜利条件
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        //被抓住时，重新加载场景
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            //逃脱方法
            EndLevel(spriteWon,false,exitSource);
        }
        else if (m_IsPlayerCaught)
        {
            //被抓方法
            EndLevel(spriteCaught,true,caughtAudio);
        }
    }

    void EndLevel(Sprite Sprite,bool doRestart,AudioSource audioSource)
    {
        //音频播放判断条件，确保播放一次，（我觉得写的多余
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        //计时器开始，累计淡入时长，到达时长后  +displayImageDuration 就推出游戏
        m_Timer += Time.deltaTime;
        //指定UI Image 的图片源
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
        //利用每一帧的  帧时间累加 / 淡入持续时长 = alpha 的变化值
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
    }
}