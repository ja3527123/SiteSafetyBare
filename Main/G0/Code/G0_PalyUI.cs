using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G0_PalyUI : MonoBehaviour {

	[Serializable]
	public struct _UI {
		public DragButt d;
		public GameObject T;

		public G0_BoxStart BoxStart;
		public ObjArray BoxEnd;

		public G0_LvUpStart LVUpStart;

		public P_Bar Time_Bar;
		public P_Bar HP_Bar;
		public ObjArray Reset;
		public ImNobBar Sceor_Bar;
	}
	public _UI UI;
	public GameObject [] Nobs;
	public GameObject [] Users;
	public G0_UserPlayUICon Now_User;

	public Vector2 Now_TPot;

	void Start () {
		UI.d.Start_Del += (v) => {
			UI.d.Update_Del (v);	
		};
		UI.d.Update_Del += (v) => {
			UI.T.transform.position = v;
			Now_TPot = UI.T.transform.localPosition;
		};
		
		Now_User = MyCalculate.SpObj (Users [G0_MainUI._.UI.UserSet.UI.SexButt.Nob] , transform , Vector3.one).GetComponent <G0_UserPlayUICon> ();
	}

	public void SpImNob (Vector3 v3,int Lv , int n) {
		MyCalculate.SpObj (Nobs [Lv], transform, v3).GetComponent <Mobe_Nob> ().Open (n);
	}
}
