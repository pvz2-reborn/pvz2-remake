using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public float smooth;
    public Vector3 gamestart_pos;
    public Vector3 select_plants_pos;
    public Vector3 maxreach_pos;
    public Camera MainCamera;
    public float speed = 0.1F;

    public bool canCameraMove = false;
    public bool canSelectPlants = false;
    public bool isSecondCamerMove = false;
    public bool moveSuccess = false;

    //uishide
    GameObject UI;
    //level settings
    public string levelStartBGM = "egyptMinigame";


    void Start(){
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
        canCameraMove = true;
        canSelectPlants = false;
        GameObject.Find("BGMmanager").SendMessage("playInternalBGM","egyptMinigame");
    }
 
    void Update() {
        /*
        gamestart_pos = new Vector3(0, 0, -10);
        select_plants_pos = new Vector3(4, 0, -10);
        maxreach_pos = new Vector3(10, 0, -10);

        smooth = 5;

        MainCamera.transform.position = Vector3.Lerp(gamestart_pos, maxreach_pos, smooth * Time.deltaTime);
        */
        //MainCamera.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
        //MainCamera.transform.position = Vector3.SmoothDamp(transform.position, new Vector3(10, 0, -10), refve, 0);
        if (canCameraMove) {

            if (transform.position.x <= 7.5f) {
                transform.position = Vector3.Lerp(transform.position, new Vector3(10.0f, 0.0f, -10.0f), 2.5f * Time.deltaTime);
                MainCamera.transform.position = Vector3.Lerp(transform.position, new Vector3(0.0f, 0.0f, -10.0f), 2.5f * Time.deltaTime);
            }

            else {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(10.0f, 0.0f, -10.0f), 2.5f * Time.deltaTime);
                MainCamera.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.0f, 0.0f, -10.0f), 2.5f * Time.deltaTime);
            }
            
            if (transform.position.x >= 10.0f) {
                canCameraMove = false;
                isSecondCamerMove = true;
                //UI = GameObject.Find("Canvas/pauseButton");
                //UI.SetActive(true);
            }
           
        }
        
        else if (canSelectPlants && isSecondCamerMove){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(4.0f, 0.0f, -10.0f), 3.0f * Time.deltaTime);
            MainCamera.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.0f, 0.0f, -10.0f), 3.0f * Time.deltaTime);
            if (transform.position.x <= 4.0f)
                isSecondCamerMove = false;
        }
        else if (!canSelectPlants && isSecondCamerMove) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.0f, 0.0f, -10.0f), 4.0f * Time.deltaTime);
            MainCamera.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.0f, 0.0f, -10.0f), 4.0f * Time.deltaTime);
            if (transform.position.x <= 0.00f) {
                isSecondCamerMove = false;
                GameObject.Find("levelManager").SendMessage("doStartLevel"); 
            }
                
        }
    }
    
   

}
