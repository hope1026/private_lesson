using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.UI
{
	class UILayerLobby : UILayerAbstract
	{
		protected override void _OnActivate()
		{
			if( null == this._eventHandler)
			{
				this._eventHandler = base.layerCanvas.gameObject.GetComponentInChildren<UILayerLobbyEventHandler>();
			}
			if( null != this._eventHandler )
			{
				this._eventHandler.HandleOnActivateLayer();
			}
		}
		protected override void _OnDeActivate()
		{
			if (null != this._eventHandler)
			{
				this._eventHandler.HandleOnDeActivateLayer();
			}
		}
		private UILayerLobbyEventHandler _eventHandler = null;
		public override UILayerType uiLayerType { get { return UILayerType.LOBBY; } }
	}
}
