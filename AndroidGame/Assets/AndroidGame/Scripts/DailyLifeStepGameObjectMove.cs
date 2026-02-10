using UnityEngine;
using DG.Tweening;
namespace AndroidGame{
    [CreateAssetMenu(fileName = "DailyLifeStepGameObjectMove", menuName = "DailyLifeStep/GameObjectMove")]
public class DailyLifeStepGameObjectMove : DailyLifeStep
{
    public string gameObjectName;
    public Vector3 targetPosition;
    public float duration = 2f;
    public override void DoEffect(){
        GameObject gameObject = GameObject.Find(gameObjectName);
        if(gameObject != null){
            gameObject.transform.DOMove(targetPosition, duration);
        }
        DOVirtual.DelayedCall(duration, DailyLifeGameManager.Instance.NextStep);
    }
}
}