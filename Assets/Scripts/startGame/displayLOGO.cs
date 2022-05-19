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

    
    public bool startLoadBar = false;
    private Image progressBar;

    Vector4 loadBarNomalColor = new Vector4(1.000f, 1.000f, 1.000f, 1.000f);
    Vector4 loadBarChangedColor = new Vector4(1.000f, 1.000f, 1.000f, 0.300f);

    public void fillLoadBar () {
        //progressBar.fillOrigin = 0;
        //Tweener tweener = progressBar.transform.DOScale(Vector3(), 3.0f)
        startLoadBar = true;
        //progressBar.fillAmount = 0.1f;
        Debug.Log("Loading...");
        progressBar.DOFillAmount(1f, 10.0f);

        
    }

    public void Awake()
    {

        progressBar = GameObject.Find("Canvas/loadBar").GetComponent<Image>();
        progressBar.fillAmount = 0.0f;
        //startLoadBar = true;
        
        //progressBar.color = new Vector4(1.000f, 1.000f, 1.000f, 1.000f);
        //Debug.Log(Color.red);
        //progressBar.type = Image.Type.Filled;
        //progressBar.fillMethod = Image.FillMethod.Horizontal;
        //progressBar.fillOrigin = 0;
    }

    private CanvasGroup canvasTemp;
    public void hideLoader () {
        GameObject bgloadBarUI = GameObject.Find("Canvas/bgLoadBar");
        GameObject loadBarUI = GameObject.Find("Canvas/loadBar");
        GameObject copyRightUI = GameObject.Find("Canvas/copyRight");
        GameObject bgBlack = GameObject.Find("Canvas/bgBlack");

        canvasTemp = loadBarUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;

        canvasTemp = copyRightUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;

        canvasTemp = bgloadBarUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;

        canvasTemp = bgBlack.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;

    }
    public void hideStartMenuRealize () {
        GameObject contentButtonUI = GameObject.Find("Canvas/contentButton");
        GameObject nameEntryUI = GameObject.Find("Canvas/nameEntry");
        GameObject startGameButtonUI = GameObject.Find("Canvas/startGameButton");
        GameObject cloudSaveButtonUI = GameObject.Find("Canvas/cloudSaveButton");
        GameObject settingButtonUI = GameObject.Find("Canvas/settingButton");
        GameObject newsButtonUI = GameObject.Find("Canvas/newsButton");
        GameObject closeGameButtonUI = GameObject.Find("Canvas/closeGameButton");

        canvasTemp = contentButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;

        canvasTemp = nameEntryUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;

        canvasTemp = startGameButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;

        canvasTemp = cloudSaveButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;

        canvasTemp = settingButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;

        canvasTemp = newsButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = false;

        canvasTemp = closeGameButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 0;
        canvasTemp.blocksRaycasts = true;
    }
    public void displayStartMenuRealize () {
        GameObject contentButtonUI = GameObject.Find("Canvas/contentButton");
        GameObject nameEntryUI = GameObject.Find("Canvas/nameEntry");
        GameObject startGameButtonUI = GameObject.Find("Canvas/startGameButton");
        GameObject cloudSaveButtonUI = GameObject.Find("Canvas/cloudSaveButton");
        GameObject settingButtonUI = GameObject.Find("Canvas/settingButton");
        GameObject newsButtonUI = GameObject.Find("Canvas/newsButton");
        GameObject closeGameButtonUI = GameObject.Find("Canvas/closeGameButton");

        canvasTemp = contentButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 1;
        canvasTemp.blocksRaycasts = true;

        canvasTemp = nameEntryUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 1;
        canvasTemp.blocksRaycasts = true;

        canvasTemp = startGameButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 1;
        canvasTemp.blocksRaycasts = true;

        canvasTemp = cloudSaveButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 1;
        canvasTemp.blocksRaycasts = true;

        canvasTemp = settingButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 1;
        canvasTemp.blocksRaycasts = true;

        canvasTemp = newsButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 1;
        canvasTemp.blocksRaycasts = true;

        canvasTemp = closeGameButtonUI.GetComponent<CanvasGroup>();
        canvasTemp.alpha = 1;
        canvasTemp.blocksRaycasts = true;
    }
    public void displayStartMenu () {
        hideLoader ();
        displayStartMenuRealize ();
        //hideLoader ();
    }

    public void newBeforeLoadBar () {
        Sequence seq = DOTween.Sequence();//执行队列
        seq.AppendCallback(() => {
            hideStartMenuRealize ();
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
        seq.AppendInterval(0.6f);
        seq.AppendCallback(() => {
           fillLoadBar ();
           //Debug.Log("Load Success!");
        });
        seq.AppendInterval(10.0f);
        seq.AppendCallback(() => {
           //loadBar ();
           Debug.Log("Load Success!");
           displayStartMenu ();
        });
    }

    void Start()
    {
        //displayStartMenu ();
        newBeforeLoadBar ();
        //onLoadBar ();
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
            progressBar.color = Color.Lerp(loadBarNomalColor, loadBarChangedColor, Mathf.PingPong(Time.time, 0.55f));
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
