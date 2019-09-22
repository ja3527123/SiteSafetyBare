using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1_HPBar : ObjArray
{
    public int MaxHP {
        get
        {
            return AllObj.Length;
        }
    }
    public int HP
    {
        get
        {
            return _HP;
        }
        set
        {
            value = Mathf.Clamp (value, 0, MaxHP);
            if (HP == value) return;

            for (int i = 0; i < AllObj.Length; i++)
            {
                GetObjT <ObjArray> (i).OnOnlyObjs (i < value ? 0 : 1);
            }
            _HP = value;
            if (ZeroDel != null && _HP <= 0)
            {
                ZeroDel ();
            }
        }
    }
    public int _HP;
    public GameObject HPObj;

    public VoidDel ZeroDel;

    public void Open (int MaxHP)
    {
        for (int i = 1; i < MaxHP; i++)
        {
            MyCalculate.SpObj (HPObj, transform, Vector3.zero, i.ToString ());
        }
        SetObj ();
        HP = MaxHP;
    }

    [ContextMenu ("OpenTest")]
    public void OpenTest ()
    {
        Open (3);
    }
}
