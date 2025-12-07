using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [SerializeField] public Vector3 target;
     [SerializeField] public bool onFiring;
    void Awake()
    {
        InputManager.instance = this;
    }
    void Update()
    {
        GetMousDown();
    }
    void FixedUpdate()
    {
        this.GetMousePos();
    }
    protected virtual void GetMousePos()
    {
        this.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMousDown()
    {
        this.onFiring = Input.GetMouseButtonDown(0);
        //Debug.Log(onFiring);
        
    }
}
