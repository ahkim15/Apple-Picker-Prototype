using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour
{

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;

	void Start ()
	{
		basketList = new List<GameObject> ();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}
	}

	public void AppleDestroyed()
	{
		// destroy all of the falling Apples
		GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag("Apple");
		foreach (GameObject tGO in tAppleArray)
		{
			Destroy (tGO);
		}
		// destroy one of the baskets
		// get the index of the last basket in basketList
		int basketIndex = basketList.Count - 1;
		// get a reference to that basket GameObject
		GameObject tBasketGO = basketList [basketIndex];
		// remove the basket from the list and destroy the GameObject
		basketList.RemoveAt (basketIndex);
		Destroy (tBasketGO);

		// restart the game, which doesn't affect HighScore.score
		if (basketList.Count == 0)
		{
			Application.LoadLevel ("_Scene_0");	// will reload scene _Scene_0, resets the game to its beginning state
		}
	}
}