using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G0_BoxStart : DiceGameObject {

	public GameObject Box;

	[ContextMenu ("OpenBox")]
	public void OpenBox () {
		int n = GetAInt ();

		if (n < 0) {
			// print ("所有箱子都生成了");
			return;
		}

		G0_Box _Box = MyCalculate.SpObj (Box , transform , Vector3.one).GetComponent <G0_Box> ();
		_Box.End_Del += () => {AllInt [n] = 1;};
		_Box.Open (AllT [n].transform.localPosition);
		AllInt [n] = 0;
	}
}
