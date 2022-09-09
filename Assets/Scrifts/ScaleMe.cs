using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScaleMe : MonoBehaviour
{
    public void Start()
    {
        //isLoop = true;
        //if (isLoop)
        //    this.transform.DOScale(scale, duration).SetLoops(-1, LoopType.Yoyo);
        //else
        //    this.transform.DOScale(scale, duration); 
        Move();
    }
    public void Move()
    {
        transform.DOLocalMoveX(-96, 75 * Time.deltaTime).OnComplete(() =>
        {
            transform.DOLocalMoveX(108, 75 * Time.deltaTime).OnComplete(() =>
           Move());                            
        });
        
  
    }





}
