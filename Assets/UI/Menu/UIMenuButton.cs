using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Grimmz.UI.Menu
{
    public class UIMenuButton : UIGameTransitionButton, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private Color titleHighlightedColor;
        [SerializeField] private Color titleUnhighlightedColor;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (title != null)
                title.color = titleHighlightedColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (title != null)
                title.color = titleUnhighlightedColor;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }
    }
}
