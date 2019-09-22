using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1_Obj_Start : ObjArray
{
    //出生左下角的座標是(-1000,600)
    //Y=7.5以上基本上就會觸發
    public G1_Obj [] G1_Obj; 

    IEnumerator Start()
    {
        for (;;)
        {
            yield return new WaitForSeconds (0.5f);
            Sp_Obj (Random.Range (0, 2) != 0, Random.Range (0, 2) != 0);
        }
    }

    public void Sp_Obj (bool LR, bool IsOK)
    {
        Vector3 StartPot = AllObj [LR ? 1 : 0].obj.transform.localPosition;
        int Y = IsOK ? Random.Range (8, 10) : Random.Range (3, 7);

        Vector3 Obj_v = new Vector2 (Random.Range (1, 11), Y);
        Obj_v.x *= LR ? -1 : 1;

        MyCalculate.SpObj (G1_Obj [Random.Range (0, G1_Obj.Length)].gameObject, transform, StartPot).GetComponent <G1_Obj> ().Open (Obj_v);
    }
}
