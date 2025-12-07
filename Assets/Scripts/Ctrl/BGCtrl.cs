using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCtrl : Singleton<BGCtrl>
{
    public Sprite[] sprites;

    public SpriteRenderer bgimage;
    public override void Awake()
    {
        MakeSingleton(false);
    }
    public override void Start()
    {
        ChangeSprites();
    }
    public void ChangeSprites()
    {
        //random bg khi vao game
        if(bgimage != null && sprites != null && sprites.Length > 0)
        {
            int randomIdx = Random.Range(0, sprites.Length);
            if(sprites[randomIdx] != null)
            {
                bgimage.sprite = sprites[randomIdx];
            }
        }
    }
}
