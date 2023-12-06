using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ClearSky
{
    public class HealrhBar_Character2 : MonoBehaviour
    {
        public Slider slider;
        

        public void setMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        }

        public void setHealth(int health)
        {
            slider.value = health;
        }
    }
}