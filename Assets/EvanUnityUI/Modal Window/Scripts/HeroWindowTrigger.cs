using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroWindowTrigger : MonoBehaviour
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
        if (!triggerOnEnable) { return; }
        TriggerWindow();
    }

    private void Start()
    {
        if (!triggerOnEnable) { return; }
        TriggerWindow();
    }

    public void TriggerWindow()
    {
        if (!triggerOnEnable) { return; }

        //Create an action for each of the unity events. The Actions will be sent to the ShowAsHero function to 
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

        UIController.instance.modalWindow.ShowAsHero(title, sprite, message, continueCallback, cancelCallback);
    }
}
