using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake instance {get; private set;}

    private CinemachineVirtualCamera vCam;
    private Cinemachine.CinemachineBasicMultiChannelPerlin vCamPerlin;
    private float shakeTimer = 0;
    private float maxShakeTimer;
    private float maxShakeIntensity;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null){
            Debug.LogError("More than two instance of cinemachine shake");
            return;
        }
        instance = this;
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time){
        vCamPerlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        vCamPerlin.m_AmplitudeGain = 0f;
        shakeTimer = time;
        maxShakeIntensity = shakeTimer;
        maxShakeIntensity = intensity;
    }

    private void Update() {
        if(shakeTimer > 0){
            shakeTimer -= Time.deltaTime;
            //Slowly reduce shake intensity
            vCamPerlin.m_AmplitudeGain = Mathf.Lerp(maxShakeIntensity, 0, 1-(shakeTimer/maxShakeTimer));
        }
    }
}
