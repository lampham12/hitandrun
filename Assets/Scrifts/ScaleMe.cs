using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScaleMe : MonoBehaviour
{
    public float scale = 1.1f;
    public float duration = 0.2f;
    public bool isLoop;


    public void Start()
    {
        isLoop = true;
        if (isLoop)
            this.transform.DOScale(scale, duration).SetLoops(-1, LoopType.Yoyo);
        else
            this.transform.DOScale(scale, duration);
    }

    
}
