using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour {
    //the purpose of this script is to check if the particle system is still playing 

    private ParticleSystem thisParticleSystem;


	// Use this for initialization
	void Start ()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (thisParticleSystem.isPlaying)
            return;     //we don't want this code to do anything if it's playing

        Destroy(gameObject);

	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
