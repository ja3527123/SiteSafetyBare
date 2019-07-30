using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDragButt : DragButt {

	public Vector3 F_V3;//按下時手指與按鈕之間的位置差

	public void Start () {
		Start_Del += (V3) => {
			F_V3 = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		};
		Update_Del += (V3) => {
			transform.position = Start_V3 + Drag_V3 - F_V3;
		};
	}
}
