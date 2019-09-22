using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class G2_Set_P : MonoBehaviour
{
    public G2_Game_P Game_P;
    public Set_PUI [] Set_PUIs;
    public ButtObj OKButt;

    public string Key = "G2_P";

    void Start()
    {
        string Json = PlayerPrefs.GetString (Key, "");
        if (Json != "")
        {
            Game_P = JsonUtility.FromJson <G2_Game_P> (Json);
        } else {
            print ("沒記錄");
        }
        Set_PUIs [0].Del += (f) =>
        {
            Game_P.Time = (int)f;
        };
        Set_PUIs [1].Del += (f) =>
        {
            Game_P.AddScore = (int)f;
        };
        Set_PUIs [2].Del += (f) =>
        {
            Game_P.SubScore = (int)f;
        };
        Set_PUIs [3].Del += (f) =>
        {
            Game_P.QA_Count = (int)f;
        };

        OKButt.Del += (g) =>
        {
            PlayerPrefs.SetString (Key, JsonUtility.ToJson (Game_P));
            SceneManager.LoadScene ("G2");
        };

        Open ();
    }

    [ContextMenu ("Open")]
    public void Open ()
    {
        Set_PUIs [0].P = Game_P.Time;
        Set_PUIs [1].P = Game_P.AddScore;
        Set_PUIs [2].P = Game_P.SubScore;
        Set_PUIs [3].P = Game_P.QA_Count;

        gameObject.SetActive (true);
    }

    [ContextMenu ("Delete")]
    public void Delete ()
    {
        PlayerPrefs.DeleteKey (Key);
    }
}
[Serializable]
public class G2_Game_P
{
    public int Time = 30;
    public float AddScore = 2;
    public float SubScore = 2;
    public int QA_Count = 3;
}