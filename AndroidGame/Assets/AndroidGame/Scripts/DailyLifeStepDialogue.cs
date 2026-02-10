using UnityEngine;
using DG.Tweening;
namespace AndroidGame{
    [CreateAssetMenu(fileName = "DailyLifeStepDialogue", menuName = "DailyLifeStep/Dialogue")]
public class DailyLifeStepDialogue : DailyLifeStep
{
    public DialogueContent dialogueContent;
    public override void DoEffect(){
        DailyLifeGameManager.Instance.AwakeDialogue(dialogueContent);
        //DailyLifeGameManager.Instance.NextStep();
    }
}
}