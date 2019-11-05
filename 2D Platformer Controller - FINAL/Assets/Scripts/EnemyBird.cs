using UnityEngine;
using System.Collections;

public class EnemyBird : MonoBehaviour {

    public float horizontalSpeed; //deciamals
    public float verticalSpeed;
    public float amplitude;

    private Vector3 tempPosition;

    public GameObject pos01;
    public GameObject pos02;

	// Use this for initialization
	void Start () {
        tempPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //transform.position = new Vector3(Mathf.PingPong(Time.time, horizontalSpeed), pos01.transform.position.x, pos02.transform.position.x);
        //transform.position.x = comom.x;
        //tempPosition.x += horizontalSpeed;
        //tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        //transform.position = tempPosition;

        if (transform.position.x == pos01.transform.position.x) {
            tempPosition.x += horizontalSpeed;
        }else if (transform.position.x == pos02.transform.position.x) {
            tempPosition.x -= horizontalSpeed;
        }

        
    }
}
