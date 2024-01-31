using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class replaceText : MonoBehaviour
{
    public SimpleHelvetica year;
    public Transform yearT;
    public SimpleHelvetica award;
    public Transform awardT;
    public SimpleHelvetica names;
    public Transform namesT;
    
    public void changeText(string line){
        string[] splits = line.Split(",");
        string temp = "";
        float xPos = 0f;
        Vector3 rand = namesT.position;
        for(int i = 0; i < splits.Length;i++){
            switch (i){
                case 0:
                    year.Text = splits[i];
                    xPos = year.GenerateText();
                    year.ApplyMeshRenderer();
                    break;
                case 1:         
                    award.Text = splits[i];
                    xPos = award.GenerateText();
                    award.ApplyMeshRenderer();
                    break;
                default:
                    temp = string.Concat(string.Concat(temp, "\n"), splits[i]);
                    break;
            }
        }
        Debug.Log(temp);
        names.Text = temp;
        xPos = names.GenerateText();
        names.ApplyMeshRenderer();
        rand = namesT.position;
    }
}
