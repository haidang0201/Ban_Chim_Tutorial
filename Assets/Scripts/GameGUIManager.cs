using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject gameGUI;
    public GameObject homeGUI;


    public Dialog gameDialog;
    public Dialog pauseDialog;

    public Image fireImageFilled;
    public TMP_Text timerText;
    public TMP_Text killCountingText;

    Dialog currentDialog;

    public Dialog CurrentDialog { get => currentDialog; set => currentDialog = value; }

    public override void Awake()
    {
        this.MakeSingleton(false);//k luu du lieu khi awake
    }

    public void GameShowGUI(bool isShow)
    {
        if (gameGUI)
        {
            gameGUI.SetActive(isShow);
        }
        if (homeGUI)
        {
            homeGUI.SetActive(!isShow);
        }
    }
    public void UpdateTimer(string time)
    {
        if (timerText)
        {
            timerText.text = time;
        }
    }
    public void UpdateKillCountTing(int kill)
    {
        if (killCountingText)
        {
            killCountingText.text = "x" + kill.ToString();//chuyen int  sang chuoi
        }
    }
    public void UpdateFireRate(float rate)
    {
        if (fireImageFilled)
        {
            fireImageFilled.fillAmount = rate;
        }
    }

}
