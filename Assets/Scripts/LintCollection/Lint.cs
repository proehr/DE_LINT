using System;
using DataStructures.Variables;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

namespace LintCollection
{
    public class Lint : MonoBehaviour
    {
        public enum LintType
        {
            SMALL,
            NORMAL,
            BIG
        }

        [SerializeField] private int lintId;
        [SerializeField] private BoolVariable collected;
        [SerializeField] private LintType lintType;
        [SerializeField] private int lintValue;
        [SerializeField] private LintInventory inventory;

        private void Awake()
        {
            if (!collected.name.EndsWith(lintId.ToString()))
            {
                Debug.Log("Lint " + lintId + "not properly saved");
            }

            if (collected.value)
            {
                RemoveFromEnvironment();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                switch (lintType)
                {
                    case LintType.SMALL:
                        inventory.AddSmallLint(lintValue);
                        break;
                    case LintType.NORMAL:
                        inventory.AddNormalLint(lintValue);
                        break;
                    case LintType.BIG:
                        inventory.AddBigLint(lintValue);
                        break;
                }

                RemoveFromEnvironment();
            }
        }

        private void RemoveFromEnvironment()
        {
            collected.value = true;
            gameObject.SetActive(false);
        }
    }
}