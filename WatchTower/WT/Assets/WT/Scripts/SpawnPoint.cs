using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    public GameObject objectToSpawn;
    public float spawnDelay = 20.0f;
    public bool enableSpawn = true;
    public float countDown;

	// Use this for initialization
	void Start () {
        countDown = spawnDelay;
	}
	
	// Update is called once per frame
	void Update () {

        countDown -= Time.deltaTime;
        if (countDown < 0)
        {
            //Application.LoadLevel("gameOver");
            if (enableSpawn)
            {
                Instantiate(objectToSpawn, transform.position, transform.rotation);
                countDown = spawnDelay;
                print("resetting");    
            }        
         }

    }
}
