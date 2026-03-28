using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image targetImage; 
    public Sprite[] images;   

    private int currentIndex = 0;

    public void SwitchImage()
    {
        if (images.Length == 0) return;

        currentIndex++;

        if (currentIndex >= images.Length)
        {
            currentIndex = 0;
        }

        targetImage.sprite = images[currentIndex];
    }
}