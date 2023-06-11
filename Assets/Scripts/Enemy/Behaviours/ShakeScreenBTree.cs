using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ShakeScreenBTree : ActionNode
{
    public float shakeIntensity, shakeDuration;
    private CinemachineShake shakeManager;

    protected override void OnStart() {
        shakeManager = GameObject.FindWithTag("vCam").GetComponent<CinemachineShake>();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        shakeManager.ShakeCamera(shakeIntensity, shakeDuration);
        return State.Success;
    }
}
