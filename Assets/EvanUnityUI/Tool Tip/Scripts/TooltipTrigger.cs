using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Evan.Unity.UI
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public string content;
        public string header;
        private Coroutine currentCoroutine;

        public void OnPointerEnter(PointerEventData eventData)
        {
            StartCoroutine(ShowCoroutine());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StopAllCoroutines();
            TooltipSystem.Hide();
        }

        private void OnMouseEnter()
        {
            StartCoroutine(ShowCoroutine());
        }

        private void OnMouseExit()
        {
            StopAllCoroutines();
            TooltipSystem.Hide();
        }

        private IEnumerator ShowCoroutine()
        {
            yield return new WaitForSeconds(TooltipSystem.showDelay);
            TooltipSystem.Show(content, header);
        }
    }
}

