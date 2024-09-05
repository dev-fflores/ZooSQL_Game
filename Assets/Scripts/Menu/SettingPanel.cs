using Controllers;
using DG.Tweening;
using UnityEngine;

namespace Menu
{
    public class SettingPanel : MenuPanel
    {
        public override void Configure(MenuMediator pMenuMediator)
        {
            pMenuMediator = base.menuMediator;
        }
        public override void Show()
        {
            _canvasGroup.DOFade(1, 0.5f);
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public override void Hide()
        {
            _canvasGroup.DOFade(0, 0.5f);
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}