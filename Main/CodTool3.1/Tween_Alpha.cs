using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tween_Alpha : Tween
{
    public CanvasGroup CanvasGroup;

    public float From = 0;
	public float To = 1;
    
    void Start () {
		Del += (f) =>
        {
			if (CanvasGroup)
			{
				CanvasGroup.alpha = Mathf.Lerp (From, To, f);
			}
		};
	}
}
