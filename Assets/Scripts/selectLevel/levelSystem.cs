using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class levelSystem : MonoBehaviour
{
    Vector2[] levelPosList = new Vector2[1000];
    Vector2 level1 = new Vector2(-5.07f, 7.0f);
    float offset = 2.0f;
    int levelnum = 5;
    private GameObject prefabLevel;
    GameObject[] levelList = new GameObject[1000];

    public class levelProgress {
        public string wordName = "Egypt";
        public int playingLevel = 0;
    }
    

    private void creatLevelPosList (Vector2 firstLevel) {
        levelPosList[1] = level1;
        for (int i = 2; i <= levelnum; i++) {
            float newX = levelPosList[i - 1].x + offset;
            levelPosList[i] = new Vector2(newX, 7);
        }
        
        for (int i = 1; i <= levelnum; i ++) {
            Debug.Log(levelPosList[i]);
        }
    }
    private void creatLevelIcon (Vector2[] levelPosList) {
        prefabLevel = Resources.Load<GameObject>("prefabs/levelNodeUnActive");
        for (int i = 1; i <= levelnum; i ++) {
            GameObject levelObject = GameObject.Instantiate<GameObject>(prefabLevel, levelPosList[i], Quaternion.identity, transform);
            Text levelName;
            Camera mainCamera;
            Canvas canvas;
            mainCamera =  GameObject.Find("Main Camera").GetComponent<Camera>();
            canvas = levelObject.GetComponentsInChildren<Canvas>()[0].GetComponent<Canvas>();
            levelName = levelObject.GetComponentsInChildren<Text>()[0].GetComponent<Text>();
            //Debug.Log(levelObject.GetComponentsInChildren<Text>()[0].GetComponent<Text>());
            canvas.worldCamera = mainCamera;

            levelName.transform.position = levelObject.transform.position;//new Vector3(0.657f, 81.06f, 0f);
            //Debug.Log(levelName.transform.position);
            
            Vector3 temp = levelName.transform.position + new Vector3(0f, -1.7f, 0f);
            //Debug.Log(temp);
            levelName.transform.position = temp;
            //levelName.transform.position.x + 0.657f;
            //levelName.transform.position.y + 81.06f;
            levelName.text = i.ToString();
            levelList[i] = levelObject;
        }
    }
    public levelProgress worldMap;
    public void loadLevelProgress () {
        worldMap = new levelProgress();
        worldMap.playingLevel = 3;
    }
    public void updateLevelIcon () {//todo 添加迷你游戏与危险关卡图标的支持
        Debug.Log("Level Progress:" + worldMap.playingLevel);
        if(worldMap.playingLevel > levelnum) {
            //Debug.LogError(System.IndexOutOfRangeException());
            Debug.Log("不会吧，不会有人改存档越界了吧?");
            return;
        }
        for (int i =1; i <= worldMap.playingLevel; i++) {
            Animator animator;
            animator = levelList[i].GetComponentInChildren<Animator>();
            if (i == worldMap.playingLevel) {
                animator.Play("levelNodeUnlocked");
                continue;
            }
            animator.Play("levelNodeFinished");
        }
    }
    public void levelFinished () {
        int finishedLevel = 3;
        if(finishedLevel == worldMap.playingLevel) {//通过新关卡
            worldMap.playingLevel = finishedLevel + 1;
            Animator animator;
            animator = levelList[finishedLevel].GetComponentInChildren<Animator>();
            animator.Play("levelNodeUnlockAnimation");//更新动画
            //更新mapPath
            if (worldMap.playingLevel < levelnum) {//当下面还有关卡时 更新动画
                animator = levelList[finishedLevel + 1].GetComponentInChildren<Animator>();
                animator.Play("levelNodeLockedAnimation");//更新动画
            }
        }
        else {
            return;
        }
    }
    public void creatMapPath () {
        if (levelnum <= 1) {
            return;
        }
        float mapPathDefaultLength = 1.55f;
        //Vector2 trulyVector = new Vector2(-3.1f, 7.0f) - new Vector2(-5.1f, 7.5f);
        //float angleTest = Vector2.Angle (Vector2.right, trulyVector);
        //Debug.Log("The angle is: " + angleTest.ToString());
        for (int i = 1; i <= (levelnum -1); i ++) {
            Vector2 levelA = levelPosList[i];
            Vector2 levelB = levelPosList[i + 1];

            float angle = Vector2.Angle (Vector2.right, (levelB - levelA));
            //Vector3 cross=Vector3.Cross(levelA, levelB);
            //angle = cross.z >  ? -angle : angle;
            //Debug.Log("Level " + i.ToString() +" to Level " + (i + 1).ToString() + ".The angle is: " + angle.ToString());

            float distance = Vector2.Distance (Vector2.right, (levelB - levelA));
            //Debug.Log("Level " + i.ToString() +" to Level " + (i + 1).ToString() + ".The distance is: " + distance.ToString());

            Vector2 midPoint = new Vector2((levelA.x + levelB.x)/2, (levelA.y + levelB.y)/2);
            //Debug.Log("MidPoint:" + midPoint);
            //有了中点动画和基于距离的缩放系数，就可以放置MapPath了
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        creatLevelPosList(level1);//关卡数据初始化
        creatLevelIcon(levelPosList);//创建关卡图标
        creatMapPath ();//创建光线路径
        loadLevelProgress();//读取存档进度
        updateLevelIcon ();//根据存档进度更新关卡图标
        //
        Invoke("levelFinished", 3); //levelFinished();//关卡完成时
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
