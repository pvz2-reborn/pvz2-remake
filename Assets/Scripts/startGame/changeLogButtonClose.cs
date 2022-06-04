using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class changeLogButtonClose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
    }

    private void OnClick(){
        CanvasGroup canvasTemp = GameObject.Find("Canvas/dialogBackend").GetComponent<CanvasGroup> ();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
