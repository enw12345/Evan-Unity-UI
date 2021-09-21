using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Evan.Unity.UI
{
    public class RadialMenu : MonoBehaviour
    {
        [SerializeField] private GameObject radialMenu;
        [SerializeField] private GameObject EntryPrefab;
        [SerializeField] private int EntryLimit;
        [SerializeField] private Sprite testSprite;

        private List<RadialMenuEntry> Entries;

        [SerializeField] private float Radius = 150f;

        private bool isOpen;

        private void Awake()
        {
            Entries = new List<RadialMenuEntry>();
            isOpen = false;
        }

        private void OnEnable()
        {
            if (Entries.Count <= 0)
            {
                Entries = GetComponentsInChildren<RadialMenuEntry>().ToList();
            }

            Arrange();
        }

        private void AddEntry(string label, Sprite iconSprite)
        {
            GameObject entry = Instantiate(EntryPrefab, transform);

            RadialMenuEntry rme = entry.GetComponent<RadialMenuEntry>();
            rme.Set(label, iconSprite);

            Entries.Add(rme);
        }

        public void CreateMenu()
        {
            for (int i = 0; i < EntryLimit; i++)
            {
                AddEntry("Button" + i.ToString(), testSprite);
            }
            Arrange();
        }

        public void Open()
        {
            radialMenu.SetActive(true);
            isOpen = true;
        }

        public void Close()
        {
            radialMenu.SetActive(false);
            isOpen = false;
        }

        public void ToggleRadialMenu()
        {
            if (!isOpen)
                Open();
            else
                Close();
        }

        public void Arrange()
        {
            float radiansOfSeperation = (Mathf.PI * 2) / Entries.Count;

            for (int i = 0; i < Entries.Count; i++)
            {
                float x = Mathf.Cos(radiansOfSeperation * i) * Radius;
                float y = Mathf.Sin(radiansOfSeperation * i) * Radius;

                Entries[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }
        }
    }
}

