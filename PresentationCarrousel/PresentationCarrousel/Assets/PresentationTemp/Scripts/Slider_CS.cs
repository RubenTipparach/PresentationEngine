// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Slider_CS : MonoBehaviour
{

    Texture[] imageArray;
    int currentImage;
    Rect imageRect;
    Rect buttonRect;

    void Start()
    {
        currentImage = 0;
        imageRect = new Rect(0, 0, Screen.width, Screen.height / 1);
        buttonRect = new Rect(Screen.width - Screen.height / 4, 600 - Screen.height / 10, Screen.width / 20, Screen.height / 20);
    }

    void OnGUI()
    {
        GUI.Label(imageRect, imageArray[currentImage]);
        if (GUI.Button(buttonRect, "Next"))
            currentImage++;

        if (currentImage > 2)
            currentImage = 0;

    }
}