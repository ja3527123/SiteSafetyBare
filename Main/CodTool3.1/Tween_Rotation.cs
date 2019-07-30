using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween_Rotation : Tween {
	public Vector3 From;
	public Vector3 To;

	void Start () {
		Del += (f) => {
			transform.localRotation = Quaternion.Euler (From + (To - From) * f);
		};
	}
}
