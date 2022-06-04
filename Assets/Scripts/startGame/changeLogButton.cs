using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class changeLogButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
    }

    private void OnClick(){
        Scrollbar scrollbar = GameObject.Find("Canvas/dialogBackend/changeLog/Scrollbar").GetComponent<Scrollbar> ();
        scrollbar.value = 1;
        CanvasGroup canvasTemp = GameObject.Find("Canvas/dialogBackend").GetComponent<CanvasGroup> ();
        canvasTemp.alpha = 1;
        canvasTemp.blocksRaycasts = true;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
