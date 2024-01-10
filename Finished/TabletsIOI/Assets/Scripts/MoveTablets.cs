using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveTablets : MonoBehaviour
{
    public GameObject tablet;
    public TextAsset textFile;
    private int selectedTablet;
    private Transform[] tabletTrans;
    public float scaler = 0.01f;
    void Awake(){
        // generate tablets
        string[] text = textFile.text.Split("\n");
        int n = text.Length;
        Debug.Log(n);
        int cnt = 0;

        tabletTrans = new Transform[n];

        for(int i = -(n / 2 - 1); i < n/2 + 1; i++){
            float xLoc = i*11;
            GameObject temp = Instantiate(tablet, new Vector3(xLoc, 0, 0.01f*(xLoc*xLoc)), Quaternion.Euler(0, 0, 0));
            temp.transform.parent=transform;
            temp.GetComponentInChildren<replaceText>().changeText(text[cnt].Split(";")[0],text[cnt].Split(";")[1]);
            tabletTrans[cnt] = temp.GetComponent<Transform>();
            cnt++;
        }
        selectedTablet = 0;
        move(0f);
    }

    public void move(float movement){
        int n = tabletTrans.Length;
        float[] temps = new float[n];
        for(int i = 0; i < n; i++){
            temps[i] = Mathf.Round((tabletTrans[i].position[0] - movement*scaler) * 10) / 10;
        }
        Debug.Log(temps[0]);
        bool tooBig = temps[0] > 0;
        bool tooSmall = temps[n-1] < 0;

        if(!tooBig && !tooSmall){
            for(int i = 0; i < n; i++){
                tabletTrans[i].position = new Vector3(temps[i],0,0.01f*(temps[i]*temps[i]));
            }
        }
    }
}
