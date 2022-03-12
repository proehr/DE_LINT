using System;
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

        [SerializeField] private LintType lintType;
        [SerializeField] private int lintValue;
        [SerializeField] private LintInventory inventory;

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
            gameObject.SetActive(false);
        }
    }
}