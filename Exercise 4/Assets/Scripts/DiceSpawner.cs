using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawner : MonoBehaviour
{

    public GameObject dicePrefab;
    private float positionX;
    private float positionY;
    private float fiveChunk;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)); //screenBounds now holds the relative positional information for the screen of the game
        fiveChunk = (screenBounds.x / 2); //fiveChunk, the main variable that splits up the placement of the dice, is set to 1/5 of the screen
        positionX = -2 * fiveChunk; //position variable is set to fiveChunk
        positionY = screenBounds.y;
        transform.position = new Vector2(positionX, positionY); //x position of the spawner object is SHOCKINGLY given to position x
        DiceSpawn(); //instigates the DiceSpawn function
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DiceSpawn()
    {
        for (positionX = -2 * fiveChunk; positionX < screenBounds.x; positionX += fiveChunk)
        {
            Instantiate(dicePrefab, new Vector2(positionX, positionY), gameObject.transform.rotation);
            Debug.Log(fiveChunk);
        }

    }
}