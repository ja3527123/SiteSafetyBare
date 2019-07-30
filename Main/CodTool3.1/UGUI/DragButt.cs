using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragButt : ButtObj, IPointerDownHandler, IPointerUpHandler,IDragHandler {
	public Vector3 Start_V3, End_V3;
	public Vector3 Drag_V3 {
		get {
			return End_V3 - Start_V3;
		}
	}
	public Void_Vector3Del Start_Del, Update_Del, End_Del;

	public void OnPointerDown(PointerEventData eventData){
		if (Source_Name != "") SourceCon.Play (Source_Name);
		Start_V3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		End_V3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (Start_Del != null) Start_Del (Start_V3);
  }
	public void OnDrag(PointerEventData eventData){
		// print (Camera.main.ScreenToWorldPoint (Input.mousePosition));
		End_V3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (Update_Del != null) Update_Del (End_V3);
  }
	public void OnPointerUp(PointerEventData eventData){
		if (End_Del != null) End_Del (End_V3);
  }

	public Vector3 GetLocalV3 (Vector3 V3) {
		return (V3 - transform.parent.position) / transform.parent.lossyScale.x;
	}
}