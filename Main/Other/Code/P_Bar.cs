using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Bar : MonoBehaviour {

	public Image P;
	public float MaxL;
	public float MinL;
	public enum _WH {W , H}
	public _WH WH;

	[Range(0, 1)]
	public float End_F;
	public float Now_F {
		get {
			float F = WH == _WH.W ? P.rectTransform.rect.width : P.rectTransform.rect.height;
			return (F - MinL) / (MaxL - MinL);
		}
		set {
			Vector2 R = P.rectTransform.sizeDelta;
			if (WH == _WH.W) {
				R.x = MinL + (MaxL - MinL) * value;
			} else {
				R.y = MinL + (MaxL - MinL) * value;
			}
				P.rectTransform.sizeDelta = R;
		}
	}

	void Update () {
		float D_F = End_F - Now_F;
		if (D_F > 0.001f || D_F < -0.001f) {
			Now_F += D_F / 5;
		}
		
	}

	[ContextMenu ("Reset")]
	public void Reset () {
		Now_F = End_F;
	}
}
