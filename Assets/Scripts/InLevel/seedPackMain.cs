using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
using UnityEngine.EventSystems;

public class seedPackMain : MonoBehaviour, ISelectHandler, IDeselectHandler ,IPointerClickHandler
{
    // Start is called before the first frame update
    //基础的种子包，拥有选中时显示一个绿框的功能
    void Awake ()
    {
        Selectable btn = this.GetComponent<Selectable> ();
        initSelectAnime ();
    }
    public Image[] imageList = new Image[10];
    public bool isSelected = false;
   
    public void initSelectAnime () {
        imageList =  this.GetComponentsInChildren<Image>();
        /*
        foreach (var i in imageList)
        {
            Debug.Log(i.name);
        }*/
    }
    public void viewSelectedPriceTab (bool type) {
        imageList[6].enabled = type;
    }
    public void selectCard () {
        //imageList[5].enabled = true;
        //imageList[6].enabled = true;
        viewSelectedPriceTab(true);
        imageList[7].enabled = true;
        isSelected = true;
    }
    public void deSelectCard () {
        //imageList[5].enabled = false;
       // imageList[6].enabled = false;
        viewSelectedPriceTab(false);
        imageList[7].enabled = false;
        isSelected = false;
    }
    public void OnSelect (BaseEventData eventData) {
        //selectCard ();
    }
    public void OnDeselect (BaseEventData eventData) {
        deSelectCard ();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick (PointerEventData pointerEventData) {
        if(isSelected) {
            deSelectCard ();
        }
        else {
            selectCard ();
        }
        
        //imageList[5].enabled = true;
        //imageList[6].enabled = true;
        //selectAnime ();
        //Debug.Log("Hello");
    }
}
