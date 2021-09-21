using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VerticalWindowTrigger : MonoBehaviour
{
    public string title;
    public Sprite sprite;
    public string message;
    public string confirmMessage = null;
    public string cancelMessage = null;
    public bool triggerOnEnable;

    public UnityEvent onContinueEvent;
    public UnityEvent onCancelEvent;
    public UnityEvent onAlternateEvent;

    private void OnEnable()
    {
        TriggerWindow();
    }

    public void TriggerWindow()
    {
        Action continueCallback = null;
        Action cancelCallback = null;
        // Action alternateCallback = null;

        if (onContinueEvent.GetPersistentEventCount() > 0)
        {
            continueCallback = onContinueEvent.Invoke;
        }
        if (onCancelEvent.GetPersistentEventCount() > 0)
        {
            cancelCallback = onCancelEvent.Invoke;
        }

        UIController.instance.modalWindow.ShowAsIcon(title, sprite, message, continueCallback, cancelCallback);
    }
}
