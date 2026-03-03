using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
namespace AndroidGame{
[CreateAssetMenu(fileName = "DailyLifeStepChangeScene", menuName = "DailyLifeStep/ChangeScene")]
public class DailyLifeStepChangeScene : DailyLifeStep
{
    public string SceneName;
    public float delay = 0f;

    public override void DoEffect(){
        DOVirtual.DelayedCall(delay, () => {
            SceneManager.LoadScene(SceneName);
        });
    }
}
}