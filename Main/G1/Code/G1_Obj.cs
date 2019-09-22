using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1_Obj : ObjArray
{   
    //出生左下角的座標是(-1000,600)
    //Y=7.5以上基本上就會觸發
    //變身後移動到高度400的地方
    public Rigidbody2D Rigidbody2D;

    public Tween_Position Tw_P_0;
    public Tween_Rotation Tw_R_0;
    public Tween_Color Tw_C_0;

    public Vector2 V2;//飛行的方向

    public ButtObj Butt;

    void Start ()
    {
        Butt.Del += (g) =>
        {
            G1_MainUI._.Score ++;
            Destroy (gameObject);
        };
    }

    public void Open (Vector2 V2)
    {
        this.V2 = V2;
        Move_0 ();
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "85B")
        {
            StartCoroutine (Move_1 ());
        }
        else if (other.name == "d")
        {
            Destroy (gameObject);
        }
	}
    public void Move_0 ()
    {
        transform.localScale = new Vector3 (V2.x > 0 ? -1 : 1, 1, 1);
        Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        Rigidbody2D.angularVelocity = Random.Range (-100, 100);
        Rigidbody2D.velocity = V2;
    }

    public IEnumerator Move_1 ()
    {
        OnOnlyObjs (1);
        Tw_R_0.Play (true);
        Rigidbody2D.bodyType = RigidbodyType2D.Static;
        Tw_P_0.Time_Length = G1_MainUI._.NowTime_Length;
        Tw_P_0.From = transform.localPosition;
        Tw_P_0.To = new Vector3 (Tw_P_0.From.x, 400, Tw_P_0.From.z);
        yield return Tw_P_0.IE_Play (true);
        yield return new WaitForSeconds (0.2f);
        yield return Move_2 ();
    }

    public IEnumerator Move_2 ()
    {
        Tw_P_0.From = transform.localPosition;
        float x = transform.localPosition.x > 0 ? 100 : -100;
        Tw_P_0.To = new Vector3 (x, -300, 0);
        Tw_P_0.Time_Length = 0.3f;
        Tw_P_0.f = 0;

        yield return Tw_P_0.IE_Play (true);
        G1_MainUI._.UI.PlayUI.UI.UserUI.Hit ();
        // print ("擊中");

        Tw_C_0.Play (true);
        Tw_P_0.From = transform.localPosition;
        x = transform.localPosition.x > 0 ? 300 : -300;
        Tw_P_0.To = new Vector3 (x, -300, 0);
        Tw_P_0.f = 0;

        G1_MainUI._.UI.PlayUI.UI.HPBar.HP--;
        yield return Tw_P_0.IE_Play (true);
        Destroy (gameObject);
    }
}
