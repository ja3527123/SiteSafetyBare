using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceImage : Dice <Sprite> {

	[ContextMenu("test")]
	void Test () {
		for(int i = 0;i < 1000;i++){
			print (GetAInt());
		}
	}
}
