using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class Button_speed_stone : MonoBehaviour
    {
        public InputField inputField;


        public void OnSubmit()
        {
            string inputValue = inputField.text;

        }
    }
}