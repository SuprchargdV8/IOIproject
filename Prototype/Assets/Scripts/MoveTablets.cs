using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveTablets : MonoBehaviour
{
    public GameObject tablet;
    public TextAsset textFile;
    private int selectedTablet;
    private Transform tabletTrans;
    public float scaler = 0.01f;
    private int min, max;
    void Awake(){
        // generate tablets
        string[] text = textFile.text.Split("\n");
        Debug.Log(text[1]);
        int n = text.Length;
        Debug.Log(n);
        min = -(n / 2)*6; max = (n / 2 - 1) *6;
        int cnt = 0;
        for(int i = -(n / 2 - 1); i < n/2 + 1; i++){
            float xLoc = i*6;
            GameObject temp = Instantiate(tablet, new Vector3(xLoc, 0, 0), Quaternion.Euler(-90, 0, 0));
            temp.transform.parent=transform;
            temp.GetComponentInChildren<replaceText>().changeText(text[cnt].Split(";")[0],text[cnt].Split(";")[1]);
            cnt++;
        }
        selectedTablet = 0;
        tabletTrans = this.GetComponent<Transform>();
        move(0f);
    }

    public void move(float movement){

        float temp = tabletTrans.position[0] - movement*scaler;
        bool tooBig = temp > max;
        bool tooSmall = temp < min;

        if(tooBig){
            tabletTrans.position = new Vector3(max,0,0);
        } else if(tooSmall){
            tabletTrans.position = new Vector3(min,0,0);
        } else {
            tabletTrans.position = new Vector3(temp,0,0);
        }
    }
}
