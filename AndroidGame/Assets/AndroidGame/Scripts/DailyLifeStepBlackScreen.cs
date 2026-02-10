using UnityEngine;
using DG.Tweening;
namespace AndroidGame{
    [CreateAssetMenu(fileName = "DailyLifeStepBlackScreen", menuName = "DailyLifeStep/BlackScreen")]
public class DailyLifeStepBlackScreen : DailyLifeStep
{
    public float duration = 1f;
    public bool isFadeIn = true;
    public override void DoEffect(){
        if(isFadeIn){
            BlackScreen.Instance.FadeIn(duration);
        }else{
            BlackScreen.Instance.FadeOut(duration);
        }
        DOVirtual.DelayedCall(duration, DailyLifeGameManager.Instance.NextStep);
    }
}
}