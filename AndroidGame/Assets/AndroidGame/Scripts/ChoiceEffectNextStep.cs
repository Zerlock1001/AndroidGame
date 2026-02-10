using UnityEngine;
namespace AndroidGame{
[CreateAssetMenu(fileName = "ChoiceEffectNextStep", menuName = "ChoiceEffect/NextStep")]
public class ChoiceEffectNextStep : ChoiceEffect
{
    public override void DoEffect(){
        DailyLifeGameManager.Instance.NextStep();
    }
}
}
