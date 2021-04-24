using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{

    public Sprite[] sprites;
    public Color[] colors;

    public int Value;
    public int Color;

    private bool Switch;

    public GameObject heldDice;

    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        Switch = false;

        Value = Random.Range(0, 5); //sets the integer variable behind the number on the dice to a random of 0-5
        Color = Random.Range(0, 5); //same as above, but for the variable behind the color on the dice

        spriteRender = GetComponent<SpriteRenderer>(); //grabs the sprite renderer for the container object: in this case, the Dice object

        spriteRender.sprite = sprites[Value]; //sets the sprite itself to one that corresponds with the Value variable on the array list
        spriteRender.color = colors[Color]; //same as above for color: these are dual systems.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (Switch == false)
                {
                    hit.transform.position = new Vector3(0f, -3.5f, 0f);
                    Switch = true;
                }

                else if (Switch == true)
                {
                    float clickedValue = hit.transform.GetComponent<DiceScript>().Value;
                    Debug.Log(clickedValue);
                    GameObject heldDice = GameObject.FindGameObjectWithTag("Held");
                    float heldValue = heldDice.GetComponent<DiceScript>().Value;

                    if (heldValue != 5 && clickedValue == (heldValue - 1))
                    {

                    }

                    else if (heldValue == 5 && clickedValue == 0)
                    {

                    }

                    else if (heldDice.layer == 2)
                    {
                        hit.transform.position = heldDice.transform.position;
                        Destroy(heldDice);
                    }
                }
            }
        }
    }
}
