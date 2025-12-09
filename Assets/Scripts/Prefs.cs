using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class Prefs
{
    //PlayerPrefs: luu du lieu ng choi
    
   public static int bestScore
    {
        get => PlayerPrefs.GetInt(GameConst.BEST_SCORE, 0);
        set
        {
            //score da luu vao bo nho
            int currentScore = PlayerPrefs.GetInt(GameConst.BEST_SCORE);
            if(value > bestScore)
            {
                //khi score hien tai > bestscore thi luu score cao nhat
                PlayerPrefs.SetInt(GameConst.BEST_SCORE, value);
            }

        }
    }
}
