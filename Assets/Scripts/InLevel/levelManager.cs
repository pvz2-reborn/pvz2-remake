using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;




    public class levelManager : MonoBehaviour
    {
        public bool isDebugMode = false;
        public bool canSelectPlants = true;

        public bool isStartedGame = false;
    
        //functions ↓ | settings ↑
        public void doBeforeStartLevel () {
        //read level settings
            Debug.Log("Level Debug Mode On");
        
        //Debug.Log("Start Reading Level ...");
        /*
        try {
            //readlevel ();
            Debug.Log("Read Success!");
        } 
        catch (IOException e) {
            Debug.LogError();
        }
        */
        //showLevelTarget ();
        //
        //doSeeZombie ();
            //doSelectPlants (canSelectPlants);
            //
            doStartLevel();
        }

        public void doStartLevel () {
            Debug.Log ("Level Starting!");
            redBannerManager bmManager = GameObject.Find("redBannerManager").GetComponent<redBannerManager>();
            bmManager.showStartGameBanner();


            
            Invoke("afterStartLevel", 1.8f);
        }
        //GameObject UI;
        public void afterStartLevel () {
            //开始创建阳光
            sunManager manager = GameObject.Find("skyManager").GetComponent<sunManager>();
            manager.startCreatSun();
            isStartedGame = true;
/*
            UI = GameObject.Find("Canvas/2xSpeedButton");
            UI.SetActive(true);
            UI = GameObject.Find("Canvas/sunNumBG");
            UI.SetActive(true);
            UI = GameObject.Find("Canvas/plantFood");
            UI.SetActive(true);
            UI = GameObject.Find("Canvas/powerUpFrame");
            UI.SetActive(true);
*/
            Debug.Log ("Level Started!");
            //GameObject.Find("BGMmanager").SendMessage("playEgyptMinigameBGM"); 
            GameObject.Find("BGMmanager").SendMessage("endBGM");
            GameObject.Find("BGMmanager").SendMessage("playInternalBGM","egyptMinigame");

            //GameObject.Find("skyManager").SendMessage("addSunNum",50);
            //playBGM.playInternalBGM("egyptMinigame");
        }


        // 此脚本为游戏开始后到结束关卡领取奖励返回地图前总控制
        
        void Start()
        {
            // 到这里被激活进入关卡
            //doBeforeStartLevel ();
            //doStartLevel ();

        }

        void Update()
        {
            
        }
    }


