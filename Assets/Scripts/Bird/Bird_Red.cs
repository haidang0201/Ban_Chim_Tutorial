
using UnityEngine;

public class Bird_Red : MonoBehaviour
{
    public float yRandom;
     public float xRandom;
     
    public float timer = 0f;
    public float timeDelay = 1f;
    public GameObject bird;

    void Start()
    {
    // gameObject.SetActive(false);
    }

    void Update()
    {
        SpawBird();
        //SelfDestroy();
    }
    protected virtual void SpawBird()
    {
        yRandom = Random.Range(-5f, 3.5f);
        xRandom = Random.Range(-15f, -14f);

        //prefabs
        Vector3 spawnPos = new Vector3(xRandom, yRandom, bird.transform.position.z);
        timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return;
        timer = 0;


        Instantiate(bird, spawnPos, Quaternion.identity);
        //gameObject.SetActive(true);
    }

    protected virtual void SelfDestroy()
    {
        Invoke(nameof(DestroyObj), 3f);
    }
    protected virtual void DestroyObj()
    {
        Destroy(gameObject);
    }
    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject)
    //     {
    //     Destroy(gameObject);
    //     }
    // }
}
