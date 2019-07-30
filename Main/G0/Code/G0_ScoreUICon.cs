using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class G0_ScoreUICon : ScoreCon
{
    public ObjArray NobObj;
    public GameObject ScoreUI;
    public GameObject PeopleUI;
    public GameObject PUI;

    public ButtObj HomeButt;
    public ButtObj ResetButt;

    void Start ()
    {
        HomeButt.Del += (g) => 
        {
            print ("回首頁");
        };
        ResetButt.Del += (g) => 
        {
            SceneManager.LoadScene ("G0");
        };
    }

    public int TestN = 100;
    [ContextMenu ("test")]
    public void Open_Test ()
    {
        Open (TestN);
    }

    public void Open (int N)
    {
        Score = N;
        LoadData ();
        float [] f = SetOrder_Text ();
        SaveData ();
        SetScore  ((int)f [0]);
        SetPeople ((int)f [1]);
        SetP      ((int)f [2]);

        gameObject.SetActive (true);
    }

    public void SetScore (int N)
    {   
        if (N == 0)
        {
            MyCalculate.SpObj (NobObj.AllObj [0].obj, ScoreUI.transform, Vector3.zero);
            return;
        }
        for (;N >= 1;)
        {
            MyCalculate.SpObj (NobObj.AllObj [N % 10].obj, ScoreUI.transform, Vector3.zero);
            N /= 10;
        }
    }
    public void SetPeople (int N)
    {
        if (N == 0)
        {
            MyCalculate.SpObj (NobObj.AllObj [0].obj, PeopleUI.transform, Vector3.zero);
            return;
        }
        for (;N >= 1;)
        {
            MyCalculate.SpObj (NobObj.AllObj [N % 10].obj, PeopleUI.transform, Vector3.zero);
            N /= 10;
        }
    }
    public void SetP (int N)
    {
         if (N == 0)
        {
            MyCalculate.SpObj (NobObj.AllObj [0].obj, PUI.transform, Vector3.zero);
            return;
        }
        for (;N >= 1;)
        {
            MyCalculate.SpObj (NobObj.AllObj [N % 10].obj, PUI.transform, Vector3.zero);
            N /= 10;
        }
    }
}
