using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class replaceText : MonoBehaviour
{
    public TMPro.TMP_Text ime;
    public TMPro.TMP_Text opis;
    
    public void changeText(string nime, string nopis){
        ime.text = nime;
        opis.text = nopis;
    }
}
