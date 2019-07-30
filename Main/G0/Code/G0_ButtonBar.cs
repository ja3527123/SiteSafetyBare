using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G0_ButtonBar : ButtonBar {

	public override void Start () {
		base.Start ();
		BarDel += (n) => {
			for (int i = 0; i < Butts.Length; i++) {
				if (n != i) {
					Butts [i].GetComponent <Image> ().raycastTarget = true;
					Butts [i].GetComponent <ImButt> ().Reset (false);
				} else {
					Butts [i].GetComponent <Image> ().raycastTarget = false;
				}
			}
		};
	}
}
