using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    private bool PlayerInZone;

    public string WinGame;

	// Use this for initialization
	void Start () {
        PlayerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetAxisRaw ("Jump") > 0 && PlayerInZone)
        {
            Application.LoadLevel(WinGame);
        }
	}
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.name == "Player")
        {
            PlayerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            PlayerInZone = false;
        }
    }
}
