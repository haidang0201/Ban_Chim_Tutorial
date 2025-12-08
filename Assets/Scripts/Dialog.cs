using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text contenText;



    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
    public void UpdateDialog(string title, string content)
    {
        if (titleText) titleText.text = title;
        if (contenText) contenText.text = content;

    }
}
