using UnityEngine;
using System.Collections;

public class DiceGameObject : Dice<GameObject> {
	[ContextMenu("test")]
	void test ()
	{
		for(int i = 0;i < 100;i++){
			print(GetAInt());
		}
	}
}
