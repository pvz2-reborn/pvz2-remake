using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class redBannerManager : MonoBehaviour
{
    private GameObject banner;
    private Text bannerText;

    private AudioClip startSound;
    private AudioSource audioSource;

    Vector3 normalScale;

    
    void Awake()
    {
        banner = GameObject.Find("Canvas/redBanner");
        bannerText = banner.GetComponent<Text>();
        startSound = Resources.Load<AudioClip>("audios/BGS/readysetplant");
        audioSource = GetComponent<AudioSource>();

        normalScale = new Vector3(1.0f, 1.0f, 1.0f);
        //testBanner();
        //showBannerNomal("testbanner", 2.0f);
    }
    public void testBanner () {
        //bannerText.text = "Test!";
        showBannerNomal("Test!", 2.0f);
    }
    public void clear () {
        bannerText.text = "";
    }
    public void showBannerNomal (string text, float livingTime) {
        bannerText.text = text;
        Invoke("clear", livingTime);
    }
    public void showBannerWithBGS (string text, float livingTime, string nameOfBGS) {
        //
        showBannerNomal(text, livingTime);
    }
    public void backNormalScale () {
        banner.transform.localScale = normalScale;
    }
    public void changeScale (Vector3 newScale, float doTime, float livingTime) {
        banner.transform.DOScale(newScale, doTime);
        Invoke("backNormalScale", livingTime);
    }
    public void showStartGameBanner () {
        Sequence seq = DOTween.Sequence();//执行队列
        seq.AppendCallback(() => {
            showBannerNomal("Ready...", 0.58f);
            audioSource.PlayOneShot(startSound);
            //banner.changeScale(new Vector3(1.1f, 1.1f, 1.1f));
            //banner.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.6f);
            //banner.transform.localScale = normalScale;
            changeScale(new Vector3(1.3f, 1.3f, 1.3f), 0.57f, 0.59f);
        });
        seq.AppendInterval(0.6f);
        seq.AppendCallback(() => {
            showBannerNomal("Set...", 0.58f);
            //banner.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.6f);
            //banner.transform.localScale = normalScale;
            changeScale(new Vector3(1.2f, 1.2f, 1.2f), 0.58f, 0.6f);
        });
        seq.AppendInterval(0.6f);
        seq.AppendCallback(() => {
            showBannerNomal("PLANT!", 0.58f);
            //banner.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.6f);
            //banner.transform.localScale = normalScale;
            changeScale(new Vector3(1.5f, 1.5f, 1.5f), 0.01f, 0.6f);
        });
        seq.AppendCallback(() => {
            
        });
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
