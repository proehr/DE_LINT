using UnityEngine;

namespace Utility
{
    public class Floaty : MonoBehaviour
    {
        internal float startPos;
    
        void Start()
        {
            startPos = transform.position.y;
        }

        void Update()
        {
            var position = transform.localPosition;
            position = new Vector3(position.x, startPos + Mathf.Sin(Time.fixedTime * Mathf.PI * 0.4f)*0.1f, position.z);
            transform.localPosition = position;
        }
    }
}