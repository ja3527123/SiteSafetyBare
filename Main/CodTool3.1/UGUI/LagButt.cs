using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LagButt : ButtObj, IPointerDownHandler, IPointerUpHandler {
	public float F = 5;
	public bool OK;
	float StartF;

	public void OnPointerDown(PointerEventData eventData){
		StartF = Time.time;
		OK = true;
  }
	public void OnPointerUp(PointerEventData eventData){
		OK = false;
  }

	void Update () {
		if (OK && (StartF + F) < Time.time) {
			if (Del != null) Del (gameObject);
			OK = false;
		}
	}
}
