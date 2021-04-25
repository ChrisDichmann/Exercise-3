using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChainScript : MonoBehaviour
{
    public int setChain; //the value of the chain variable
    public int setScore; //the value of the score variable
    public Text chainText; //the text of chain
    public Text scoreText; //the text of score

    // Start is called before the first frame update
    void Start()
    {
        chainText = GetComponent<Text>(); //grabs the text value of the Chain Text
        setChain = 0; //sets chain to 0 on start
    }

    // Update is called once per frame
    void Update()
    {
        chainText.text = setChain + " Chain"; //prints the chain value plus the word "Chain"
        scoreText.text = setScore + "/50"; //prints the score with "/50"
    }
}
