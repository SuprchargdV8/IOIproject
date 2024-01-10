using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 zoomout;
    public Vector3 zoomin;
    public bool zoom;

    public ParticleSystem particles;
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        zoom = false;
        trans = this.GetComponent<Transform>();
        zoomout = new Vector3(0f,0f,-15f);
        zoomin = new Vector3(0f,0f,-10f);
    }

    public void setZoom(){
        zoom = !zoom;
    }


    // Update is called once per frame
    void Update()
    {
        if(zoom){
            particles.Play();
            trans.position = Vector3.Lerp(zoomin, trans.position, 0.995f);
        } else {
            particles.Stop();
            trans.position = Vector3.Lerp(zoomout, trans.position, 0.995f);
        }
    }
}
