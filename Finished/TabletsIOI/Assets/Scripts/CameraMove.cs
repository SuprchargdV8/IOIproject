using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 zoomout;
    public Vector3 zoomin;
    public bool zoom;

    public ParticleSystem particles1;
    public ParticleSystem particles2;
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        zoom = false;
        trans = this.GetComponent<Transform>();
        zoomout = new Vector3(0f,0f,-25f);
        zoomin = new Vector3(0f,0f,-15f);
    }

    public void setZoom(){
        zoom = !zoom;
    }

    private bool play = true;
    // Update is called once per frame
    void Update()
    {
        if(zoom){
            if(!particles1.isPlaying && !particles2.isPlaying && !play){
                particles1.Emit(3);
                particles2.Emit(3);
                play = true;
            }
            trans.position = Vector3.Lerp(zoomin, trans.position, 0.995f);
        } else {
            if(play){
                play = false;
            }
            trans.position = Vector3.Lerp(zoomout, trans.position, 0.995f);
        }
    }
}
