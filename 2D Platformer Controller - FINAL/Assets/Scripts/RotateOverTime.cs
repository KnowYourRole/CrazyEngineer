using UnityEngine;
using System.Collections;

public class RotateOverTime : MonoBehaviour {

    public float EnemyRotate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        EnemyRotate -= Time.deltaTime;

        if (EnemyRotate < 0)
        {
            
        }
    }
}
