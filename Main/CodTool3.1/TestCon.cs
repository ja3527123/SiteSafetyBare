using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TestCon : MonoBehaviour {
	//純粹就是拿來給人測試用的腳本
	public UnityEvent [] Events;

	IEnumerator Start () {
		for (int i = 0; i < Events.Length; i++) {
			Events [i].Invoke ();
			yield return new WaitForSeconds (1);
		}
	}

	public void Print (string text) {
		print (text);
	}
}
