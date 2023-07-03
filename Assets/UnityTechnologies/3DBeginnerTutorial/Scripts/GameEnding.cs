using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    //UI图像淡入时长
    public float fadeDuration = 1f;

    //UI图像完全出现后显示的时长
    public float displayImageDuration = 1f;

    //获取玩家角色，目的是判断触发游戏结束条件
    public GameObject player;

    //获取CanvasGroup组件，目的是设置 Alpha 值
    public CanvasGroup exitBackgroundImageCanvasGroup;

    //判断玩家是否走到终点，碰到触发器
    bool m_IsPlayerAtExit;

    //计时器，用来累积淡入时长
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
        //计时器开始，累计淡入时长，到达时长后  +displayImageDuration 就推出游戏
        m_Timer += Time.deltaTime;
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            //游戏结束，这个方法要在 BUild 后才会触发，目前处于 Edit 阶段不会触发
            Application.Quit();
        }
        //利用每一帧的  帧时间累加 / 淡入持续时长 = alpha 的变化值
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
    }
}