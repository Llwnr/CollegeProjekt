using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRangeExtendByMouse : MonoBehaviour
{
    private CinemachineTransposer vCamTransposer;
    private Transform player;
    private Vector3 cameraPos;
    [SerializeField]private Vector2 offset;
    [SerializeField]private float offsetMultiplier;
    [SerializeField]private float lerpSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        vCamTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = player.transform.position;
        //Lerp offset to follow mouse position
        offset = Vector2.Lerp(offset, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - cameraPos).normalized, Time.deltaTime*lerpSpeed);
        //if(Mathf.Abs(offset.x) < 0.01f && Mathf.Abs(offset.y) < 0.01f) return;
        vCamTransposer.m_FollowOffset = offset*offsetMultiplier;
        vCamTransposer.m_FollowOffset.z = -10;
    }
}
