using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class Time {
    public string whatTime(int seconds) {
        string res;

        int secondsInAnHour = 60 * 60;
        int secondsInAMinute = 60;

        int hours = 0;

        while (seconds >= secondsInAnHour)
        {
            seconds -= secondsInAnHour;
            hours++;
        }

        int minutes = 0;

        while (seconds >= secondsInAMinute)
        {
            seconds -= secondsInAMinute;
            minutes++;
        }

        res = string.Format("{0}:{1}:{2}", hours, minutes, seconds);

        return res;
    }

}


// Powered by FileEdit
// Powered by CodeProcessor
