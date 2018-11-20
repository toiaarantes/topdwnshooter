using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    public Animator cameraAnim;

    public void CamShake()
    {
        cameraAnim.SetTrigger("shake");
    }
}
