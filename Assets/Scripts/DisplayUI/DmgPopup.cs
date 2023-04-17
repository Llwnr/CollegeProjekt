using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgPopup : MonoBehaviour
{
    [SerializeField]private float duration = 1f;
    private float timer;
    private TextMeshProUGUI textBox;
    // Start is called before the first frame update
    void Start()
    {
        timer = duration;
        textBox = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //Starting phase
        if(timer > duration*0.5f){
            textBox.fontSize += Time.deltaTime*0.8f;
            transform.position += new Vector3(0, Time.deltaTime*2, 0);
        }else if(timer < duration*0.5){
            textBox.fontSize -= Time.deltaTime;
            transform.position -= new Vector3(0, Time.deltaTime, 0);
        }

        if(timer < 0){
            Destroy(gameObject);
        }
    }
}
