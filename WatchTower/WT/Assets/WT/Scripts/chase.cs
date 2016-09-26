using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour {

    public Transform Target;
    Animator anim;
    public int TrackingDistance = 1000;
    public int AttackRange = 3;
    public float WalkingSpeed = 0.05f;
    private bool target_alive;
    public float AttackDamage = 5.0f;

    private bool done = false;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", false);

        print("Target: " + Target);
    }   

    void findNextTarget()
    {
        Debug.Log("Finding next target...");
        GameObject[] temp;
        bool done = false;
        temp = GameObject.FindGameObjectsWithTag("tower");
        for (int i = 0; i < temp.Length; i++)
        {
            if (!done)
            {
                Debug.Log("FOUND TOWER:" + temp[i].name);
                if (temp[i].name != null)
                {
                    Debug.Log("Setting New TARGET! YEAHHH!");
                    Target = temp[i].GetComponent<Transform>();
                    done = true;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Target != null) { 

            target_alive = Target.GetComponent<health>().alive;
            // print("Target is alive?: " + target_alive);
            // print("Target: " + Target);


            // if distance from player is within 50 units away from player
            if (target_alive && (Vector3.Distance(Target.position,this.transform.position) < TrackingDistance))
            {
           


                // turn to face the player!
                Vector3 direction = Target.position - this.transform.position;
                direction.y = 0; // avoid tipping backwards when too close!
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                // since we are in tracking distance
                anim.SetBool("isWalking", true);

                // keep walking if not close enough
                if (direction.magnitude > AttackRange)
                {
                    anim.SetBool("isWalking", true);
                    this.transform.Translate(0, 0, WalkingSpeed);
                    anim.SetBool("isAttacking", false);
                }
                // ATTACK!
                else
                {
                    anim.SetBool("isAttacking", true);
                    anim.SetBool("isWalking", false);
                
                }

            }
            // too far away, simply idle
            else
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
            
            
            }

        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);

            findNextTarget();

        }
    }
} 
