using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class G1_MainUI : MonoBehaviour
{
    static public G1_MainUI _;

	[Serializable]
	public struct _UI
	{
		public G1_UserSetUI UserSetUI;
        public G1_PlayUI PlayUI;
        public G_ScoreUICon EndUI;
	}
    public _UI UI;

    public G1_Game_P Game_P;

    float StartTime;

    public float f
    {
        get
        {
            float f = 1 - (Time.time - StartTime) / Game_P.Time;
            return Mathf.Clamp (f, 0, 1);
        }
    }
    public float NowTime_Length
    {
        get
        {
            float v = Game_P.Min_Obj_Time_Length + (Game_P.Max_Obj_Time_Length - Game_P.Min_Obj_Time_Length) * f;
            return v;
        }
    }

    void Awake ()
    {
        string G1_P = PlayerPrefs.GetString ("G1_P", "");
		if (G1_P != "")
		{
			Game_P = JsonUtility.FromJson <G1_Game_P> (G1_P);
		}
        _ = this;
    }

    void Start ()
    {
        StartTime = Time.time;
    }
}