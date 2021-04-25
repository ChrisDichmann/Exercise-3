using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriesScript : MonoBehaviour
{
    public int triesCount; //holds the number variable for player's tries
    public Text triesText; //the actual text that will be printed
    // Start is called before the first frame update
    void Start()
    {
        triesText = GetComponent<Text>(); //grabs the text at start
        triesCount = 6; //set player's tries to 6 on start
    }

    // Update is called once per frame
    void Update()
    {
        triesText.text = triesCount + ""; //set the printed text to just be the value of triesCount. Added an invisible string because the code refused to read the variable as a string.

        if (triesCount <= -1) //gives the player an additional try at 0: once you hit -1, you're out of tries
        {
            SceneManager.LoadScene("GameOver"); //scene manager that sends player to game over
        }
    }
}
