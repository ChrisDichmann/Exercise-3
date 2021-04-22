using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawner : MonoBehaviour
{
    public GameObject invisibleSpawn;
    private GameObject dicePrefab;
    public float positionX;
    public int diceSelector;

    // Start is called before the first frame update
    void Start()
    {
        positionX = invisibleSpawn.transform.position.x;
        positionX = 80;
    }

    // Update is called once per frame
    void Update()
    {
        //DiceSpawn();
        RandomizeDice();
    }

   /* public void DiceSpawn()
    {
        for (positionX = 80; positionX < 960; positionX += 160)
        {
            Instantiate(dicePrefab, gameObject.transform.position, gameObject.transform.rotation);
        }

    } */

    public void RandomizeDice()
    {
        System.Random r = new System.Random();
        int diceSelector = r.Next(1, 36);

        string diceVariable = string.Format("Dice{diceSelector}");
        Debug.Log(diceVariable);
    }
}
