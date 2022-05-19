using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class godMenu : MonoBehaviour {

	void Start () {
		Button btn = this.GetComponent<Button> ();
		if (btn.name == "restartButton") {
			btn.onClick.AddListener (OnClick);
		}
		if (btn.name == "addSunButton") {
			btn.onClick.AddListener (addSun);
		}
	}

	private void OnClick(){
        GameObject.Find("levelManager").SendMessage("doStartLevel"); 
	}
	
	private void addSun () {
		sunManager manager = GameObject.Find("skyManager").GetComponent<sunManager>();
		sunMain sun = manager.creatSun(100, "sky");
		//sun.value = 100;
		//GameObject.Find("skyManager").SendMessage("addSunNum",sun); 
		sun.OnClick();
	}
}