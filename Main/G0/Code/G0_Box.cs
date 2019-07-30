using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G0_Box : MonoBehaviour {

	public Tween_Position TwP;
	public Tween_Size TwS;

	public VoidDel End_Del;

	public void Open (Vector3 V3) {
		TwP.To = V3;
		TwP.Play (true);
		TwS.Play (true);
	}

	public void End () {
		StartCoroutine (_End ());
	}

	public IEnumerator _End () {
		if (End_Del != null) {
			End_Del ();
		}
		yield return null;
		Destroy (gameObject);
	}
}
