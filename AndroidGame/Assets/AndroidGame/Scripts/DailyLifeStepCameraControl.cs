using UnityEngine;
using DG.Tweening;

namespace AndroidGame{
    [CreateAssetMenu(fileName = "DailyLifeStepCameraControl", menuName = "DailyLifeStep/CameraControl")]
public class DailyLifeStepCameraControl : DailyLifeStep
{
    public Vector2 cameraPosition;
    public float cameraSize;
    public float duration = 1f;
    public float delay = 1f;
    public override void DoEffect(){
        GameObject camera = Camera.main.gameObject;
        Vector3 targetPosition = new Vector3(cameraPosition.x, cameraPosition.y, Camera.main.transform.position.z);
        camera.transform.DOMove(targetPosition, duration);
        camera.GetComponent<Camera>().DOOrthoSize(cameraSize, duration);
        DOVirtual.DelayedCall(duration + delay, DailyLifeGameManager.Instance.NextStep);
    }
}
}