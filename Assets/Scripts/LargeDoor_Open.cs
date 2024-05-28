using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDoor_Open : MonoBehaviour
{
    public Animator mAnimator;
    public void OpenDoor()
    {
        mAnimator.SetTrigger("OpenLeft");
        mAnimator.SetTrigger("OpenRight");
    }
}
