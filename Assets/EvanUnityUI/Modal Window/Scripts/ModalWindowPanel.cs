using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;

namespace Evan.Unity.UI
{
    public class ModalWindowPanel : MonoBehaviour
    {
        [Header("Header")]
        [SerializeField]
        private Transform _headerArea;
        [SerializeField]
        private TextMeshProUGUI _titleField;

        [Header("Content")]
        [SerializeField]
        private Transform _contentArea;
        [SerializeField]
        private Transform _verticalLayoutArea;
        [SerializeField]
        private Image _heroImage;
        [SerializeField]
        private TextMeshProUGUI _heroText;
        [Space()]
        [SerializeField]
        private Transform _horizontalLayoutArea;
        [SerializeField]
        private Transform _iconContainer;
        [SerializeField]
        private Image _iconImage;
        [SerializeField]
        private TextMeshProUGUI _iconText;

        [Header("Footer")]
        [SerializeField]
        private Transform _footerArea;
        [SerializeField]
        private Button _confirmButton;
        [SerializeField]
        private Button _declineButton;
        [SerializeField]
        private Button _alternateButton;

        private Action onConfirmCallback;
        private Action onDeclineCallback;
        private Action onAlternateCallback;

        public void Confirm()
        {
            onConfirmCallback?.Invoke();
            Close();
        }

        public void Decline()
        {
            onDeclineCallback?.Invoke();
            Close();
        }

        public void Alternate()
        {
            onAlternateCallback?.Invoke();
            Close();
        }

        public void Close()
        {

        }

        public void Show()
        {

        }

        public void ShowAsHero(string title, Sprite imageToShow, string message, string confirmMessage, string declineMessage, string alternateMessage, Action confirmAction, Action declineAction, Action alternateAction = null)
        {
            _horizontalLayoutArea.gameObject.SetActive(false);
            _verticalLayoutArea.gameObject.SetActive(true);

            //Hide header if there's no title
            bool hasTitle = !string.IsNullOrEmpty(title);
            _headerArea.gameObject.SetActive(hasTitle);
            _titleField.text = title;

            _heroImage.sprite = imageToShow;
            _heroText.text = message;

            onConfirmCallback = confirmAction;
            _confirmButton.GetComponentInChildren<TextMeshProUGUI>().text = confirmMessage;

            bool hasDecline = (declineAction != null);
            _declineButton.gameObject.SetActive(hasDecline);
            _declineButton.GetComponentInChildren<TextMeshProUGUI>().text = declineMessage;
            onDeclineCallback = declineAction;

            bool hasAlternate = (alternateAction != null);
            _alternateButton.gameObject.SetActive(hasAlternate);
            _alternateButton.GetComponentInChildren<TextMeshProUGUI>().text = alternateMessage;
            onAlternateCallback = alternateAction;
        }

        public void ShowAsHero(string title, Sprite imageToShow, string message, Action confirmAction)
        {
            ShowAsHero(title, imageToShow, message, "Continue", "", "", confirmAction, null);
        }

        public void ShowAsHero(string title, Sprite imageToShow, string message, Action confirmAction, Action declineAction)
        {
            ShowAsHero(title, imageToShow, message, "Continue", "Back", "", confirmAction, declineAction);
        }

        public void ShowAsIcon(string title, Sprite imageToShow, string message, string confirmMessage, string declineMessage, string alternateMessage, Action confirmAction, Action declineAction, Action alternateAction = null)
        {
            _horizontalLayoutArea.gameObject.SetActive(true);
            _verticalLayoutArea.gameObject.SetActive(false);

            //Hide header if there's no title
            bool hasTitle = !string.IsNullOrEmpty(title);
            _headerArea.gameObject.SetActive(hasTitle);
            _titleField.text = title;

            _iconImage.sprite = imageToShow;
            _iconText.text = message;

            onConfirmCallback = confirmAction;
            _confirmButton.GetComponentInChildren<TextMeshProUGUI>().text = confirmMessage;

            bool hasDecline = (declineAction != null);
            _declineButton.gameObject.SetActive(hasDecline);
            _declineButton.GetComponentInChildren<TextMeshProUGUI>().text = declineMessage;
            onDeclineCallback = declineAction;

            bool hasAlternate = (alternateAction != null);
            _alternateButton.gameObject.SetActive(hasAlternate);
            _alternateButton.GetComponentInChildren<TextMeshProUGUI>().text = alternateMessage;
            onAlternateCallback = alternateAction;
        }

        public void ShowAsIcon(string title, Sprite imageToShow, string message, Action confirmAction)
        {
            ShowAsIcon(title, imageToShow, message, "Continue", "", "", confirmAction, null);
        }

        public void ShowAsIcon(string title, Sprite imageToShow, string message, Action confirmAction, Action declineAction)
        {
            ShowAsIcon(title, imageToShow, message, "Continue", "Back", "", confirmAction, declineAction);
        }
    }
}
