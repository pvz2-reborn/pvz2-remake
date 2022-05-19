using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;


namespace levelManagers
{

    public class levelManager : MonoBehaviour
    {
        public bool isDebugMode = false;
        public bool canSelectPlants = true;
    
        //functions ↓ | settings ↑
        public Vector3 cameraMoveto;
        public Camera MainCamera;
        public bool canCameraMove = false;
        public float cameraMoveSpeed = 1.0f;
        public bool isCameraMoveSuccess = true;

        

        public void MoveCamera (Vector3 to, float speed) {
            cameraMoveto = to;
            cameraMoveSpeed = speed;
            //canCameraMove = true;
            isCameraMoveSuccess = false;
            //waiting for move
            //while (!isCameraMoveSuccess) {}
            //public int time = 0;
            /*
            for (public int time = 0; time<=100000; time+=1)
            {
                Debug.Log("hello");
               //transform.position = Vector3.MoveTowards(transform.position, cameraMoveto, cameraMoveSpeed * time);
            }*/
            for(int i =1;!isCameraMoveSuccess;i++){
                Debug.Log("hello3");
                transform.position = Vector3.MoveTowards(transform.position, cameraMoveto, 0.000001f);
                //Debug.Log(Time.deltaTime);
                if (transform.position == cameraMoveto) {
                    isCameraMoveSuccess = true;
                    break;
                }
                if(i>=10000) break;
            }
           
        }

        public void doSeeZombie () {
            //MoveCamera (new Vector3(10.0f, 0.0f, -10.0f), 2.5f);
            //while(true){}
            //Camera 
            //Tweener tweener = gameObject.transform.DOMove(new Vector2(-8.27f, 4.57f), 1.4f);
        }

        public void doSelectPlants (bool canSelectPlants) {
            Debug.Log("hello1");
        
            if (canSelectPlants) {
            //MoveCamera (new Vector3(10.0f, 0.0f, -10.0f), 0.1f);
            
            }
            else {

            }
        //LetsRocked.back to lawn.
        //MoveCamera (new Vector3(0.0f, 0.0f, -10.0f), 2.5f);
        }

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
        doSeeZombie ();
            doSelectPlants (canSelectPlants);
            //
            doStartLevel();
        }

        public AnimationCurve curve;//放大的曲线
        private float value = 0;

        public void uiSet () {
            Text text;
            text = GameObject.Find("Canvas/redBanner").GetComponent<Text>();
            text.text = "Set...";
            //BGSINNEED
            Invoke ("uiPLANT", 0.6f);
            while (true) {
                //GameObject.Find("Canvas/redBanner").GetComponent<Text>().transform.localScale=Vector3.one*curve.Evaluate (value+=Time.deltaTime*2);
                GameObject.Find("Canvas/redBanner").GetComponent<Text>().transform.localScale=Vector3.one*1.1f;
                value+=Time.deltaTime;
                if (value>=1) {
                break;
                }
            }
        }

        public void uiPLANT () {
            Text text;
            text = GameObject.Find("Canvas/redBanner").GetComponent<Text>();
            text.text = "PLANT!";
            //BGSINNEED
            Invoke ("afterStartLevel", 0.6f);
            while (true) {
                //GameObject.Find("Canvas/redBanner").GetComponent<Text>().transform.localScale=Vector3.one*curve.Evaluate (value+=Time.deltaTime*2);
                GameObject.Find("Canvas/redBanner").GetComponent<Text>().transform.localScale=Vector3.one*1.3f;
                value+=Time.deltaTime;
                if (value>=1) {
                break;
                }
            }
        }
        public AudioClip startSound;
        private AudioSource audioSource;

        public void doStartLevel () {
            Debug.Log ("Level Starting!");
            Text text;
            text = GameObject.Find("Canvas/redBanner").GetComponent<Text>();
            text.text = "Ready...";
            //BGSINNEED

            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(startSound);

            Invoke ("uiSet", 0.6f);
            value = 0;
            while (true) {
                //GameObject.Find("Canvas/redBanner").GetComponent<Text>().transform.localScale=Vector3.one*curve.Evaluate (value+=Time.deltaTime*2);
                GameObject.Find("Canvas/redBanner").GetComponent<Text>().transform.localScale=Vector3.one*1.2f;
                value+=Time.deltaTime;
                if (value>=1) {
                break;
                }
            }

            //Ready... Set... PLANT!
        }
        //GameObject UI;
        public void afterStartLevel () {
            Text text;
            text = GameObject.Find("Canvas/redBanner").GetComponent<Text>();
            text.text = "";

            //开始创建阳光
            sunManager manager = GameObject.Find("skyManager").GetComponent<sunManager>();
            manager.startCreatSun();
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


        // 此脚本为进入关卡时到结束关卡领取奖励返回地图前总控制
        
        void Start()
        {
        // 到这里被激活进入关卡
        doBeforeStartLevel ();
            //doStartLevel ();

        }

        void Update()
        {
            if (canCameraMove) {
              transform.position = Vector3.MoveTowards(transform.position, cameraMoveto, cameraMoveSpeed * Time.deltaTime);
             //MainCamera.transform.position = Vector3.MoveTowards(transform.position, cameraMoveto, cameraMoveSpeed * Time.deltaTime);
                 if (transform.position == cameraMoveto) {
                    canCameraMove = false;
                    isCameraMoveSuccess = true;
                }
                
            }
        }
    }
}

