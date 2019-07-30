using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween_Size : Tween {
	public Vector3 From;
	public Vector3 To;

	void Start () {
		Del += (f) => {
			transform.localScale = From + (To - From) * f;
		};
	}
}
