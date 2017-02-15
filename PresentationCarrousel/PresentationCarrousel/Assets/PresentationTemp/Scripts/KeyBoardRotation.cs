// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class KeyBoardRotation : MonoBehaviour
{

    [SerializeField]
    float rotAmount = 90.0f;

    [SerializeField]
    Vector3 destEuler = Vector3.zero;

    [SerializeField]
    float speed = 5.0f;

    private Vector3 currEuler;

    void Start()
    {
        currEuler = destEuler;
        transform.eulerAngles = destEuler;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            destEuler.y += -rotAmount;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            destEuler.y += rotAmount;
        }


        currEuler = Vector3.Lerp(currEuler, destEuler, Time.deltaTime * speed);
        transform.eulerAngles = currEuler;
    }
}