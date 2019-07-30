using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G0_UserSetUI : MonoBehaviour {

    [Serializable]
	public struct _UI {
        public ButtObj [] Butts;
        public G0_ButtonBar SexButt;
        public ButtObj EndButt;

        public G0_UserUI User;
    }
    public _UI UI;

    void Start () {
        UI.Butts [0].Del += (g) => {
            ImButt butt = (ImButt)UI.Butts [0];
            UI.User.SetIm ("Head", butt.OK);
            CK ();
        };
        UI.Butts [1].Del += (g) => {
            ImButt butt = (ImButt)UI.Butts [1];
            UI.User.SetIm ("Body", butt.OK);
            CK ();
        };
        UI.Butts [2].Del += (g) => {
            ImButt butt = (ImButt)UI.Butts [2];
            UI.User.SetIm ("Joint", butt.OK);
            CK ();
        };
        UI.Butts [3].Del += (g) => {
            ImButt butt = (ImButt)UI.Butts [3];
            UI.User.SetIm ("Hand", butt.OK);
            CK ();
        };
        UI.Butts [4].Del += (g) => {
            ImButt butt = (ImButt)UI.Butts [4];
            UI.User.SetIm ("Foot", butt.OK);
            CK ();
        };

        UI.SexButt.BarDel += (n) => {
            if (n == 0) {
                UI.User.SetIm ("Sex", false);
            } else {
                UI.User.SetIm ("Sex", true);
            }
        };

        UI.EndButt.Del += (g) => {
            G0_MainUI._.SetUI (1);
        };
    }

    public void CK () {
        for (int i = 0; i < UI.Butts.Length; i++) {
            ImButt butt = (ImButt)UI.Butts [i];
            if (!butt.OK) {
                UI.EndButt.gameObject.SetActive (false);
                return;
            }
        }
        UI.EndButt.gameObject.SetActive (true);
    }
}
