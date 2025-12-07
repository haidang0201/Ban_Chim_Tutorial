using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestB : MonoBehaviour
{
    public static TestB instance;//singleton
    void Awake()
    {
        TestB.instance = this;
    }
    public void ShowB()
    {
        Debug.Log(transform.name);
    }
}
