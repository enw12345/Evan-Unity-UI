using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Evan.Unity.UI
{
    [ExecuteInEditMode]
    public class Tooltip : MonoBehaviour
    {
        public TextMeshProUGUI headerField;
        public TextMeshProUGUI contentField;
        public LayoutElement layoutElement;
        public int characterWrapLimit;

        public RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        public void SetText(string content, string header = "")
        {
            if (string.IsNullOrEmpty(header))
            {
                headerField.gameObject.SetActive(false);
            }
            else
            {
                headerField.gameObject.SetActive(true);
                headerField.text = header;
            }

            contentField.text = content;

        }

        private void Resize()
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        }

        private void Update()
        {
            if (Application.isEditor)
            {
                Resize();
            }

            Vector2 position = Input.mousePosition;
            float pivotX = position.x / Screen.width;
            float pivotY = position.y / Screen.height;

            rectTransform.pivot = new Vector2(pivotX, pivotY);
            transform.position = position;
        }
    }
}

