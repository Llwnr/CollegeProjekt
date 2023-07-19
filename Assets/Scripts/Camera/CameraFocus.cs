using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraFocus : MonoBehaviour, IDashObserver
{
    public static CameraFocus instance {get; private set;}

    private CinemachineVirtualCamera vCam;
    private float origOrthoSize;
    [SerializeField]private float focusedOrthoSize;

    [SerializeField]private float speed;

    private bool toZoom = false;

    //For chromatic aberration
    [SerializeField]private Volume postProcessVolume;
    private ChromaticAberration chromaticAberration;
    private LensDistortion lensDistortion;

    private BallDash ballDash;

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
        if(postProcessVolume.profile.TryGet<ChromaticAberration>(out chromaticAberration)){
            Debug.Log("success");
        }
        if(postProcessVolume.profile.TryGet<LensDistortion>(out lensDistortion)){

        }

        //For camera to zoom while dashing
        ballDash = GameObject.FindWithTag("Player").GetComponent<BallDash>();
        ballDash.AddDashObserver(this);
    }

    private void OnDestroy() {
        ballDash.RemoveDashObserver(this);
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

    public void DashStart()
    {
        chromaticAberration.intensity.value = 0.7f;
        lensDistortion.intensity.value = -0.2f;
    }

    public void DashEnd()
    {
        chromaticAberration.intensity.value = 0;
        lensDistortion.intensity.value = 0;
    }
}
