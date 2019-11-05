using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

    public int damageToGive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);



            var player = other.GetComponent<PlayerController>();  //so the variable player is = to the player controller script that is attached to our player
            player.knockbackCount = player.knockbackLength;

            if (other.transform.position.x < transform.position.x) //so we need to know if the player or the other is from the left or from the right
                player.knockFromRight = true;   //so if player x axis is less than enemy x axsis, the player is from the left side of the enemy, after that we activate knock from right and the player gets knocked
            else
                player.knockFromRight = false;
        }
    }

}
