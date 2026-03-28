using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
namespace AndroidGame{
[CreateAssetMenu(fileName = "DailyLifeStepAnimation", menuName = "DailyLifeStep/Brench")]
public class DailyLifeStepBrench : DailyLifeStep
{
    [SerializeField]
    public List<Conditions> conditions;
    public List<DailyLifeStep> steps0;
    public List<DailyLifeStep> steps1;
    public List<DailyLifeStep> steps2;
    public List<DailyLifeStep> steps3;
    public override void DoEffect(){
        Debug.Log(conditions.Count);
        if(conditions.Count > 0 && CheckConditions(conditions[0])){
            Debug.Log("Change To Brench 0");
            DailyLifeGameManager.Instance.AddStep(steps0);
            DailyLifeGameManager.Instance.NextStep();
            return;
        }
        if(conditions.Count > 1 && CheckConditions(conditions[1])){
            Debug.Log("Change To Brench 1");
            DailyLifeGameManager.Instance.AddStep(steps1);
            DailyLifeGameManager.Instance.NextStep();
            return;
        }
        if(conditions.Count > 2 && CheckConditions(conditions[2])){
            Debug.Log("Change To Brench 2");
            DailyLifeGameManager.Instance.AddStep(steps2);
            DailyLifeGameManager.Instance.NextStep();
            return;
        }
        Debug.Log("Change To Brench 3");
        DailyLifeGameManager.Instance.AddStep(steps3);
        DailyLifeGameManager.Instance.NextStep();
    }
    [System.Serializable] public class Conditions{
        public List<Condition> condition;
    }
    [System.Serializable] public class Condition{
        public bool isMood;
        public bool higherThan;
        public int compareValue;
    }
    public bool CheckConditions(Conditions conditions){
        foreach(var cond in conditions.condition){
            if(cond.isMood){
                if(cond.higherThan){
                    if(GameData.Instance.MoodValue < cond.compareValue){
                        return false;
                    }
                }else{
                    if(GameData.Instance.MoodValue >= cond.compareValue){
                        return false;
                    }
                }
            }
            else{
                if(cond.higherThan){
                    if(GameData.Instance.EvolutionValue < cond.compareValue){
                        return false;
                    }
                }else{
                    if(GameData.Instance.EvolutionValue >= cond.compareValue){
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
}