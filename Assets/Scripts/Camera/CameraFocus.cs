using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFocus : MonoBehaviour
{
    public static CameraFocus instance {get; private set;}

    private CinemachineVirtualCamera vCam;
    private float origOrthoSize;
    [SerializeField]private float focusedOrthoSize;

    [SerializeField]private float speed;

    private bool toZoom = false;

    private void Awake() {
        if(!instance){
            instance = this;
        }else{
            Debug.LogError("More than one camera focus");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        origOrthoSize = vCam.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(toZoom){
            vCam.m_Lens.OrthographicSize = Mathf.Lerp(vCam.m_Lens.OrthographicSize, focusedOrthoSize, Time.deltaTime*speed);
        }else{
            vCam.m_Lens.OrthographicSize = Mathf.Lerp(vCam.m_Lens.OrthographicSize, origOrthoSize, Time.deltaTime*speed*2.5f);
        }
    }

    public void SetZoom(bool value){
        toZoom = value;
    }


}
