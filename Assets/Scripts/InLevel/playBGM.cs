using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playBGM : MonoBehaviour
{
    //BGM总控制脚本

    //public AudioClip gameBGM;
    private AudioSource audioSource;
    private string BGMname;
    // Start is called before the first frame update
    public void playInternalBGM (string BGMname) {
        BGMname = BGMname;
        Debug.Log("Nowplaying: "+BGMname);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("audios/BGM/"+BGMname);
        audioSource.Play();
    }
    public void playExternalBGM (string BGMforder) {

    }
    public void endBGM () {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }
    //BGMfile needs to place in BGM/ forder.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
