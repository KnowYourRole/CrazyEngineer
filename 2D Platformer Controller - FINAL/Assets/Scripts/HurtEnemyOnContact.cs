using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {

    public int damageToGive;

    public float bounceOnEnemy;

    private Rigidbody2D myrigidbody2D; //to be able to move the player we need access to the rigidbody

	// Use this for initialization
	void Start () {
        myrigidbody2D = transform.parent.GetComponent<Rigidbody2D>(); //first thing we want is find the rigidbody on the parent (not the headstomper)
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        print(other.tag);

        if (other.gameObject.tag == "Enemy") //if an object with tag enemy
        {

            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive); //public int we add the dmg in he editor
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, bounceOnEnemy); //se we don't change the x value we want to keep it and we set value in the editor
            damageToGive =3;
            print("I hurt you");
        }
        

    }
}
