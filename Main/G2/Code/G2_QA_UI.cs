using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G2_QA_UI : MonoBehaviour
{
    public G2_Card_Obj Obj;
    public ButtObj [] Butts;
    public DiceInt Dice;

    //有幾題加分題
    public int MaxQA => G2_MainUI._.Game_P.QA_Count;

    public int [] QAIDs;
    public Sprite OK_Button_Im;

    public int n;
    public int Score = 0;

    public void Start ()
    {
        QAIDs = Dice.GetATs_NotRepeating();
        LoadData (QAIDs [0]);
    }

    public void LoadData (int Index)
    {
        Obj.Reset (Index);

        int A = Random.Range (0, 2);
        int Un_Data = (Index + Random.Range (1, Obj.All_Im.Length)) % Obj.All_Im.Length;

        const string ABCD = "ABCD";
        for (int i = 0; i < Butts.Length; i++)
        {
            Butts [i].GetComponent <Image> ().sprite = Butts [i].GetComponent <ImButt> ().FalseIm;
            if (i == A)
            {
                Butts [i].GetComponentInChildren <Text> ().text = $"{ABCD[i]}.{Obj.All_Im[Index].Name}";
                Butts [i].Del = (g) =>
                {
                    Button_Event (true, g);
                };
            }
            else
            {
                Butts [i].GetComponentInChildren <Text> ().text = $"{ABCD[i]}.{Obj.All_Im[Un_Data].Name}";
                Butts [i].Del = (g) =>
                {
                    Button_Event (false, g);
                };
            }
            Butts [i].GetComponent <Image> ().raycastTarget = true;
        }
    }

    public void Button_Event (bool b, GameObject g)
    {
        if (b)
        {
            Score++;
            g.GetComponent <Image> ().sprite = OK_Button_Im;
            print ("對");
        }
        else
        {
            print ("錯");
        }

        for (int i = 0; i < Butts.Length; i++)
        {
            Butts [i].GetComponent <Image> ().raycastTarget = false;
        }
        StartCoroutine (_Button_Event ());
    }
    public IEnumerator _Button_Event ()
    {
        yield return new WaitForSeconds (1);
        n++;
        if (n < MaxQA)
        {
            LoadData (QAIDs [n]);
        }
        else
        {
            G2_MainUI._.QAScroce_F = (float)Score / MaxQA;
            G2_MainUI._.UI.End_UI.Open ((int)G2_MainUI._.Score);
            print ("結束 分數:" + G2_MainUI._.Score);
        }
    }
}
