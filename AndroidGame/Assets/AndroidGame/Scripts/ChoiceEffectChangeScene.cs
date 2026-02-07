using UnityEngine;
using UnityEngine.SceneManagement;
namespace AndroidGame{
[CreateAssetMenu(fileName = "ChoiceEffectChangeScene", menuName = "Scriptable Objects/ChoiceEffectChangeScene")]
public class ChoiceEffectChangeScene : ChoiceEffect
{
    public string sceneName;
    public override void DoEffect(){
        Debug.Log("ChangeScene to " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
}
