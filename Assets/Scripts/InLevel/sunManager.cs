using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class sunManager : MonoBehaviour
{
    public Text sunNumText;
    private Sequence mScoreSequence;
    public int trulySunNum = 50;
    public int beforeSunNum = 50;
    private int afterSunNum = 0;

    private int creatNum = -32768;

    public bool mouseHold = false;

    void Awake() {
        mScoreSequence = DOTween.Sequence();
        mScoreSequence.SetAutoKill(false);
    }

    public void DigitalAnimation() {
        mScoreSequence.Append(DOTween.To(delegate (float value) {
            var temp = Math.Floor(value);
            sunNumText.text = temp + "";
        }, beforeSunNum, afterSunNum, 0.4f));
        beforeSunNum = afterSunNum;
    }

    public Image sunDownImage;
    public void addSunAnimationFirst () {
        //sunDownImage.SetActive(false);
        sunDownImage.enabled = true;
        Invoke("addSunAnimationSecond",0.5f);
    }
    void addSunAnimationSecond () {
        sunDownImage.enabled = false;
    }

    //需要传一个sun对象
    public void addSunNum (sunMain sun) {
        sunNumText = GameObject.Find("Canvas/sunNumBG/Text").GetComponent<Text>();
        trulySunNum += sun.value;
        //sun.selfDestroy();//WIP Anime
        sun.transformToUI();
        afterSunNum += sun.value;
        //addSunAnimationFirst();
        //DigitalAnimation();
    }
    public void useSunNum (int num) {
        sunNumText = GameObject.Find("Canvas/sunNumBG/Text").GetComponent<Text>();
        afterSunNum -= num;
        DigitalAnimation();
    }

    //-------------Creat SUN-------------------

    private GameObject prefabSun;

    //阳光固定从6.0f的位置被创建
    private float creatSunPosY = 6.0f;
    private float creatSunPosZ = 0.0f;
    //阳光从(-2.0f ~ 7.0f)这个X轴之间落下
    private float creatSunMaxPosX = 7.0f;
    private float creatSunMinPosX = -2.0f;
    //阳光在(-3.5f ~ 2.5)这个范围内落地

    private float downSunMaxPosX = 2.5f;
    private float downSunMinPosX = -3.5f;
    
    
    public sunMain creatSun (int sunNum, string creatType) {
        GameObject sunObject = GameObject.Instantiate<GameObject>(prefabSun, Vector3.zero, Quaternion.identity, transform);
        sunMain sun =  sunObject.GetComponent<sunMain>();
        //防止刚体影响下落
        //Rigidbody2D sunRigidBody = sun.GetComponent<Rigidbody2D>();

        //添加图层顺序防止闪烁
        SpriteRenderer sunRender = sunObject.GetComponent<SpriteRenderer>();
        sunRender.sortingOrder = creatNum;
        creatNum += 1;
        //65536个阳光池，一局应该不会有那么多阳光的吧？

        float downY = UnityEngine.Random.Range(downSunMinPosX, downSunMaxPosX);
        float creatX = UnityEngine.Random.Range(creatSunMinPosX, creatSunMaxPosX);
        //float downYPos = UnityEngine.Random.Range(-3.5f, 2.5f);
        //Debug.Log("creat:" + creatX.ToString());
        //Debug.Log("down:" + downY.ToString());
        //why use var is always 0???
        //你妈的原来是没private引擎里自己改了变量，我说呢
        /*
        switch (creatType) {
            case "sky" :
                return sun.initSunFromSky(downY, creatX, creatSunPosY, sunNum);
                break;
            case "sunFlower" :
                return sun.initSunFromSunFlower(creatX, creatSunPosY, sunNum);
                break;
            default :
                return sun.initSunFromSky(downY, creatX, creatSunPosY, sunNum);
                break;
        }*/
        return sun.initSunFromSky(downY, creatX, creatSunPosY, sunNum);
    }
    public sunMain creatSunFromPlant (int sunNum, float creatPosX, float creatPosY) {
        GameObject sunObject = GameObject.Instantiate<GameObject>(prefabSun, Vector3.zero, Quaternion.identity, transform);
        sunMain sun =  sunObject.GetComponent<sunMain>();
        //添加图层顺序防止闪烁
        SpriteRenderer sunRender = sunObject.GetComponent<SpriteRenderer>();
        sunRender.sortingOrder = creatNum;
        creatNum += 1;
        //65536个阳光池，一局应该不会有那么多阳光的吧？

        return sun.initSunFromPlant(creatPosX, creatPosY, sunNum);
    }
    //天上掉落的阳光的数值，0为不掉落
    public void creatSkySun () {
        creatSun(50, "sky");
        //creatSun(50);
        //creatSun(75);
        //creatSun(100);
    }
    private void setMouseHold () {
        if(Input.GetMouseButtonDown(0)) {
            mouseHold = true;
        }
        if(Input.GetMouseButtonUp(0)) {
            mouseHold = false;
        }
    }
    public void startCreatSun () {
        prefabSun = Resources.Load<GameObject>("prefabs/sun");
        InvokeRepeating("creatSkySun", 5, 10);
        //默认是10s一个
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetButtonDown ("Fire1")) {
            //Debug.Log("Mouse Down!");
            mouseHold = true;
            //mouseHold = false;
            Invoke("setMouseHold",0.5f);
        }
        */
        setMouseHold();
    }
}
