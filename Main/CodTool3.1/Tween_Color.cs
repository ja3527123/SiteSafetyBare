using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tween_Color : Tween {
	public Color From = new Color (1,1,1);
	public Color To = new Color (1,1,1);

	public MaskableGraphic ColorObj;

	public Color NowColor;

	void Start () {
		if (ColorObj == null) ColorObj = GetComponent <MaskableGraphic> ();

		Del += (f) => {
			NowColor = From + (To - From) * f;
			if (ColorObj)
			{
				ColorObj.color = NowColor;
			}
		};
	}
}
