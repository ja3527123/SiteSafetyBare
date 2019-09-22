using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2_MainUI : MonoBehaviour
{
    static public G2_MainUI _;

	[Serializable]
	public struct _UI
	{
		public G2_UserSetUI UserSetUI;
        public G2_Card_UI Card_UI;
        public G2_QA_UI QA_UI;
        public G_ScoreUICon End_UI;

        public ObjArray Sex;
	}
    public _UI UI;

    public G2_Game_P Game_P;

    //完成卡片挑戰時還剩多少時間
    public float CardTime_F;
    public float QAScroce_F;

    public float Score => 80 * CardTime_F + 20 * QAScroce_F;

    void Awake ()
    {
        string G2_P = PlayerPrefs.GetString ("G2_P", "");
		if (G2_P != "")
		{
            print (G2_P);
			Game_P = JsonUtility.FromJson <G2_Game_P> (G2_P);
		}
        _ = this;
    }
}
