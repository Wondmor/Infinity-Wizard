using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClearSky
{
    public class ReviveBar : MonoBehaviour
    {
        public Slider slider;

        public void setMaxReviveTime(int time)
        {
            slider.maxValue = time;
            slider.value = time;
        }

        public void setReviveTime(int time)
        {
            slider.value = time;
        }
    }
}