using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawner : MonoBehaviour
{
    public GameObject dicePrefab; //references the Dice object/prefab
    public float positionX; //holds x positional info, and is referenced by the Game Manager
    public float positionY; //same as above for y
    private float fiveChunk; //divides up the screen into five chunks
    private Vector2 screenBounds; //defines the limits of the screen relative to the camera

    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GetComponent<Camera>(); //calls the camera and references it in future measurements
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)); //screenBounds now holds the relative positional information for the screen of the game
        fiveChunk = (screenBounds.x / 3); //fiveChunk, the main variable that splits up the placement of the dice, is set to 1/5 of the screen
        positionX = -2 * fiveChunk; //position variable is set to fiveChunk
        positionY = screenBounds.y / 3 + 1;
        transform.position = new Vector2(positionX, positionY); //x position of the spawner object is SHOCKINGLY given to position x
        DiceSpawn(); //instigates the DiceSpawn function
    }

    public void DiceSpawn() //the general "Dice Spawn" function that occurs on the start of the game
    {
        for (positionX = -2 * fiveChunk; positionX < screenBounds.x; positionX += fiveChunk) //a for loop that starts at -2 and goes until the end of the screen in intervals of fiveChunk, effectively running 5 times
        {
            Instantiate(dicePrefab, new Vector2(positionX, positionY), gameObject.transform.rotation); //instantiates a Dice at the position of the Spawner. I like the idea of the spawner itself moving and "placing" dice down as it goes. It's functionally identical to a stationary spawner with moving variables, but it's my preference
        }

        positionX = -2 * fiveChunk; //resets position of x
        positionY = screenBounds.y / 3 - 2; //resets position of y, now down a row

        for (positionX = -2 * fiveChunk; positionX < screenBounds.x; positionX += fiveChunk) //redoes the above for loop at a new y to create a second row
        {
            Instantiate(dicePrefab, new Vector2(positionX, positionY), gameObject.transform.rotation);
        }
    }
    public void SingleSpawn() //a function for spawning one Die: just has no for loop
    {
        Instantiate(dicePrefab, new Vector2(positionX, positionY), gameObject.transform.rotation); //called by Game Manager to replace utilized Die
    }
}