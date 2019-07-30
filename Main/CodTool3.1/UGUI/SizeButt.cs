using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SizeButt : ButtObj, IPointerDownHandler, IPointerUpHandler {
	public RectTransform Obj;

	public enum SizeType {Scale, Rect};
	public SizeType sizeType;
	public Vector3 OpenSize = Vector3.one * 1.1f;
	public Vector3 CloseSize = Vector3.one;

	

	public void OnPointerDown(PointerEventData eventData){
		if (Source_Name != "") SourceCon.Play (Source_Name);
		SetSize (true);
    }
	public void OnPointerUp(PointerEventData eventData){
		SetSize (false);
		if (Del != null) Del (gameObject);
    }
	
	public void SetSize (bool b) {
		switch (sizeType) {
			case SizeType.Scale :
				if (b) {
					Obj.localScale = OpenSize;
				} else {
					Obj.localScale = CloseSize;
				}
				break;
			case SizeType.Rect :
				if (b) {
					Obj.sizeDelta = OpenSize;
				} else {
					Obj.sizeDelta = CloseSize;
				}
				break;
		}
	}

//=====================================================================================================
	[ContextMenu ("SetObj_Scale")]
	public void SetObj_Scale () {
		sizeType = SizeType.Scale;
		if (Obj == null) Obj = gameObject.GetComponent <RectTransform> ();
		CloseSize = Obj.transform.localScale;
		OpenSize = CloseSize * 1.1f;
	}

	[ContextMenu ("SetObj_Rect")]
	public void SetObj_Rect () {
		sizeType = SizeType.Rect;
		if (Obj == null) Obj = gameObject.GetComponent <RectTransform> ();
		CloseSize = Obj.sizeDelta;
		OpenSize = CloseSize * 1.1f;
	}
}