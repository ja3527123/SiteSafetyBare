using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1_UserSetUI : MonoBehaviour
{
    [Serializable]
	public struct _UI
	{
		public G1_ButtonBar SexButton;
        public ObjArray User;
        public ButtObj EndButton;
	}
    public _UI UI;

    public int Sex
    {
        get
        {
            return UI.SexButton.Nob;
        }
    }

    void Start ()
    {
        UI.SexButton.BarDel += (n) =>
        {
            UI.User.OnOnlyObjs (n);
        };
        UI.EndButton.Del += (g) =>
        {
            G1_MainUI._.UI.PlayUI.Open (Sex);
            gameObject.SetActive (false);
        };
    }
}
