using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedPackNormal : seedPackMain
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectCard () {
        //imageList[6].enabled = true;
        viewSelectedPriceTab(true);
    }
    public void deSelectCard () {
        viewSelectedPriceTab(false);
        //imageList[6].enabled = false;
    }

}
