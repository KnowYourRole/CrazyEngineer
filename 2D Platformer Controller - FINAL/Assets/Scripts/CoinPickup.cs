using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

    public int pointsToAdd;
    

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null) //it gets triggered by object with player controller
            return;     //if it doesn't has the script it returns null

        ScoreManager.AddPoints(pointsToAdd);

        Destroy(gameObject);
    }
	
	
}
