using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
namespace AndroidGame
{
    [CreateAssetMenu(fileName = "DailyLifeStepDelay", menuName = "DailyLifeStep/Delay")]
    public class DailyLifeStepDelay : DailyLifeStep
    {
        public float duration = 1f;

        public override void DoEffect()
        {
            DOVirtual.DelayedCall(duration, () =>
            {
                DailyLifeGameManager.Instance.NextStep();
            });
        }
    }
}