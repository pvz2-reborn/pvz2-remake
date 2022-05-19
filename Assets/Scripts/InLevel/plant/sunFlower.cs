using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using Plant;


    public class sunFlower : MonoBehaviour {
        public float HP = 0;
        public int sunCost = 0;
        public float coolDown = 1.0f;
        public int creatCD = 5;//30
        public int sunValue = 50;
        //Vector3 creatPos = transform.position;
        //sunManager manager = GameObject.Find("skyManager").GetComponent<sunManager>();
        
        private Animator animator;
        public void creat () {
            sunManager manager = GameObject.Find("skyManager").GetComponent<sunManager>();
            Sequence seq = DOTween.Sequence();//执行队列
            seq.AppendCallback(() => {
                animator.Play("sunFlowerProduct1");
            });
            //seq.Append()
            seq.AppendInterval(1.25f);
            seq.AppendCallback(() => {
                sunMain sun = manager.creatSunFromPlant(50, transform.position.x, transform.position.y);
            });
             //sun.jump();
            seq.AppendCallback(() => {
                //animator.Play("sunFlowerProduce1");
                animator.Play("sunFlowerProduct2");
            });
            seq.AppendInterval(1.25f);
            seq.AppendCallback(() => {
                animator.Play("sunFlower");
            });
		    
            Debug.Log("flower action!");
            //return true;
        }

        void Start() {
            animator = GetComponentInChildren<Animator>();
            //Debug.Log("creatCD:" + creatCD.ToString());
            InvokeRepeating("creat", 5, creatCD);
            sunCost = 50;//
            //plant = FindObjectOfType<basePlant>();
            //Debug.Log("Cost:" + this.sunCost.ToString());
        }

        
    }


