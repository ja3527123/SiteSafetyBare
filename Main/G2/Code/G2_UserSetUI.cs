using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2_UserSetUI : MonoBehaviour
{
    [Serializable]
	public struct _UI
	{
		public G2_ButtonBar SexButton;
        public ObjArray User;
        public ButtObj EndButton;
	}
    public _UI UI;

    public int Sex => UI.SexButton.Nob;
    void Start ()
    {
        UI.SexButton.BarDel += (n) =>
        {
            UI.User.OnOnlyObjs (n);
        };
        UI.EndButton.Del += (g) =>
        {
            G2_MainUI._.UI.Card_UI.gameObject.SetActive (true);
            G2_MainUI._.UI.Sex.OnOnlyObjs (UI.SexButton.Nob);
            gameObject.SetActive (false);
        };
    }
}
