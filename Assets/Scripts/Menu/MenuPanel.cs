using Controllers;
using UnityEngine;

namespace Menu
{
    public abstract class MenuPanel : MonoBehaviour
    {
        protected MenuMediator menuMediator;
        [SerializeField] protected CanvasGroup _canvasGroup;

        protected RectTransform rectTransform;
        public virtual void Configure(MenuMediator pMenuMediator)
        {
            this.menuMediator = pMenuMediator;
        }
        public abstract void Show();
        public abstract void Hide();
    }
}