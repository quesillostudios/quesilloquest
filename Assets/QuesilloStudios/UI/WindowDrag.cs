using System.Linq;
using UnityEngine;

namespace QuesilloStudios.UI
{
    public class WindowDrag : MonoBehaviour
    {
        [SerializeField] private RectTransform windowRect;
        private Vector2 _lastWindowPosition;
        private Vector3 _offset;
        
        public void MoveWindow()
        {
            windowRect.position = Input.mousePosition + _offset;
            
            if (IsRectTransformInsideScreen(windowRect))
            {
                _lastWindowPosition = windowRect.position;
            }
        }
        
        public void GetOffset()
        {
            _offset = windowRect.position - Input.mousePosition;
        }

        public void CheckIfOutside()
        {
            windowRect.position = _lastWindowPosition;
        }

        private static bool IsRectTransformInsideScreen(RectTransform rectTransform)
        {
            var isInside = false;
            var corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);
            var rect = new Rect(0,0,Screen.width, Screen.height);
            var visibleCorners = corners.Count(corner => rect.Contains(corner));
            if(visibleCorners == 4)
            {
                isInside = true;
            }
            return isInside;
        }
    }
}
