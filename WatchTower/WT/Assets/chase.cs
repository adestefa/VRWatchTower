using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour {

    public Transform Target;
    Animator anim;
    public int TrackingDistance = 100;
    public int AttackRange = 3;
    public float WalkingSpeed = 0.05f;
    private bool target_alive;
    public float AttackDamage = 5.0f;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", false);

        print("Target: " + Target);
    }   
	
	// Update is called once per frame
	void Update () {

       
        target_alive = Target.GetComponent<health>().alive;
        // print("Target is alive?: " + target_alive);
        // print("Target: " + Target);

        if (!target_alive)
        {
            print("YOU LOST!");
        }

        // if distance from player is within 50 units away from player
        if ((target_alive) && (Vector3.Distance(Target.position,this.transform.position) < TrackingDistance))
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
} 
