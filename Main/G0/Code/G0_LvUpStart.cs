using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G0_LvUpStart : MonoBehaviour {

	public DiceGameObject LVUpDice;
	public GameObject [] LvUpObjs;

	public void OpenLvUp (int Lv) {
		GameObject g = MyCalculate.SpObj (LvUpObjs [Lv], transform , LVUpDice.GetAT ().transform.localPosition);
		g.name = "LvUp_" + Lv;
	}
}
