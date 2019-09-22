using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImButt : ButtObj, IPointerDownHandler, IPointerUpHandler {
	public Sprite FalseIm;
	public Sprite TrueIm;

	public bool Switch;

	public bool OK;

	public void OnPointerDown(PointerEventData eventData){
		if (Source_Name != "") SourceCon.Play (Source_Name);
		if (!Switch) {
			OK = true;
			gameObject.GetComponent <Image> ().sprite = TrueIm;
		}
    }
	public void OnPointerUp(PointerEventData eventData){
		if (!Switch) {
			OK = false;
			gameObject.GetComponent <Image> ().sprite = FalseIm;
		} else {
			OK = !OK;
			gameObject.GetComponent <Image> ().sprite = OK ? TrueIm : FalseIm;
		}

		if (Del != null) {
			Del (gameObject);
		}
    }

	//=====================================================================================================
	[ContextMenu ("SetObj")]
	public void SetObj () {
		FalseIm = gameObject.GetComponent <Image> ().sprite;
	}

	[ContextMenu ("Reset")]
	public void Reset () {
		if (!Switch) {
			OK = false;
			gameObject.GetComponent <Image> ().sprite = FalseIm;
		} else {
			gameObject.GetComponent <Image> ().sprite = OK ? TrueIm : FalseIm;
		}
	}

	public void Reset (bool b) {
		OK = b;
		Reset ();
	}
}
