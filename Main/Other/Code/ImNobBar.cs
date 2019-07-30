using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImNobBar : MonoBehaviour {
	public ObjArray [] Nobs;

	public void LoadInt (int n) {
		string n_String = n.ToString ();
		for (int i = 0; i < Nobs.Length; i++) {
			if (i >= n_String.Length) {
				Nobs [i].OnOffAll (false);
			} else {
				SetNob (Nobs [i] , n_String [i]);
			}
		}
	}

	void SetNob (ObjArray OA, char N_String) {
		switch (N_String) {
			case '0' :
			OA.OnOnlyObjs (0);
			break;
			case '1' :
			OA.OnOnlyObjs (1);
			break;
			case '2' :
			OA.OnOnlyObjs (2);
			break;
			case '3' :
			OA.OnOnlyObjs (3);
			break;
			case '4' :
			OA.OnOnlyObjs (4);
			break;
			case '5' :
			OA.OnOnlyObjs (5);
			break;
			case '6' :
			OA.OnOnlyObjs (6);
			break;
			case '7' :
			OA.OnOnlyObjs (7);
			break;
			case '8' :
			OA.OnOnlyObjs (8);
			break;
			case '9' :
			OA.OnOnlyObjs (9);
			break;
			default :
			OA.OnOffAll (false);
			break;
		}
	}

	[ContextMenu ("Reset")]
	public void Reset () {
		for (int i = 0; i < Nobs.Length; i++) {
			Nobs [i].OnOffAll (false);
		}
	}

	[ContextMenu ("test")]
	public void test () {
		LoadInt (1234);
	}
}
