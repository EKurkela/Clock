using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    //analog clock hands
    public GameObject secondHand;
    public GameObject minuteHand;
    public GameObject hourHand;

    //digital clock slot
    public Text Digi;
    
    string oldSeconds;// variable used for update checking

    void Update()
    {
        //updates clockhand rotation only every second not every frame
        string seconds = System.DateTime.UtcNow.ToString("ss");
        if (seconds != oldSeconds)
        {
            UpdateTimer();
        }
        oldSeconds = seconds;
    }

    //clock uptater used iTween for easy animation
    void UpdateTimer()
    {
        int secondsInt = int.Parse(System.DateTime.Now.ToString("ss"));// seconds of current time
        int minutesInt = int.Parse(System.DateTime.Now.ToString("mm"));// minutes of current time
        int hoursInt = int.Parse(System.DateTime.Now.ToString("hh"));// hours of current time  
        
        iTween.RotateTo(secondHand, iTween.Hash("z", secondsInt * 6 * -1, "time", 1, "easetype", "easeOutQuint"));//second hand rotation with iTween
        iTween.RotateTo(minuteHand, iTween.Hash("z", minutesInt * 6 * -1, "time", 1, "easetype", "easeOutElastic"));//minute hand rotation with iTween
        float hourDistance = (float)(minutesInt) / 60f; //helper variable for moving hour hand
        iTween.RotateTo(hourHand, iTween.Hash("z", (hoursInt + hourDistance) * 360 / 12 * -1, "time", 1, "easetype", "easeOutQuint"));//hour hand rotation with iTween
                
        Digi.text = System.DateTime.Now.ToString("HH") + ":" + minutesInt.ToString() + ":" + secondsInt.ToString();//digital clock. HH gets hours in 24h format 
        
    }
}
