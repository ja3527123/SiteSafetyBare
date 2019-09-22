using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1_PlayUI : MonoBehaviour
{
    [Serializable]
    public struct _UI
    {
        public G1_Obj_Start Obj_Start;
        public G1_UserUI UserUI;
        public G1_HPBar HPBar;
    }
    public _UI UI;

    float StartTime;

    void Start ()
    {
        StartTime = Time.time;

        UI.HPBar.ZeroDel += () =>
        {
            G1_MainUI._.UI.EndUI.Open (G1_MainUI._.Score);
        };
        UI.HPBar.Open (G1_MainUI._.Game_P.Max_HP);
    }

    public void Open (int Sex)
    {
        UI.UserUI.Reset (0, Sex);

        gameObject.SetActive (true);
    }
}