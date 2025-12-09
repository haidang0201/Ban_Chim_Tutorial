
//using System;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float spawnTime;
    public Bird[] birdPrefabs;
    bool isGameOver;
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

    public int timeLimit;
    int currentTimeLimit;
    int birdKill;
    public int BirdKill { get => birdKill; set => birdKill = value; }



    public override void Awake()
    {
        this.MakeSingleton(false);
        currentTimeLimit = timeLimit;
    }
    public override void Start()
    {
        GameGUIManager.Ins.GameShowGUI(false);
        GameGUIManager.Ins.UpdateKillCountTing(birdKill);


    }
    
     public void PlayGame()
    {
        StartCoroutine(GameSpawn());
        StartCoroutine(TimeCountDown());
        GameGUIManager.Ins.GameShowGUI(true);
    }
    IEnumerator TimeCountDown()
    {
        while (currentTimeLimit > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTimeLimit--;
            if (currentTimeLimit <= 0)
            {
                isGameOver = true;

                GameGUIManager.Ins.gameDialog.UpdateDialog("VẬY THÔI Á", "BEST KILLED : x" + birdKill);
               
                //GameGUIManager.Ins.gameDialog.UpdateDialog("VẬY THÔI Í", "BEST KILLED : x" + Prefs.bestScore);
                

                GameGUIManager.Ins.gameDialog.Show(true);
                GameGUIManager.Ins.CurrentDialog = GameGUIManager.Ins.gameDialog;
                Prefs.bestScore = birdKill;
            }
                GameGUIManager.Ins.UpdateTimer(IntToTime(currentTimeLimit));
            
        }
    }
    IEnumerator GameSpawn()
    {
        //vong lap random
        while (!isGameOver)
        {
            SpawnBird();
            yield return new WaitForSeconds(spawnTime);
        }
    }
    public void SpawnBird()
    {
        Vector3 spawnPos = Vector3.zero;
        //xh random
        float ranCheck = Random.Range(0f, 1f);
        //random right
        if (ranCheck >= 0.5)
        {
            spawnPos = new Vector2(14f, Random.Range(-6.5f, 4f));
        }
        else//random left
            spawnPos = new Vector2(-20f, Random.Range(-6.5f, 4f));

        if (birdPrefabs != null && birdPrefabs.Length > 0)
        {
            int ranIdx = Random.Range(0, birdPrefabs.Length);

            if (birdPrefabs[ranIdx] != null)
            {
                Bird birdClone = Instantiate(birdPrefabs[ranIdx], spawnPos, Quaternion.identity);
            }
        }
    }
    string IntToTime(int time)
    {
        float minutes = Mathf.Floor(time / 60);//lam tron
        float seconds = Mathf.RoundToInt(time % 60);
        return minutes.ToString("00") + " : " + seconds.ToString("00");

    }
}
