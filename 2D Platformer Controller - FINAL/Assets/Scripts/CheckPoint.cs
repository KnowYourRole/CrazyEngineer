using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    public LevelManager levelManager;  //Empty levelmanager of the type levelmanager
                                       // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();  //finds any objects in the scene that have level manager script attached to it
    }

    // Update is called once per frame
    void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
            Debug.Log("Activated Checkpoint" + transform.position);
        }
    }
}
