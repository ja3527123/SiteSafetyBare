using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBar : MonoBehaviour {

	public ButtObj [] Butts;

	public int Nob;
	public Void_IntDel  BarDel;

	public virtual void Start () {
		for (int i = 0; i < Butts.Length; i++) {
			int _i = i;
			Butts [i].Del += (g) => {
				Open (_i);
			};
		}
	}

	public void Open (int n) {
		Nob = n;
		if (BarDel != null) BarDel (Nob);
	}
}
