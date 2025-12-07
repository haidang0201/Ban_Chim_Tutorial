
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
        StartCoroutine(GameSpawn());
        StartCoroutine(TimeCountDown());

    }
    IEnumerator TimeCountDown()
    {
        while (currentTimeLimit > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTimeLimit--;
            if(currentTimeLimit <= 0)
            {
                isGameOver = true;
            }
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
            spawnPos = new Vector2(7f, Random.Range(-5f, 2f));
        }
        else//random left
            spawnPos = new Vector2(-14f, Random.Range(-5f, 2f));

        if (birdPrefabs != null && birdPrefabs.Length > 0)
        {
            int ranIdx = Random.Range(0, birdPrefabs.Length);

            if (birdPrefabs[ranIdx] != null)
            {
                Bird birdClone = Instantiate(birdPrefabs[ranIdx], spawnPos, Quaternion.identity);
            }
        }
    }
}
