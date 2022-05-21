using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class StartGame : MonoBehaviour
{
    public Vector3 gamestart_pos;
    public Vector3 select_plants_pos;
    public Vector3 maxreach_pos;
    private Camera MainCamera;

    private bool canSelectPlants = false;

    

    //uishide
    GameObject UI;
    //level settings
    public string levelStartBGM = "egyptMinigame";

    public void doSeeZombie () {
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Sequence seq = DOTween.Sequence();//执行队列
        seq.Append(
            MainCamera.transform.DOMove(new Vector3(10.0f, 0.0f, -10.0f), 2.0f)
        );
        seq.AppendCallback( () => {
            if (canSelectPlants) {
                seq.Append(
                    MainCamera.transform.DOMove(new Vector3(4.0f, 0.0f, -10.0f), 2.5f)
                );
                Invoke("doSelectPlants", 2.5f);
            }
            else {
                doBackLawn();
            }
        });
       
       

    }
    public void doSelectPlants () {
        Debug.Log("Selecting Plant");
        
        //
        doBackLawn ();
    }
    public void doBackLawn () {
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        levelManager manager = GameObject.Find("levelManager").GetComponent<levelManager>();
        Sequence seq = DOTween.Sequence();//执行队列
        seq.Append(
            MainCamera.transform.DOMove(new Vector3(0.0f, 0.0f, -10.0f), 2.0f)
        );
        seq.AppendCallback( () => {
            //doSelectPlants ();
            manager.doBeforeStartLevel ();
        });
    }

    void Start(){
        doSeeZombie ();
        /*
        UI = GameObject.Find("Canvas/pauseButton");
        UI.SetActive(false);
        UI = GameObject.Find("Canvas/2xSpeedButton");
        UI.SetActive(false);
        UI = GameObject.Find("Canvas/sunNumBG");
        UI.SetActive(false);
        UI = GameObject.Find("Canvas/plantFood");
        UI.SetActive(false);
        UI = GameObject.Find("Canvas/powerUpFrame");
        UI.SetActive(false);
        */ //hide
        //pauseButton,2xSpeedButton,sunNumBG,plantFood,powerUpFrame
        //Debug.Log(MainCamera.transform.position);
        //canCameraMove = true;
        //canSelectPlants = false;
        //GameObject.Find("BGMmanager").SendMessage("playInternalBGM","egyptMinigame");
    }
 
    void Update() {
       
    }
    
   

}
