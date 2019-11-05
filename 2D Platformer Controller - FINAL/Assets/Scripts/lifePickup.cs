using UnityEngine;
using System.Collections;

public class lifePickup : MonoBehaviour {

    private LifeManager lifeSystem;

	// Use this for initialization
	void Start () {
        lifeSystem = FindObjectOfType<LifeManager>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            lifeSystem.GiveLife();
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
