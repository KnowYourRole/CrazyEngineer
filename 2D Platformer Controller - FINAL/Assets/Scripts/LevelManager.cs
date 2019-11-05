using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


    public GameObject currentCheckpoint;

    private PlayerController player;

    public GameObject deathParticle;    //adding reference to elements in unity that i can apply
    public GameObject respawnParticle;

    public int pointPenaltyOnDeath;

    public float respawnDelay;  //delay between respawn variable

    private new CameraController camera;

    private float gravityStore;

    public HealthManager healthManager;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();

        camera = FindObjectOfType<CameraController>();

        healthManager = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation); //It create copy of whatever object we deciede (deathParticle) we deciede where the player is where he gets killed
        player.enabled = false;             //when player dies he is not able to move
        player.GetComponent<Renderer>().enabled = false;    //making player invisible
        //gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        //player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        camera.isFollowing = false;
        ScoreManager.AddPoints(-pointPenaltyOnDeath); //or i can leave a whole value like -100 points or so
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //going 2 respawn player function, after the player is disabled and the visual is disabled
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        //player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        player.transform.position = currentCheckpoint.transform.position;
        player.knockbackCount = 0;  //we want when the player respawns to not get any knock so the game starts with 0 knock
        player.enabled = true;             //when player dies he is not able to move after player pos is reset
        player.GetComponent<Renderer>().enabled = true;    //making player invisible
        healthManager.FullHealth();
        healthManager.isDead = false;
        camera.isFollowing = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);   //this is what handles death and coming back 2 life
    }

}
