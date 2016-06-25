using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour
{

	public GameObject applePrefab;	// prefab for instantiating apples

	public float speed = 1f;	// speed at which the AppleTree moves in meters/second
	public float leftAndRightEdge = 10f;	// distance where AppleTree turns around
	public float chanceToChangeDirections = 0.1f;	// chance that the AppleTree will change directions
	public float secondsBetweenAppleDrops = 1f;	// rate at which apples will be instantiated

	void Start ()
	{
		// dropping apples every second
		InvokeRepeating ("DropApple", 2f, secondsBetweenAppleDrops);	// call new fx DropApple; 2f tells to wait 2 sec before the first time that it calls DropApple; secondsBetweenAppleDrops tells it to then call DropApple again every secondsBwnAppleDrops seconds thereafter
	}

	void DropApple()
	{
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}

	void Update ()
	{
		//basic movement
		Vector3 pos = transform.position;	// defines Vector3 pos to be the current position of the AppleTree
		pos.x += speed + Time.deltaTime;	// x of pos is increased by the speed * Time.deltaTime, measure of the # of seconds since the last frame
		transform.position = pos;	// moves AppleTree to a new position
		//changing direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed);	// move right
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);	// move left
		}
	}

	void FixedUpdate()
	{
		// changing direction randomly
		if (Random.value < chanceToChangeDirections) {
			speed *= -1;	// change direction
		}
	}
}





