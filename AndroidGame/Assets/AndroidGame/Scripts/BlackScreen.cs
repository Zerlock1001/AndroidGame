using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace AndroidGame{
public class BlackScreen : MonoBehaviour
{
    public static BlackScreen Instance;
    public Image image;
    public void Awake()
    {
        Instance = this;
        image = GetComponent<Image>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeIn(float duration)
    {
        image.gameObject.SetActive(true);
        image.DOFade(1, duration);
    }
    public void FadeOut(float duration)
    {
        image.gameObject.SetActive(true);
        image.DOFade(0, duration).OnComplete(() => {
            image.gameObject.SetActive(false);
        });
    }
}
}