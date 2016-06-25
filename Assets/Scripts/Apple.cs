using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour
{

	public static float bottomY = -20f;	// every instance of Apple will have the same value of bottomY

	void Update ()
	{
		if (transform.position.y < bottomY)
		{
			// this script refers to the current instance of the Apple class, not the entire GameObject
			Destroy (this.gameObject);	// removes things that are passed into it from the game and can be used to destroy both components and GameObjects
		}
	}
}