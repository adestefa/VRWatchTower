using UnityEngine;
using System.Collections;

public class health : MonoBehaviour
{

    //public Image healthBar;
    public float max_health = 100f;
    public float cur_health = 0f;
    public GameObject healthBar;
    public AudioSource damage_sound;
    public AudioSource die_sound;
    public bool alive;

    private float Damage_Skeleton = 2f;
    private float Damage_Demon = 10f;
    private float Damage_Golem = 10f;
    private float Damage_Guul = 10f;
    private float Damage_Ifrit = 5f;

    void Awake()
    {
        if (damage_sound==null)
        {
            damage_sound = GameObject.Find("Attack").GetComponent<AudioSource>();
        }

        if (die_sound == null)
        {
            die_sound = GameObject.Find("Die").GetComponent<AudioSource>();
        }
        
    }

    void playHitSound()
    {
        damage_sound.Play();
    }

    void playDieSound()
    {
       die_sound.Play();
    }


    // Use this for initialization
    void Start()
    {
        cur_health = max_health;
        print("start Health" + cur_health);
        alive = true;

    }
   
  void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            playHitSound();
            print("hit");

            takeDamage(5f);

       /**     if (other.gameObject.name=="Skeleton")
            {
                takeDamage(Damage_Skeleton);
            }
            else if (other.gameObject.name == "Demon")
            {
                takeDamage(Damage_Demon);
            }
            else if (other.gameObject.name == "Ifrit")
            {
                takeDamage(Damage_Ifrit);
            }
            else if (other.gameObject.name == "Golem")
            {
                takeDamage(Damage_Golem);
            }
            else if (other.gameObject.name == "Guul")
            {
                takeDamage(Damage_Guul);
            } */

        }
    }


    public void takeDamage(float damage)
    {
        print("Take damage:" + damage);

        // [cur_health] absolute value
        if (cur_health > 1)
        {
            // remove damage from attacker
            cur_health -= damage;
            print("cur health:" + cur_health);
            
            // calculate health bar percentage
            float my_health = cur_health / max_health;

            print("tower new health: " + my_health);
            // update healthbar
            setHealthBar(my_health);

            if (alive && cur_health <= 1)
            {
                print("Tower down!:" + cur_health);
                Destroy(gameObject, 1f);
                Destroy(GetComponent<MeshRenderer>());
                Destroy(GetComponent<Canvas>());
                alive = false;
                cur_health = 0;
            }
        }
        
    }

    public void setHealthBar(float myhealth)
    {
        //myhealth = Mathf.Clamp(myhealth, 0f, 1f);
        print("set HealthBar" + myhealth);
        //healthBar.transform.localScale = new Vector3(Mathf.Clamp(my_health, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        healthBar.transform.localScale = new Vector3(myhealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

   

}
