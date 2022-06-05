using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using Newtonsoft.Json;

namespace LevelSystemAPI {
    public class levelSystem : MonoBehaviour {
        //private static levelSystem controller = new levelSystem();
        
        
        Vector2[] levelPosList = new Vector2[1000];
        Vector2 level1 = new Vector2(-5.07f, 7.0f);
        float offset = 5.0f;
        int levelnum = 0;
        private GameObject prefabLevel;
        //List<GameObject> levelList = new List<GameObject>();
        GameObject[] mapPathList = new GameObject[1000];

            Vector3 levelNameOffset = new Vector3(0f, -1.7f, 0f);
        Vector3 mapPathOffset = new Vector3(0f, -2.5f, 0f);
        Vector3 levelButtonOffset = new Vector3(0f, -2.2f, 0f);

        public class levelProgress {
           public string wordName = "Egypt";
            public int playingLevel = 0;
        }

        public class Postion2D {
            public float x {get; set;}
            public float y {get; set;}

        }

        public class MapPiece {
            public Postion2D position {get; set;}
            public string eventType {get; set;}
            public string name {get; set;}
            public string dataString {get; set;}
            public string parentEvent {get; set;}
            public string displayText {get; set;}
            public int cost {get; set;}
            public bool autoVisible {get; set;}
            public string completedEvent {get; set;}
            public string unlockedEvent {get; set;}
            public string levelNodeType {get; set;}
            public int drawLayer {get; set;}
            public float rotationAngle {get; set;}
            public float rotationRate {get; set;}
            public float scaleX {get; set;}
            public float scaleY {get; set;}     

            public GameObject gameObject {get; set;}   
        }

        public class WordMapMain {
            public int version {get; set;}
            public List<MapPiece> mapPieces {get; set;}
        }
    
        WordMapMain wordMapMain = new WordMapMain ();

        public List<MapPiece> levelList = new List<MapPiece>();

        private static string configPath = "Config";
        public string config;

        public static bool LoadConfig<T>(out T loadObject, string name = "config", string Path = "Config")
        {
            //读取配置文件
            string folderPath = System.IO.Path.Combine(Application.dataPath, Path); //配置文件夹路径
            string fileName = name + ".json";                                           //文件名
            string filePath = System.IO.Path.Combine(folderPath, fileName);             //文件路径
            loadObject = default;

            if (System.IO.File.Exists(filePath))
            {
                //读取文件
                System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
                string str_json = sr.ReadToEnd();
                sr.Close();
                //反序列化
                loadObject = JsonConvert.DeserializeObject<T>(str_json);
                Debug.Log("成功读取Config");
                return true;
            }
            Debug.Log("Config读取失败");
            return false;
        }

        public void readWorldMapPiece () {
            LoadConfig<WordMapMain>(out wordMapMain, "config", "Config/worlds/egypt/part1");

        }

        private void creatLevelIcon () {
            //creatLevelList ();
            /*
            levelPosList[1] = level1;
            for (int i = 2; i <= levelnum; i++) {
                float newX = levelPosList[i - 1].x + offset;
                levelPosList[i] = new Vector2(newX, 7);
            }
        
            for (int i = 1; i <= levelnum; i ++) {
                Debug.Log(levelPosList[i]);
            }*/
            //关卡图标预制体
            /*
            if(levelList[0].gameObject != null) {
                return;
            }*/
            prefabLevel = Resources.Load<GameObject>("prefabs/levelNodeUnActive");
            for (int i = 0; i < levelList.Count; i++) {
                //Debug.Log(wordMapMain.mapPieces[i].name);
                //关卡图标是哪种类型的
                    GameObject levelObject = new GameObject();
                    switch (wordMapMain.mapPieces[i].levelNodeType)
                    {
                        //迷你游戏
                        case "minigame":
                            levelObject = GameObject.Instantiate<GameObject>(prefabLevel, new Vector2(wordMapMain.mapPieces[i].position.x, wordMapMain.mapPieces[i].position.y), Quaternion.identity, transform);
                            break;
                        //默认
                        default:
                            levelObject = GameObject.Instantiate<GameObject>(prefabLevel, new Vector2(wordMapMain.mapPieces[i].position.x, wordMapMain.mapPieces[i].position.y), Quaternion.identity, transform);
                            break;
                    }
                    Text levelName;
                    Camera mainCamera;
                    Canvas canvas;
                    Button levelButton;
                    mainCamera =  GameObject.Find("Main Camera").GetComponent<Camera>();
                    canvas = levelObject.GetComponentsInChildren<Canvas>()[0].GetComponent<Canvas>();
                    levelName = levelObject.GetComponentsInChildren<Text>()[0].GetComponent<Text>();
                    levelButton = levelObject.GetComponentsInChildren<Button>()[0].GetComponent<Button>();
                    //Debug.Log(levelObject.GetComponentsInChildren<Text>()[0].GetComponent<Text>());
                    canvas.worldCamera = mainCamera;

                    levelName.transform.position = levelObject.transform.position;//new Vector3(0.657f, 81.06f, 0f);
                    //Debug.Log(levelName.transform.position);

                    //由于预制体中心点不在图标上，所以需要offset
                    Vector3 temp = levelName.transform.position + levelNameOffset; 
                    //Debug.Log(temp);
                    levelName.transform.position = temp;

                    //关卡按钮同理
                    levelButton.transform.position = levelObject.transform.position;
                    temp = levelButton.transform.position + levelButtonOffset;
                    levelButton.transform.position = temp;
                
                    //关卡显示名
                    levelName.text = wordMapMain.mapPieces[i].displayText;
                    //关卡进入按钮设置
                    levelButton.enabled = false;
                    levelButton.GetComponent<levelButton>().levelID = i + 1;
                    if(wordMapMain.mapPieces[i].dataString != "") {
                        levelButton.GetComponent<levelButton>().level = wordMapMain.mapPieces[i].dataString;
                    }
                    else {
                        levelButton.GetComponent<levelButton>().level = "null";
                    }
                    
                    //存入关卡总列表
                    levelList[i].gameObject = levelObject;
            }
        }
        private void creatLevelList () {
            readWorldMapPiece ();
            //读取地图碎片
            for (int i = 0; i < wordMapMain.mapPieces.Count; i ++) {
                //如果是关卡配置
                if(wordMapMain.mapPieces[i].eventType == "level") {
                    levelList.Add(wordMapMain.mapPieces[i]);
                }
            }
        }
        public levelProgress worldMap;
        public void loadLevelProgress () {
            worldMap = new levelProgress();
            worldMap.playingLevel = 3;
        }
        Dictionary <string, bool> eventProgress = new  Dictionary <string, bool>();
        public void initLevelEvent () {
            //扫一遍所有的地图碎片
            for (int i = 0; i < wordMapMain.mapPieces.Count; i++) {
                //如果这里是关卡
                if (wordMapMain.mapPieces[i].eventType == "level") {
                    //默认事件全为false
                    eventProgress[wordMapMain.mapPieces[i].name] = false;
                }
            }
        }
        public void updateLevelIcon () {//todo 添加迷你游戏与危险关卡图标的支持
            Debug.Log("Level Progress:" + worldMap.playingLevel);
            if(worldMap.playingLevel > levelList.Count) {
                //Debug.LogError(System.IndexOutOfRangeException());
                Debug.Log("不会吧，不会有人改存档越界了吧?");
                return;
            }
            for (int i = 0; i <= worldMap.playingLevel - 1; i++) {
                Animator animator;
                Button levelButton;
                animator = levelList[i].gameObject.GetComponentInChildren<Animator>();
                levelButton = levelList[i].gameObject.GetComponentInChildren<Button>();
                if (i == (worldMap.playingLevel - 1)) {
                    animator.Play("levelNodeUnlocked");
                    levelButton.enabled = true;
                    continue;
                }
                levelButton.enabled = true;
                animator.Play("levelNodeFinished");
            }
        }
    
        public void levelFinished (int finishedLevel) {
            Debug.Log("Playing Level: " + worldMap.playingLevel);
            Debug.Log("Finishing Level: " + finishedLevel);
            //creatLevelList ();
            //creatLevelIcon ();
            //loadLevelProgress();
            if(finishedLevel == worldMap.playingLevel) {//通过新关卡
                worldMap.playingLevel = finishedLevel + 1;
                Animator animatorLevelIcon;
                Animator animatorMapPath;
                
                animatorLevelIcon = levelList[finishedLevel - 1].gameObject.GetComponentInChildren<Animator>();
                animatorLevelIcon.Play("levelNodeUnlockAnimation");//更新动画
                //更新mapPath
                animatorMapPath = mapPathList[finishedLevel - 1].GetComponentInChildren<Animator>();
                animatorMapPath.Play("beamPathOpen");
            
                if (worldMap.playingLevel < levelList.Count + 1) {//当下面还有关卡时 更新动画
                    animatorLevelIcon = levelList[finishedLevel].gameObject.GetComponentInChildren<Animator>();
                    animatorLevelIcon.Play("levelNodeLockedAnimation");//更新动画
                    Button levelButton;
                    levelButton = levelList[finishedLevel].gameObject.GetComponentInChildren<Button>();
                    levelButton.enabled = true;
                }
            }
            else {
                return;
            }
        }

        private GameObject prefabMapPath;
        public void creatMapPath () {
            if (levelList.Count <= 1) {
                return;
            }
            float mapPathDefaultLength = 0.78f;
        
            prefabMapPath = Resources.Load<GameObject>("prefabs/mapPathDefault");
            for (int i = 0; i < (levelList.Count -1); i ++) {
                Vector2 levelA = new Vector2(levelList[i].position.x, levelList[i].position.y);
                Vector2 levelB = new Vector2(levelList[i + 1].position.x, levelList[i + 1].position.y);

                float angle = Vector2.Angle (Vector2.right, (levelB - levelA));
                Vector3 normal = Vector3.Cross (Vector2.right,(levelB - levelA));//叉乘求出法线向量
                //angle *= Mathf.Sign (Vector3.Dot(normal,Vector3.up));  //求法线向量与物体上方向向量点乘，结果为1或-1，修正旋转方向
                //Vector3 cross=Vector3.Cross(levelA, levelB);
                angle = normal.z < 0 ? -angle : angle;
                //Debug.Log("Level " + i.ToString() +" to Level " + (i + 1).ToString() + ".The angle is: " + angle.ToString());

                //float distance = Vector2.Distance (Vector2.right, (levelB - levelA));
                float distance = (levelB - levelA).magnitude;
                //Debug.Log("Level " + i.ToString() +" to Level " + (i + 1).ToString() + ".The distance is: " + distance.ToString());
                float scaleFactor = distance * mapPathDefaultLength;

                Vector3 midPoint = new Vector3((levelA.x + levelB.x)/2, (levelA.y + levelB.y)/2, 0);
                //Debug.Log("MidPoint:" + midPoint);
                //有了中点动画和基于距离的缩放系数，就可以放置MapPath了

                GameObject mapPathObject = GameObject.Instantiate<GameObject>(prefabMapPath, midPoint + mapPathOffset , Quaternion.identity, transform);
                //重设mapPath长度
                mapPathObject.transform.localScale = new Vector3 (scaleFactor,1,1);
                //重设mapPath角度
                mapPathObject.transform.rotation = Quaternion.Euler(0,0,angle);
            
                mapPathList[i] = mapPathObject;//存储
            }
        }
        public void updateMapPath () {
            if (levelList.Count <= 1) {
                return;
            }

            for (int i = 0; i < worldMap.playingLevel - 1; i ++) {
                Animator animator;
                animator = mapPathList[i].GetComponentInChildren<Animator>();
            
                animator.Play("beamPathOpen");
            }
        }
        public void Awake () {
            creatLevelList();//关卡数据初始化
            creatLevelIcon();//创建关卡图标
            //initLevelEvent ();//关卡事件初始化
            creatMapPath ();//创建光线路径
            loadLevelProgress();//读取存档进度
            updateLevelIcon ();//根据存档进度更新关卡图标
            updateMapPath ();//根据存档进度更新光线路径
            //Invoke("levelFinished", 3); //levelFinished();//关卡完成时
        }
        public int GetPlayingLevel () {
            loadLevelProgress();
            return worldMap.playingLevel;
        }
        public int GetLevelByDataString (string data) {
            creatLevelList();//关卡数据初始化
            if(data == "null") {
                return -1;
            }
            for (int i = 0; i < levelList.Count; i++) {
                if(levelList[i].dataString == data) {
                    return i + 1;
                }
            }
            return -1;
        }
    }
}
