using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blok : MonoBehaviour
{
    [SerializeField] AudioClip breaksound;
    [SerializeField] GameObject breakVFX;
    [SerializeField] int maxHits;
    [SerializeField] int timeHit;
    [SerializeField] Sprite[] hitSprites;
    //cached references
    Level level;
    gameStatus gameStatus;
    private void Awake()
    {
        
        
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<gameStatus>();
    }
    private void Start()
    {
        if (tag == "breakable")
        {
            level.countBreakableBlocks();
               
        }
        
    }
    private void Handlehit()
    {
        timeHit++;
        maxHits = hitSprites.Length + 1;
        if (timeHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSprites();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Handlehit();
        
    }

    private void ShowNextSprites()
    {
        int spriteIndex = timeHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError($"Sprites is missing forom away:+{ gameObject.name}");
        }
        

    }

    private void DestroyBlock()
    {
        if (tag == "breakable")
        {
            AudioSource.PlayClipAtPoint(breaksound, transform.position);
            level.DestroyBlocks();
            Destroy(gameObject);
            Sparklesseffect();
            gameStatus.AddToScore();
        }
        
    }

    private void Sparklesseffect()
    {
        GameObject sparkless = Instantiate(breakVFX, transform.position, Quaternion.identity);
        Destroy(sparkless, 1.5f);
    }
}
