using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Golf
{
    public class Batton_Image : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        public Sprite normalSprite;
        public Sprite pressedSprite;
        private Image buttonImage;

        void Start()
        {
            buttonImage = GetComponent<Image>();
            buttonImage.sprite = normalSprite;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            buttonImage.sprite = pressedSprite; 
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            buttonImage.sprite = normalSprite; 
        }
    }
}
