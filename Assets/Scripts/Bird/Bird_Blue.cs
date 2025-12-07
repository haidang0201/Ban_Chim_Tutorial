
using UnityEngine;

public class Bird_Blue : Bird_Red
{


    protected override void SpawBird()
    {
        yRandom = Random.Range(-4.5f, 1.5f);
        xRandom = Random.Range(-15.5f, -14.5f);

        Vector3 spawnPos = new Vector3(xRandom, yRandom, bird.transform.position.z);
        timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return;
        timer = 0;
        Instantiate(bird, spawnPos, Quaternion.identity);
        //gameObject.SetActive(true);
    }
    
}
