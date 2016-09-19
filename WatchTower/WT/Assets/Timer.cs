using UnityEngine;
using System.Collections;


public class Timer : MonoBehaviour {
    public int timerMax = 10000;        // time to complete this level
    public TextMesh timer_;             // text to show timer UI
    public bool playGame = false;       // game toggle
    public Hits score_;                 // score class to track number of hits
    public string nextScene;            // name of next scene
    public int numHitsToNextScene;      // number of hits to advance to next scene
    // Use this for initialization
    void Start () {
        timer_.text = timerMax.ToString();
        playGame = false;

       // GameObject scoreboardNeeded = GameObject.FindGameObjectWithTag("ScoreBoardHitsNeeded");
       // scoreboardNeeded.needed = "test";
    }
   

    // Update is called once per frame
     void Update()
    {

        //if (playGame)
        //{

            // manage the game timer
            if (timerMax > 0)
            {
                if (this.score_.numHits < numHitsToNextScene)
                {
                    timerMax = timerMax - 1;
                    timer_.text = "Timer: " + timerMax.ToString();
                }
                else
                {
                    timer_.text = "Round cleared!";
                     Application.LoadLevel(nextScene);
                }
            }
            else
            {
                timer_.text = "Game Over";
            }
        //} 

    }
}


