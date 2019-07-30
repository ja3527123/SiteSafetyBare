using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G0_LvUp : MonoBehaviour {
	[ContextMenu ("End")]
	public void End () {
		StartCoroutine (_End ());
	}
	public IEnumerator _End () {
		yield return null;
		Destroy (gameObject);
	}
}
