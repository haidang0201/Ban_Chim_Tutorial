using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestA : MonoBehaviour
{
    void Update()
    {
        TestB.instance.ShowB();
    }
}
