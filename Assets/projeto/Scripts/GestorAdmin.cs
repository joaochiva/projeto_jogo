using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestorAdmin : MonoBehaviour
{

	public InputField text;

	public void acao()
	{
		Debug.Log(text.text);
	}

	
}
