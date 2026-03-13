using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace AndroidGame{
    [CreateAssetMenu(fileName = "DailyLifeStepChangeSprite", menuName = "DailyLifeStep/Step/ChangeSprite")]
public class DailyLifeStepChangeSprite : DailyLifeStep
{
    public List<Sprite> sprites;
    public float changeInterval = 1f;
    public string gameObjectName;
    int currentSpriteIndex = 0;
    public override void DoEffect()
    {
        DailyLifeGameManager.Instance.StartCoroutine(ChangeSprite());
        DailyLifeGameManager.Instance.NextStep();
    }

    IEnumerator ChangeSprite()
    {
        if (sprites == null || sprites.Count == 0) yield break;
        var sr = GameObject.Find(gameObjectName)?.GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        while (true)
        {
            sr.sprite = sprites[currentSpriteIndex];
            currentSpriteIndex++;
            if (currentSpriteIndex >= sprites.Count)
                currentSpriteIndex = 0;
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
}