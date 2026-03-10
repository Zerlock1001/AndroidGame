using UnityEngine;
namespace AndroidGame{
    [CreateAssetMenu(fileName = "ChoiceEffectMoodChange", menuName = "Scriptable Objects/ChoiceEffectMoodChange")]

public class ChoiceEffectMoodChange : ChoiceEffect
{
    public int moodChange = 0;
    public int evolutionChange = 0;
    public override void DoEffect(){
        if(GameManager.instance == null){
            return;
        }
        GameManager.instance.AddMoodValue(moodChange);
        GameManager.instance.AddEvolutionValue(evolutionChange);
    }
}
}
