using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class sunMain : MonoBehaviour
{
    private float downTargetPosY;
    private float downSpeed = 1.2f;

    private bool canSunDown = true;

    private bool beClicked = false;

   
    //private bool mouseHold = false;

    public int value = 50;

    //private UnityEvent leftClick;

    
    //private void OnMouse
    /*
    private void OnMouseDown () {
        Debug.Log("Clicked sun!");
        selfDestroy();
    }*/
    private int chooseBGS = 1;
    private AudioSource audioSource;


    public void OnClick () {
        
        chooseBGS = UnityEngine.Random.Range(1,5);
        Debug.Log("BGS:" + chooseBGS.ToString());
        //playBGS;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("audios/BGS/sunByPickUp" + chooseBGS.ToString());
        audioSource.Play();

        
        sunManager manager = GameObject.Find("skyManager").GetComponent<sunManager>();
        canSunDown = false;
        manager.addSunNum(this);
        //selfDestroy();
        
    }
    private void OnMouseOver() {
        sunManager manager = GameObject.Find("skyManager").GetComponent<sunManager>();
        if(manager.mouseHold && !beClicked) {
            //Debug.Log("Pickuped sun!");
            //selfDestroy();
            beClicked = true;
            OnClick();
        }
    }
    public void selfDestroy () {
        Destroy(gameObject);
    }

    private float UI_Alpha = 1;             //初始化时让UI显示
    private float alphaSpeed = 1.0f;          //渐隐渐显的速度
    private CanvasGroup canvasGroup;
    private SpriteRenderer spriteRenderer;
    public void UI_FadeOut_Event()
    {
        UI_Alpha = 0;
        canvasGroup.blocksRaycasts = false;     //不可以和该对象交互
    }
    //Transform sunObject = this;
    public void transformToUI () {
        canvasGroup = GetComponent<CanvasGroup>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sunManager manager = GameObject.Find("skyManager").GetComponent<sunManager>();
        Invoke("UI_FadeOut_Event",0.2f);
        //阳光平滑淡出
        Tweener tweener = gameObject.transform.DOMove(new Vector2(-8.27f, 4.57f), 1.4f);
        
       

        //tweener.SetEase(Ease.Linear);
        //selfDestroy();
        tweener.onComplete = delegate () {
            //Debug.Log("移动完毕事件");
            manager.addSunAnimationFirst();
            manager.DigitalAnimation();
            selfDestroy();
            //UI_FadeOut_Event();
        };
    }

    public sunMain initSunFromSky (float downTargetPosY, float creatPosX, float creatPosY, int sunValue) {
        value = sunValue;
        this.downTargetPosY = downTargetPosY;
        transform.position = new Vector2(creatPosX, creatPosY);
        //计算一个缩放   
        /*
            5 = 0.5
            25 = 0.7
            50 = 1
            75 = 1.3
        */
        float zoom;
        switch (sunValue)
        {
            case 0  : zoom = 0.0f; break;
            case 5  : zoom = 0.5f; break;
            case 25 : zoom = 0.7f; break;
            case 50 : zoom = 1.0f; break;
            case 75 : zoom = 1.3f; break;
            case 100: zoom = 1.6f; break;
            default : zoom = 1.0f; break;
        }
        transform.localScale = new Vector3(zoom, zoom, 1.0f);

        return this;
    }
    private Rigidbody2D sunRigidBody;
    private bool isRigid = false;
    public float lineY;
    public sunMain initSunFromPlant (float creatPosX, float creatPosY, int sunValue) {
        sunRigidBody = GetComponent<Rigidbody2D>();
        canSunDown = false;
        value = sunValue;
        transform.position = new Vector2(creatPosX, creatPosY + 0.695471f);

        lineY = creatPosY - 0.663f;

        //dojump
        isRigid = true;
        sunRigidBody.gravityScale = 1f;
        sunRigidBody.velocity += new Vector2(0, 3);

        float sunJumpForce = UnityEngine.Random.Range(-0.5f ,0.51f);
        Vector2 force = new Vector2(sunJumpForce, 1);

        sunRigidBody.AddForce(force * 50);


        float zoom;
        switch (sunValue)
        {
            case 0  : zoom = 0.0f; break;
            case 5  : zoom = 0.5f; break;
            case 25 : zoom = 0.7f; break;
            case 50 : zoom = 1.0f; break;
            case 75 : zoom = 1.3f; break;
            case 100: zoom = 1.6f; break;
            default : zoom = 1.0f; break;
        }
        transform.localScale = new Vector3(zoom, zoom, 1.0f);

        return this;
    }
    // Start is called before the first frame update
    //public Transform target;
    void Start()
    {
        //Invoke("selfDestroy", 10.0f);
        //target = this.transform;
        //Destroy(target.gameObject, 5);
        //leftClick.AddListener(new UnityAction(ButtonLeftClick));
    }

    // Update is called once per frame
    void Update()
    {
        if(isRigid) {
            if(transform.position.y <= lineY) {
                //sunRigidBody.Sleep();
                Destroy(sunRigidBody);
            }
        }
        //if(transform.position.y <= downTargetPosY) return;
        //transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
        if(canSunDown) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, downTargetPosY, 0.0f), downSpeed * Time.deltaTime);
            if(transform.position.y <= downTargetPosY) {
                canSunDown = false;
            }
                
        }

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
                spriteRenderer.color = new Vector4(1.0f, 1.0f, 1.0f, canvasGroup.alpha);
            }
            //Debug.Log("doing!");
        }
        /*
        if(Input.GetButtonDown ("Fire1")) {
            //Debug.Log("Mouse Down!");
            mouseHold = true;
        }
        else {
            mouseHold = false;
        }*/
        
        
    }
}
