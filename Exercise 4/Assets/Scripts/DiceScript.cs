using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    public Sprite[] sprites; //an array that holds 6 sprites for Dice to randomly select on Initialization
    public Color[] colors; //an array that holds 6 color values for Dice to randomly select on Initialization

    public int Value; //the variable that determines which line of the sprites array the Die picks
    public int Color; //the variable for the above, but for color values

    private SpriteRenderer spriteRender; //grabs the sprite renderer of the object in order to alter its appearance at will

    // Start is called before the first frame update
    void Start()
    {
        Value = Random.Range(0, 6); //sets the integer variable behind the number on the dice to a random of 0-5
        Color = Random.Range(0, 6); //same as above, but for the variable behind the color on the dice

        spriteRender = GetComponent<SpriteRenderer>(); //grabs the sprite renderer for the container object: in this case, the Dice object

        spriteRender.sprite = sprites[Value]; //sets the sprite itself to one that corresponds with the Value variable on the array list
        spriteRender.color = colors[Color]; //same as above for color: these are dual systems.
    }

    private void Update()
    {
        if (transform.position.y < 0) //code for the Dice to differentiate between top and bottom row: a simple, janky fix, but one that works. Dividing rows by having Dice beneath y=0 get a special tag
        {
            transform.gameObject.tag = "Bottom"; //gives Dice on the bottom row the tag "Bottom," allowing them to be interacted with
        }
    }
}
