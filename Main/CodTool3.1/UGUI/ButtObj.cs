using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtObj : MonoBehaviour {

	public Void_GameObject Del;

	public string Source_Name;

	public void LoadOut () {
		Del += (GameObject g) => {
			Destroy (g);
		};
	}
	public void LoadClose () {
		Del += (GameObject g) => {
			g.SetActive (false);
		};
	}
}
