using System;
using DataStructures.Events;
using DataStructures.Variables;
using TMPro;
using UnityEngine;

namespace UIController
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text smallLintCountText;
        [SerializeField] private TMP_Text normalLintCountText;
        [SerializeField] private TMP_Text bigLintCountText;

        [SerializeField] private IntVariable smallLintCount;
        [SerializeField] private IntVariable normalLintCount;
        [SerializeField] private IntVariable bigLintCount;
        [SerializeField] private GameEvent onLintCountChanged;

        private void Awake()
        {
            onLintCountChanged.RegisterListener(SetHUDValues);
            SetHUDValues();
        }

        private void OnEnable()
        {
            SetHUDValues();
        }

        private void SetHUDValues()
        {
            smallLintCountText.text = GetStringifiedCount(smallLintCount.value);
            normalLintCountText.text = GetStringifiedCount(normalLintCount.value);
            bigLintCountText.text = GetStringifiedCount(bigLintCount.value);
        }

        private String GetStringifiedCount(int count)
        {
            if (count < 10)
            {
                return "0" + count;
            }

            return count.ToString();
        }
    }
}