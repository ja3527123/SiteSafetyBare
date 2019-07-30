using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TimeLoop : MonoBehaviour {
	public Void_IntDel Del;
	public UnityEvent TheEvent;
	public float Delay;
	public float Time_F = 1;
	public int n;

	public bool IsOpen;//這個開關如果false就會暫停

	float Next_Time = 0;//當遊戲時間大於這個數時啟動判斷

	public void Open () {
		enabled = true;
		Load_Del ();
		Next_Time = Time.time + Delay + Time_F;
		IsOpen = true;
	}

	public void Reset () {
		StartCoroutine (_Reset ());
	}
	IEnumerator _Reset () {
		IsOpen = false;
		n = 0;
		yield return null;
		Open ();
	}

	void Update () {
		if (!IsOpen) return;
		if (Time.time > Next_Time) {
			n++;
			Load_Del ();
			Next_Time = Time.time + Time_F;
		}
	}

	public void Load_Del () {
		if(Del != null) Del(n);
		TheEvent.Invoke();
	}

	public void Test () {
		print (n);
	}
}
