using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class displayLOGO : MonoBehaviour
{
    private float UI_Alpha = 1;             //初始化时让UI显示
    public float alphaSpeed = 1.1f;          //渐隐渐显的速度
    private CanvasGroup canvasGroup;

    public void displayEALOGO () {
        canvasGroup = GameObject.Find("Canvas/EALOGO").GetComponent<CanvasGroup>();
        UI_FadeIn_Event();
    }
    public void hideEALOGO () {
        canvasGroup = GameObject.Find("Canvas/EALOGO").GetComponent<CanvasGroup>();
        UI_FadeOut_Event();
    }
    public void displayPvz2LOGO () {
        canvasGroup = GameObject.Find("Canvas/pvz2LOGO").GetComponent<CanvasGroup>();
        UI_FadeIn_Event();
    }
    public void hidePvz2LOGO () {
        canvasGroup = GameObject.Find("Canvas/pvz2LOGO").GetComponent<CanvasGroup>();
        UI_FadeOut_Event();
    }
    public void displayLoadMenu () {
        canvasGroup = GameObject.Find("Canvas/bgBlack").GetComponent<CanvasGroup>();
        UI_FadeOut_Event();
    }

    private Image progressBar;
    public bool startLoadBar = false;

    public void loadBar () {
        //Tweener tweener = progressBar.transform.DOScale(Vector3(), 3.0f)
        startLoadBar = true;
    }

    public void Awake()
    {
        progressBar = GameObject.Find("Canvas/loadBar").GetComponent<Image>();
        progressBar.type = Image.Type.Filled;
        progressBar.fillMethod = Image.FillMethod.Horizontal;
        progressBar.fillOrigin = 0;
    }

    public void SetProgressValue10()
    {
        progressBar.fillAmount = 10f;
    }
    public void SetProgressValue20()
    {
        progressBar.fillAmount = 20f;
    }
    public void SetProgressValue30()
    {
        progressBar.fillAmount = 30f;
    }
    public void SetProgressValue40()
    {
        progressBar.fillAmount = 40f;
    }
    public void SetProgressValue50()
    {
        progressBar.fillAmount = 50f;
    }
    public void SetProgressValue60()
    {
        progressBar.fillAmount = 60f;
    }
    public void SetProgressValue70()
    {
        progressBar.fillAmount = 70f;
    }
    public void SetProgressValue80()
    {
        progressBar.fillAmount = 80f;
    }
    public void SetProgressValue90()
    {
        progressBar.fillAmount = 90f;
    }
    public void SetProgressValue100()
    {
        progressBar.fillAmount = 100f;
    }
    public void newBeforeLoadBar () {
        Sequence seq = DOTween.Sequence();//执行队列
        seq.AppendCallback(() => {
            displayEALOGO ();
        });
        seq.AppendInterval(2.0f);
        seq.AppendCallback(() => {
            hideEALOGO ();
        });
        seq.AppendInterval(1.5f);
        seq.AppendCallback(() => {
            displayPvz2LOGO ();
        });
        seq.AppendInterval(2.5f);
        seq.AppendCallback(() => {
            hidePvz2LOGO ();
        });
        seq.AppendInterval(1.0f);
        seq.AppendCallback(() => {
            displayLoadMenu ();
        });
        seq.AppendInterval(1.0f);
        seq.AppendCallback(() => {
            //displayLoadMenu ();
            
        });

    }

    void Start()
    {
        newBeforeLoadBar ();
        //displayEALOGO ();
        //Invoke("hideEALOGO",2);
        //Invoke("displayPvz2LOGO",3.5f);
        //Invoke("hidePvz2LOGO",6);
        //Invoke("displayLoadMenu",7);
        //Invoke("loadBar",8);
        /*
        Invoke("SetProgressValue10",8);
        Invoke("SetProgressValue20",9);
        Invoke("SetProgressValue30",10);
        Invoke("SetProgressValue40",11);
        Invoke("SetProgressValue50",12);
        Invoke("SetProgressValue60",13);
        Invoke("SetProgressValue70",14);
        Invoke("SetProgressValue80",15);
        Invoke("SetProgressValue90",16);
        Invoke("SetProgressValue100",17);
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasGroup == null)
        {
            return;
        }
 
        if (UI_Alpha != canvasGroup.alpha)
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, UI_Alpha, alphaSpeed * Time.deltaTime);
            if (Mathf.Abs(UI_Alpha - canvasGroup.alpha) <= 0.01f)
            {
                canvasGroup.alpha = UI_Alpha;
            }
        }
        if(startLoadBar) {
            //progressBar.transform.position.width = MoveTowards(progressBar.transform.position.width,1000f,2.5f * Time.deltaTime);
            
        }
    }
    public void UI_FadeIn_Event()
    {
        UI_Alpha = 1;
        canvasGroup.blocksRaycasts = true;      //可以和该对象交互
    }
 
    public void UI_FadeOut_Event()
    {
        UI_Alpha = 0;
        canvasGroup.blocksRaycasts = false;     //不可以和该对象交互
    }
}
