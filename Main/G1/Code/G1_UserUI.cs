using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1_UserUI : ObjArray
{
    public Tween_Position Tw_P;

    public int Mod;
    public int Sex;

    [ContextMenu ("Reset")]
    public void Reset ()
    {
        OnOnlyObjs (Mod);
        GetObjT <ObjArray> (Mod).OnOnlyObjs (Sex);
    }

    public void Reset (int Mod)
    {
        this.Mod = Mod;
        Reset ();
    }

    public void Reset (int Mod, int Sex)
    {
        this.Sex = Sex;
        Reset (Mod);
    }

    public void Hit ()
    {
        if (Hit_Obj != null)
        {
            StopCoroutine (Hit_Obj);
        }
        Hit_Obj = _Hit ();
        StartCoroutine (Hit_Obj);
    }

    IEnumerator Hit_Obj;
    public IEnumerator _Hit ()
    {
        Reset (1);
        Tw_P.f = 0;
        yield return Tw_P.IE_Play (true);
        Reset (0);
    }
}
