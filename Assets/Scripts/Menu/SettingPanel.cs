using Controllers;
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
            throw new System.NotImplementedException();
        }

        public override void Hide()
        {
            throw new System.NotImplementedException();
        }
    }
}