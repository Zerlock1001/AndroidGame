using UnityEngine;

namespace AndroidGame{
    [CreateAssetMenu(fileName = "DailyLifeStepChangeStates", menuName = "DailyLifeStep/StepChangeStates")]
public class DailyLifeStepChangeStates : DailyLifeStep
{
    public GameManager.GameState newGameState;
    public override void DoEffect(){
        DailyLifeGameManager.Instance.currentGameState = newGameState;
        //Debug.Log("DailyLifeGameManager.Instance.currentGameState: " + DailyLifeGameManager.Instance.currentGameState);
        DailyLifeGameManager.Instance.NextStep();
    }
}
}