using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2_Card_UI : ObjArray
{
    public DiceInt Im_Dice;
    public DiceInt Card_Dice;
    public P_Bar Time_Bar;

    public int [] IDs;
    public int [] Card_Nob;

    public G2_Card_Obj Card_A;
    public G2_Card_Obj Card_B;

    public float Time_L = 60;

    public int OpenCard = 8;

    IEnumerator Start ()
    {
        IDs = Im_Dice.GetATs_NotRepeating ();
        Card_Nob = Card_Dice.GetATs_NotRepeating ();

        for (int i = 0; i < AllObj.Length; i++)
        {
            G2_Card_Obj obj = GetObjT <G2_Card_Obj> (Card_Nob [i]);
            obj.Initial (IDs [i / 2]);
            obj.Button.Del += (g) =>
            {
                if (!Card_A)
                {
                    Card_A = obj;

                    obj.StartCoroutine (obj.Open ());
                }
                else if (!Card_B)
                {
                    Card_B = obj;
                    //因為攜程過程會把物件變成null所以再創造一個物件來裝
                    G2_Card_Obj A = Card_A;
                    G2_Card_Obj B = Card_B;
                    if (Card_A.ID == Card_B.ID)
                    {
                        print ("對");
                        Time_L += G2_MainUI._.Game_P.AddScore;
                        obj.StartCoroutine (obj.Open (A, B, true));
                        OpenCard--;
                    }
                    else
                    {
                        print ("錯");
                        Time_L -= G2_MainUI._.Game_P.SubScore;
                        obj.StartCoroutine (obj.Open (A, B, false));
                    }
                    
                    Card_A = null;
                    Card_B = null;
                }
            };
        }

        Time_L = G2_MainUI._.Game_P.Time;
        for(;;)
        {
            yield return null;
            Time_L -= Time.deltaTime;
            Time_Bar.End_F = Time_L / G2_MainUI._.Game_P.Time;
            if (Time_L <= 0)
            {
                print ("時間到 結束");
                StartCoroutine (End (0));
                break;
            }
            else if (OpenCard <= 0)
            {
                print ("挑戰完成還剩" + Time_L + "秒");
                StartCoroutine (End (Time_Bar.End_F));
                break;
            }
        }
    }

    IEnumerator End (float Time_F = 0)
    {
        yield return new WaitForSeconds (3);
        G2_MainUI._.CardTime_F = Time_F;
        G2_MainUI._.UI.Card_UI.gameObject.SetActive (false);
        G2_MainUI._.UI.QA_UI.gameObject.SetActive (true);
    }
}
