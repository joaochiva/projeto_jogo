using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncherView : MonoBehaviour
{
	public GameObject prefab; // This is our prefab object that will be exposed in the inspector

	public int numberToCreate; // number of objects to create. Exposed in inspector

	void Start()
	{
		Populate();
	}

	void Update()
	{

	}

	void Populate()
	{
		for (int i = 0; i < numberToCreate; i++)
		{
			// Create new instances of our prefab until we've created as many as we specified
			_ = Instantiate(prefab, transform);

			// Randomize the color of our image
			//newObj.GetComponent().color = Random.ColorHSV();
		}

	}
}
