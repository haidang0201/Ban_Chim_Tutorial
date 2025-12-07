using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    float timer = 0f;
    public float timeDelay =1;
    public bool isShooting;
    private Vector3 mousePos;
    public float speed;
    Vector3 targetPos;

    void Update()
    {
        mousePos = InputManager.instance.target;
        if (InputManager.instance.onFiring  && !isShooting)
            Shoot(mousePos);

        if (isShooting)
        {
            this.GetTime();
        }
    }
    void FixedUpdate()
    {
        Moving();
        GetTargetPos();
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, targetPos, speed);
        transform.position = newPos;
    }
    private void GetTargetPos()
    {
        this.targetPos = InputManager.instance.target;
        this.targetPos.z = 0;
    }
    void Shoot(Vector3 mousePos)
    {
        isShooting = true;
        Vector3 shootDir = Camera.main.transform.position - mousePos;
        shootDir.Normalize();// giu nguyen huong vector =1;
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, shootDir);
        if (hits != null & hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                if (hit.collider && (Vector3.Distance((Vector2)hit.collider.transform.position, (Vector2)mousePos) < 0.4f))
                {
                    Debug.Log(hit.collider.name);
                    Bird bird = hit.collider.GetComponent<Bird>();
                    if (bird) bird.Die();
                }
            }
        }
        AudioContrl.Ins.PlaySound(AudioContrl.Ins.shooting);
    }
    void GetTime()
    {
        this.timeDelay -= Time.deltaTime;
        if (this.timeDelay <= 0)
        {
            isShooting = false;
            this.timeDelay = 0.3f;   
        }
    }
}
