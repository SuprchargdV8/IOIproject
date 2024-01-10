using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class replaceText : MonoBehaviour
{
    public SimpleHelvetica ime;
    //public TMPro.TMP_Text opis;
    
    public void changeText(string nime, string nopis){
        Debug.Log(ime.Text);
        ime.Text = nime;
        ime.GenerateText();
        ime.ApplyMeshRenderer();
    }
}
