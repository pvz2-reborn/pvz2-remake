using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class girdManager : MonoBehaviour
{
    private List<Vector2> gridPointList = new List<Vector2>();
    private List<girds> gridList = new List<girds>();
    // Start is called before the first frame update
    void Start()
    {
        creatGridsBaseColl ();
        //createGridBasePointList ();
        createGridsBaseGird ();
    }
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            //Debug.Log(getGridByMouse());
        }
    }

    private void creatGridsBaseColl () {
        GameObject prefabGird = new GameObject ();
        prefabGird.AddComponent<BoxCollider2D>().size = new Vector2(1.26f, 1.54f);
        prefabGird.GetComponent<BoxCollider2D>().offset = new Vector2(0.05f, 0.38f);
        prefabGird.transform.SetParent(transform);
        prefabGird.transform.position = transform.position;
        prefabGird.name = 1 + "-" + 1;

        for (int i = 0; i <= 6; i++) {
            for(int j = -2; j <= 12; j++) {
                GameObject gird = GameObject.Instantiate<GameObject>(prefabGird, transform.position + new Vector3(1.26f*(j-1), -1.54f*(i-1),0),Quaternion.identity, transform);
                gird.name = i + "," + j;
            }
        }
    }
    private void createGridBasePointList () {
        for (int i = 0; i <= 6; i++) {
            for(int j = -2; j <= 12; j++) {
                //GameObject gird = GameObject.Instantiate<GameObject>(prefabGird, transform.position + new Vector3(1.26f*(j-1), -1.54f*(i-1),0),Quaternion.identity, transform);
                //gird.name = i + "," + j;
                gridPointList.Add(transform.position + new Vector3(1.26f*(j-1), -1.54f*(i-1),0));
            }
        }
    }
    private void createGridsBaseGird () {
        for (int i = 0; i <= 6; i++) {
            for(int j = -2; j <= 12; j++) {
                //GameObject gird = GameObject.Instantiate<GameObject>(prefabGird, transform.position + new Vector3(1.26f*(j-1), -1.54f*(i-1),0),Quaternion.identity, transform);
                //gird.name = i + "," + j;
                //gridPointList.Add(transform.position + new Vector3(1.26f*(j-1), -1.54f*(i-1),0));
                gridList.Add(new girds(new Vector2(i,j), transform.position + new Vector3(1.26f*(j-1), -1.54f*(i-1),0), false));
            }
        }
    }
    public Vector2 getGridByMouse () {
        float dis = 100000000;
        Vector2 point = new Vector2();
        for (int i = 0; i < gridList.Count; i++) {
            if(Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition) ,gridList[i].Position) < dis) {
                dis = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition) ,gridList[i].Position);
                point = gridList[i].Position;
            }
        }
        return point;
    }
}
