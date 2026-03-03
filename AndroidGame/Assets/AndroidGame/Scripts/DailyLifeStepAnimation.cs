using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
namespace AndroidGame{
[CreateAssetMenu(fileName = "DailyLifeStepAnimation", menuName = "DailyLifeStep/Animation")]
public class DailyLifeStepAnimation : DailyLifeStep
{
    public string GameObjectName;
    public AnimationClip animationClip;
    public float duration = 1f;

    public override void DoEffect(){
        GameObject gameObject = GameObject.Find(GameObjectName);
        if(gameObject != null){
            gameObject.GetComponent<Animator>().Play(animationClip.name, 0, 0f);
            DOVirtual.DelayedCall(duration, DailyLifeGameManager.Instance.NextStep);
        }
    }
}
}