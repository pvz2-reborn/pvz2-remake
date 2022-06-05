using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using Newtonsoft.Json;
using LevelSystemAPI;

public class levelButton : MonoBehaviour
{
    //private levelSystem controller = new levelSystem();
    public string level = "null";
    public int levelID = -1;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
        //controller.Awake();
    }
    private void OnClick(){
        Debug.Log("Joining Level..." + level);
        //controller.GetPlayingLevel();
        //controller.levelFinished(levelID);
        GameObject.Find("levelSelectSystem").SendMessage("levelFinished", levelID);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
