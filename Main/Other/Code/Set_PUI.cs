using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_PUI : MonoBehaviour
{
    public ButtObj AddButt;
    public ButtObj LessButt;

    public float N;

    public float MaxN;
    public float MinN;

    public Text Text;

    public float P
    {
        get
        {
            return _P;
        }
        set
        {
            _P = value;
            if (value % 1 == 0)
            {
                if (Text != null) Text.text = value.ToString ("0");
            }
            else
            {
                if (Text != null) Text.text = value.ToString ("0.0");
            }
            
            if (Del != null) Del (value);
        }
    }

    public float _P;

    public Void_FloatDel Del;

    void Start ()
    {
        AddButt.Del += (g) => 
        {
            P = Mathf.Min (P + N, MaxN);
        };
        LessButt.Del += (g) =>
        {
            P = Mathf.Max (P - N, MinN);
        };

        P = P;
    }
}
