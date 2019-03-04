using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("UI Settings")]
    public Text startText; // Reference to the Text component of the StartText UI obj
    public Text finishText; // Reference to the Text component of the FinishText UI objectect

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // check if 'ESC' was pressed anytime
        {
            // Restart our game!
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Access current active scene and return the build index number
        }
    }

    public void ShowStartText() // show the startText information by setting enabled to true
    {
        startText.enabled = true;
    }

    public void HideStartText() // hide the startText information by setting enabled to false
    {
        startText.enabled = false;
    }

    public void ShowFinishText() // show the finishText information by setting enabled to true
    {
        finishText.enabled = true;
    }

    public void HideFinishText() // hide the finishText information by setting enabled to false
    {
        finishText.enabled = false;
    }
}
