using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

    private Vector3 posA; //starting position of the object

    private Vector3 posB;   //Ending position of the object

    private Vector3 nexPos; //desides which one is the next pos (posA or posB) so next pos should be = to next pos depending on last pos

    [SerialieField]
    public float speed; //speed of the object

    [SerialieField]
    public Transform childTransform; //The script is placed on the parent object so we make reference to the child object in the hierarchy 

    [SerialieField]
    public Transform transformB;  //here i make a reference to another child object that is going to be the next position
	// Use this for initialization
	void Start () {

        posA = childTransform.localPosition; //The A position
        posB = transformB.localPosition; //The b position
        nexPos = posB;  //pos A is the current pos so we need to move to pos B first

    }

    // Update is called once per frame
    void Update()
    {
        Move(); //executing the function
        
    }

    private void Move() //functions where the target should move from the first pos to the second pos
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime); //we give it the current pos and the target is the next pos moves by speed

        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1) //if the distance between current pos and the next pos is less or = to 0.1
        {
            ChangeDestination(); //we use function change destination
        }
    }

    private void ChangeDestination() //function that switch between next position A and next position B
    {
        nexPos = nexPos != posA ? posA : posB; //If next position isn't = to pos then we nee to move to posA or posB(moves to one of 2 options)based on the condition
    }                                          //If it's different than A it will move to A (and around)

    private void ChangeScale()  //scale the object 180 degrees
    {
        /*if(posB = true);
        transform.localScale = new Vector3(-1f, 1f, 1f);
        else if(posA = true)
        transform.localScale = new Vector3(1f, 1f, 1f);*/
    }


}
