using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G2_Card_Obj : MonoBehaviour
{
    public Image B_Im_Obj;
    public Image Im_Obj;
    public Tween_Size Tween;
    public Tween_Alpha Tween_A;
    public ButtObj Button;

    public G2_Card_Data [] All_Im;
    public Sprite [] B_Im;

    public int ID;
    public bool IsOpen;

    //public Action <bool, G2_Card_Obj> Button_Event;
    //public Action <bool, G2_Card_Obj> _Button_Event;

    void Start ()
    {
        // Button.Del += (g) => {
        //     StartCoroutine (Open (!IsOpen));
        // };
    }

    public void Initial (int ID)
    {
        this.ID = ID;
    }

    public IEnumerator Open (G2_Card_Obj A, G2_Card_Obj B, bool OK)
    {
        yield return Open ();
        yield return new WaitForSeconds (1f);
        if(OK)
        {
            A.Tween_A.Play (true);
            B.Tween_A.Play (true);
        }
        else
        {
            StartCoroutine (A.Close ());
            StartCoroutine (B.Close ());
        }
    }

    public IEnumerator Open ()
    {
        IsOpen = true; 

        B_Im_Obj.raycastTarget = false;

        yield return Tween.IE_Play (true);
        yield return new WaitForSeconds (0.2f);
        Reset ();
        yield return Tween.IE_Play (false);
    }
    public IEnumerator Close ()
    {
        IsOpen = false;

        yield return Tween.IE_Play (true);
        yield return new WaitForSeconds (0.2f);
        Reset ();
        yield return Tween.IE_Play (false);

        B_Im_Obj.raycastTarget = true;
    }



    [ContextMenu ("Reset")]
    public void Reset ()
    {
        if (!IsOpen)
        {
            B_Im_Obj.sprite = B_Im [0];
            Im_Obj.enabled = false;
        }
        else
        {
            B_Im_Obj.sprite = B_Im [1];
            Im_Obj.sprite = All_Im [ID];
            Im_Obj.enabled = true;
        }
    }

    public void Reset (int ID)
    {
        this.ID = ID;
        Reset ();
    }
}

[Serializable]
public class G2_Card_Data
{
    public string Name;
    public Sprite Im;

    static public implicit operator Sprite (G2_Card_Data t)
    {
        return t.Im;
    }
    static public implicit operator string (G2_Card_Data t)
    {
        return t.Name;
    }
}
