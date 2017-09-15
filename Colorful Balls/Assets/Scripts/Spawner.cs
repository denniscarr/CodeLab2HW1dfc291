using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject ballPrefab;


    private void Start()
    {
        InvokeRepeating("SpriteTime", 0f, 0.015f);
    }


    void SpriteTime()
    {
        MakeSprite(GetComponent<NumberGenerator>().Next());
    }


    void MakeSprite(int spriteIndex)
    {
        GameObject newSprite = Instantiate(ballPrefab);
        newSprite.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
        newSprite.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere * 25f, ForceMode2D.Impulse);
        newSprite.GetComponent<Ball>().colorIndex = spriteIndex;
        newSprite.transform.position = Random.insideUnitSphere * 5f;
    }
}