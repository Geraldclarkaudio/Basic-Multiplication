using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        [SerializeField]
        private Canvas canvas;

        public Vector3 originalPosition;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            originalPosition = rectTransform.anchoredPosition;
            
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

            Cursor.lockState = CursorLockMode.Confined;
        }

        private void Update()
        {
            Rect rect = rectTransform.rect;

            Vector2 leftBottom = transform.TransformPoint(rect.min);
            Vector2 rightTop = transform.TransformPoint(rect.max);
            Vector2 UISize = rightTop - leftBottom;

            rightTop = new Vector2(Screen.width, Screen.height) - UISize;

            float x = Mathf.Clamp(leftBottom.x, 0, rightTop.x);
            float y = Mathf.Clamp(leftBottom.y, 0, rightTop.y);

            Vector2 offset = (Vector2)transform.position - leftBottom;

            transform.position = new Vector2(x, y) + offset;
        }

    }
}
