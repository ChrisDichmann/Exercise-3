using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{ 
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene"); //simple scene manager using button function to activate this function on click of button
    }
}
