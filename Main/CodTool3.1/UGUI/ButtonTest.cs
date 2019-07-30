using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTest : ButtObj, 
IPointerClickHandler, //傳統的按下判斷
IPointerDownHandler,  //滑鼠按下
IPointerUpHandler,    //滑鼠放開
IPointerEnterHandler, //滑鼠進入範圍
IPointerExitHandler,  //滑鼠離開範圍
IDragHandler          //滑鼠拖動 
{

	public void OnPointerClick(PointerEventData eventData){
		print ("基礎按法");
    }
	public void OnPointerDown(PointerEventData eventData){
		print ("按下" + eventData.pointerId);
    }
	public void OnPointerUp(PointerEventData eventData){
		print ("放開" + eventData.pointerId);
    }
	public void OnPointerEnter(PointerEventData eventData){
        Debug.Log ("進入範圍");
    }
    public void OnPointerExit(PointerEventData eventData){
        Debug.Log ("離開範圍");
    }
    public void OnDrag(PointerEventData eventData){
        Debug.Log ("拖動");
    }
}
