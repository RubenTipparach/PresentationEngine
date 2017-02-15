// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;
using System;

public class DateTimeGen : MonoBehaviour
{


    private DateTime theTime = DateTime.Now;

    void Start()
    {

    }

    void Update()
    {


        var days = theTime.DayOfWeek;
        var day = theTime.Day;
        var month = theTime.Month;
        var year = theTime.Year;
        var hours = theTime.Hour;
        var minutes = theTime.Minute;
        var seconds = theTime.Second;

        GetComponent< GUIText > ().text = days + " " + day + " / " + month + " / " + year + " // " + hours + ":" + minutes + ":" + seconds;

    }
}