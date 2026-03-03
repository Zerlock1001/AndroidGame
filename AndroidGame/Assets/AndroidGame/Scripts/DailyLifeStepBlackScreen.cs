using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
namespace AndroidGame{
    [CreateAssetMenu(fileName = "DailyLifeStepBlackScreen", menuName = "DailyLifeStep/BlackScreen")]
public class DailyLifeStepBlackScreen : DailyLifeStep
{
    public float duration = 1f;
    public bool isFadeIn = true;
    public Sprite sprite;
    public override void DoEffect(){
        if(sprite != null){
            BlackScreen.Instance.GetComponent<Image>().sprite = sprite;
        }
        if(isFadeIn){
            BlackScreen.Instance.FadeIn(duration);
        }else{
            BlackScreen.Instance.FadeOut(duration);
        }
        DOVirtual.DelayedCall(duration, DailyLifeGameManager.Instance.NextStep,false);
    }
}
}