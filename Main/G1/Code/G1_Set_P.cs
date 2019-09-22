using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class G1_Set_P : MonoBehaviour
{
    public G1_Game_P Game_P;
    public Set_PUI [] Set_PUIs;
    public ButtObj OKButt;

    public string Key = "G1_P";

    void Start ()
    {
        string Json = PlayerPrefs.GetString (Key, "");
        if (Json != "")
        {
            Game_P = JsonUtility.FromJson <G1_Game_P> (Json);
        } else {
            print ("沒記錄");
        }

        Set_PUIs [0].Del += (f) =>
        {
            Game_P.Max_HP = (int)f;
        };
        Set_PUIs [1].Del += (f) =>
        {
            Game_P.Max_Obj_Time_Length = f;
        };
        Set_PUIs [2].Del += (f) =>
        {
            Game_P.Min_Obj_Time_Length = f;
        };
        Set_PUIs [3].Del += (f) =>
        {
            Game_P.Time = (int)f;
        };

        OKButt.Del += (g) =>
        {
            PlayerPrefs.SetString (Key, JsonUtility.ToJson (Game_P));
            SceneManager.LoadScene ("G1");
        };

        Open ();
    }

    [ContextMenu ("Open")]
    public void Open ()
    {
        Set_PUIs [0].P = Game_P.Max_HP;
        Set_PUIs [1].P = Game_P.Max_Obj_Time_Length;
        Set_PUIs [2].P = Game_P.Min_Obj_Time_Length;
        Set_PUIs [3].P = Game_P.Time;

        gameObject.SetActive (true);
    }

    [ContextMenu ("Delete")]
    public void Delete ()
    {
        PlayerPrefs.DeleteKey (Key);
    }
}

[Serializable]
public class G1_Game_P
{
    public int Max_HP = 3;
    public float Max_Obj_Time_Length = 3f;
    public float Min_Obj_Time_Length = 0.5f;
    public int Time = 60;
}

// [Serializable]
// public class G1_Game_P
// {
//     // static public G0_Game_P _;
// 	public int Max_Time = 60;//開場時從幾秒開始倒數
// 	public int [] Time_Up = new int [] {50, 50};//升級時回覆多少時間
// 	public int Max_HP = 200;//健康值
// 	public int HP_Dom_Speed = 20;//每秒會降低多少健康值
// 	public int HP_Up_Speed = 50;//每秒會回覆多少健康值
// 	public int [] Speed = new int [] {20, 25, 30};//玩家每個狀態的移動速度
// }