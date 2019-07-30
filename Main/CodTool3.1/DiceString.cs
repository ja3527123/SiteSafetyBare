using UnityEngine;
using System.Collections;

public class DiceString : Dice<string> {
	[ContextMenu("test")]
	void Test () {
		for(int i = 0;i < 1000;i++){
			print (GetAInt());
		}
	}
}
