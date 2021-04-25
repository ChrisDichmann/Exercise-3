using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject heldDice; //the object that references the dice that has already been clicked, and is being compared to
    public GameObject theSpawner; //references the DiceSpawner, to bring in new die after a click

    public GameObject chainText; //references the chain to increase the chain with each successful click (also contains score)
    public GameObject triesText; //references the tries to decrease player's remaining tries on a discard

    public Vector3 clickedPosition; //holds the position info of a clicked die BEFORE it moves to a new placement

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() //fun fact: ALL OF THIS was in the Dice Script. Then I moved it to a Game Manager and it fixed a TON of problems.
    {
        if (Input.GetMouseButtonDown(0)) //on left mouse click
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //sets the input of the mouse relative to the camera
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y); //places said relativity on a 2D plane

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero); //raycasts a beam straight forward for physics collision
            if (hit.collider != null) //checks to see if the click has hit anything: this ended up being a real problem, and placing it just right solved a lot of bugs
            {             
                if (heldDice == hit.transform.gameObject) //if the clicked object IS the held dice
                {
                    Destroy(heldDice); //destroy the dice
                    heldDice = null; //set held dice to null, essentially resetting the pseudo-boolean and opening the held dice position to all
                    chainText.GetComponent<ChainScript>().setChain = 0; //resets chain on this discard
                    triesText.GetComponent<TriesScript>().triesCount -= 1; //removes a try on this discard
                }
                else
                {
                    Vector2 mousePos2DAbove = new Vector2(mousePos.x, mousePos.y + 3); //places said relativity on a 2D plane for the dice above the clicked options
                    RaycastHit2D hitAbove = Physics2D.Raycast(mousePos2DAbove, Vector2.zero); //raycasts a beam straight above the click by 3 units, the exact distance between the die on the bottom and the top rows

                    if (heldDice == null && hit.collider.tag == "Bottom" /*Switch == false*/) //if the player clicks a die and THERE IS NO DIE IN THE HELD POSITION - includes old boolean switch as a relic of the past
                    {
                        clickedPosition = hit.transform.position; //takes the positional info of the clicked Die and saves it before the die moves
                        hitAbove.transform.position = clickedPosition; //takes the die hit by the above beam and moves it to the position of clickedPosition aka the former position of the clicked die

                        hit.transform.position = new Vector3(0f, -3.5f, 0f); //sends the hit die to the "held" location at the bottom middle of the screen
                        //hit.collider.tag = "Held"; //the old design for this section tagged the die clicked as "held" once it moved. This tag was invaluable in determining the values contained within the die, but was unmanageable due to deleting anything it touched
                        heldDice = hit.transform.gameObject; //sets the variable gameObject heldDice to the moved dice. This has the effect of the "held" tag, but without the sheer annoyance.
                        //Switch = true; //the old boolean switch: this was used to determine whethere there was a dice to be replaced on the bottom of the screen, now replaced with the check for a value in heldDice                   

                        GameObject.Find("DiceSpawner").GetComponent<DiceSpawner>().positionX = clickedPosition.x; //grabs the DiceSpawner and moves it to the former x coordinate of the clicked Die
                        GameObject.Find("DiceSpawner").GetComponent<DiceSpawner>().positionY = clickedPosition.y + 3; //grabs the DiceSpawner and moves it to the former y coordinate of the clicked Die PLUS 3, which is essentially the row above
                        GameObject.Find("DiceSpawner").GetComponent<DiceSpawner>().SingleSpawn(); //initializes a single spawn of a Die at the Spawner's new location

                        chainText.GetComponent<ChainScript>().setChain += 1; //increase chain
                        chainText.GetComponent<ChainScript>().setScore += 1; //increase score
                    }

                    else if (hit.collider.tag == "Bottom") //if the click hits a dice with tag Bottom, which is given on the Bottom Row
                    {
                        float clickedValue = hit.transform.GetComponent<DiceScript>().Value; //grabs the Value variable from within the clicked dice
                        //Debug.Log(clickedValue); //shows off the value in the console: I like to keep this handy to make sure the clicks are properly pulling the correct value
                        // GameObject heldDice = GameObject.FindGameObjectWithTag("Held"); //previously heldDice would be determined by the object that had the "held" tag: this was much more general, and was replaced by literally assigning the variable to the game object on each move
                        float heldValue = heldDice.GetComponent<DiceScript>().Value; //grabs the Value variable from the held dice

                        bool valid = (heldValue + 1) % 6 == clickedValue; //special thanks to Sweaters Sam for this one: originally I had two if statments for if the clicked dice was +1 over the held dice's Value, up to 5, then a second if statment for if the clicked dice was 1, and the held was six. This streamlines that process by modifying the count to wrap around at 6.

                        float clickedColor = hit.transform.GetComponent<DiceScript>().Color; //grabs the Color Array data on the clicked Die
                        float heldColor = heldDice.GetComponent<DiceScript>().Color; //grabs the Color Array data on the held Die

                        bool matching = clickedColor == heldColor; //compares the Color between the held and the clicked Die: sets boolean matching to true if they match

                        if (valid || matching) //two booleans: if either is true (color matches or value is +1 compared), a successful move can be made
                        {
                            clickedPosition = hit.transform.position; //sets clickedPosition to the position data of the clicked die before it moves
                            hitAbove.transform.position = clickedPosition; //moves the Die hit by the above Raycast to the former position of the clicked Die

                            hit.transform.position = heldDice.transform.position; //moves the clicked dice to the held dice position
                            // hit.collider.tag = "Held"; //originally set the collider tag of the clicked dice to held
                            Destroy(heldDice); //destroys the old held dice
                            heldDice = hit.transform.gameObject; //sets the clicked dice as the held dice   

                            GameObject.Find("DiceSpawner").GetComponent<DiceSpawner>().positionX = clickedPosition.x; //grabs the Dice Spawner, moves it to clicked die's X
                            GameObject.Find("DiceSpawner").GetComponent<DiceSpawner>().positionY = clickedPosition.y + 3; //grabs the Dice Spawner, moves it to clicked die's Y + 3
                            GameObject.Find("DiceSpawner").GetComponent<DiceSpawner>().SingleSpawn(); //initializes the spawn

                            chainText.GetComponent<ChainScript>().setChain += 1; //increase chain
                            chainText.GetComponent<ChainScript>().setScore += 1; //increase score
                        }
                    }
                }
            }
        }    
    }
}