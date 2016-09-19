using UnityEngine;
using System.Collections;

public class Hits : MonoBehaviour {
    public int numHits;
    public TextMesh hits_;
    //public GameObject scoretimer;
    //public Timer t_;

    // Use this for initialization
    void Start()
    {
        numHits = 0;
        //this.t_ = scoretimer.GetComponentInChildren<Timer>();
    } 

    public void addHit()
    {
        print("Hits::addHit:called");
        numHits = numHits + 1;
    }
	
	// Update is called once per frame
	void Update () {
        hits_.text = "" + numHits;

	}
}
