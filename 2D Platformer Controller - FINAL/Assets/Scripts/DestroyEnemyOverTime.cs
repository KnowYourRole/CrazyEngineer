using UnityEngine;
using System.Collections;

public class DestroyEnemyOverTime : MonoBehaviour {

    public float lifetime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;

        if(lifetime < 0)
        {
            //transform.rotation.y += 180;
        }
	}
}
