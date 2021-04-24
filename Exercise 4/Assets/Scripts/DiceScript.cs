using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{

    public Sprite[] sprites;
    public Color[] colors;

    public int Value;
    public int Color;

    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        Value = Random.Range(0, 5); //sets the integer variable behind the number on the dice to a random of 0-5
        Color = Random.Range(0, 5); //same as above, but for the variable behind the color on the dice

        spriteRender = GetComponent<SpriteRenderer>(); //grabs the sprite renderer for the container object: in this case, the Dice object

        spriteRender.sprite = sprites[Value]; //sets the sprite itself to one that corresponds with the Value variable on the array list
        spriteRender.color = colors[Color]; //same as above for color: these are dual systems.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
