using UnityEngine;
using System.Collections;

public class BackForth : MonoBehaviour {

	//these are the two positions that you bird glides between
	public Transform pos01;
	public Transform pos02;

	//this is the speed of the bird
	public float speed;

	//this is the place that the bird is currently gliding towards
	Transform curPlace;

	//this is the animation object that needs to be flipped
	public GameObject Bird;

	// Use this for initialization
	void Start () {
		//this sets the animation object that needs to be flipped
		Bird = transform.GetChild(0).gameObject;
		//this sets the first place that our object needs to fly to
		curPlace = pos02;
	}
	
	// Update is called once per frame
	void Update () {

		//this resets where the bird needs to fly to once it reaches the first point
		if (transform.position.x == pos01.position.x) {
			
			//this sets the point
			curPlace = pos02;

			//this resets the scale of the bird
			Bird.transform.localScale = new Vector3 (1, 1, 1);

		} else if(transform.position.x == pos02.position.x){
			
			//this sets the point
			curPlace = pos01;

			//this resets the scale of the bird
			Bird.transform.localScale = new Vector3 (-1, 1, 1);
		}

		//this makes sure that the bird is always in motion
		transform.position = Vector3.MoveTowards(transform.position, curPlace.position, speed * Time.deltaTime);
	}
}
