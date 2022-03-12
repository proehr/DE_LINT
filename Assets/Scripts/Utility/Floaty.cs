using UnityEngine;

namespace Utility
{
    public class Floaty : MonoBehaviour
    {
        internal Vector3 startPos;
    
        void Start()
        {
            startPos = transform.position;
        }

        void Update()
        {
            transform.position = new Vector3(startPos.x, startPos.y + Mathf.Sin(Time.fixedTime * Mathf.PI * 0.4f)*0.05f, startPos.z);
        }
    }
}