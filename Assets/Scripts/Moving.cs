using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public float minYSpeed;
    public float maxYSpeed;
    bool moveLeftOnStart;
    public GameObject deathVFX;
    bool isDead;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        RandomMovingDir();
    }
    void Update()
    {
        Flip();
    }
    void FixedUpdate()
    {
        rb.velocity = moveLeftOnStart 
        ? new Vector2(-speed, Random.Range(minYSpeed, maxYSpeed))
        : new Vector2(speed, Random.Range(minYSpeed, maxYSpeed));
    }
    void RandomMovingDir()
    {
        moveLeftOnStart = transform.position.x > 0 ? true : false;
    }
    public void Die()
    {
        isDead = true;
        Destroy(gameObject);
        if (deathVFX)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
        }
    }
    void Flip()
    {
        if (moveLeftOnStart)
        {
            if (transform.localScale.x < 0) return;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (transform.localScale.x > 0) return;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
