using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mobe_Nob : MonoBehaviour
{
    public ObjArray NobObj;
    public GameObject m_Nob;

    public int Nob {
        set {
            Open (value);
        }
    }

    public void  Open (int Nob) {
        string _Nob = Nob.ToString ();
        int [] NobInt = new int [_Nob.Length];
        for (int i = 0; i < NobInt.Length; i++) {
            NobInt [i] = "0123456789".IndexOf (_Nob [i]);
            ObjArray OA = MyCalculate.SpObj (NobObj.gameObject, m_Nob.transform, Vector3.zero).GetComponent <ObjArray> ();
            OA.OnOnlyObjs (NobInt [i]);
            OA.gameObject.SetActive (true);
        }

        m_Nob.GetComponent <Tween_Color> ().Del += (f) => {
            Image [] Ims = GetComponentsInChildren <Image> ();
            foreach (Image i in Ims) {
                i.color = m_Nob.GetComponent<Tween_Color> ().NowColor;
            }
        };
        m_Nob.GetComponent <Tween_Color> ().End_Del += () => {
            Destroy (gameObject);
        };
        m_Nob.SetActive (true);
        m_Nob.GetComponent <Tween_Color> ().Play (true);
    } 

    [ContextMenu ("Test")]
    public void Test () {
        Open (7);
    }
}
