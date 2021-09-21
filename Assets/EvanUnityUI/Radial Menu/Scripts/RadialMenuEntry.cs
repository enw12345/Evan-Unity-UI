using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Evan.Unity.UI
{
    public class RadialMenuEntry : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI Label;
        [SerializeField] private Image icon;

        public void Set(string labelText, Sprite iconSprite)
        {
            Label.text = labelText;
            icon.sprite = iconSprite;
        }
    }
}

