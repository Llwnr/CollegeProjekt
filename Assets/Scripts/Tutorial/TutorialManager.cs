using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance {get; private set;}

    [SerializeField]private string[] tutorialTexts;
    [SerializeField]private GameObject triggers;
    private TextMeshProUGUI textBox;

    private int index = 0;

    private void Awake() {
        if(instance != null){
            Debug.LogError("More than one tutorial managers");
            return;
        }
        instance = this;
        textBox = GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        UpdateText();
    }

    public void UpdateText(){
        //When one tutorial is complete, show the next one
        textBox.text = tutorialTexts[index];
        index++;
    }
}
