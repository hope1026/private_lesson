using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.UI
{
	class UILayerGame : UILayerAbstract
	{
		protected override void _OnActivate()
		{
			UnityEngine.Cursor.visible = false;
			UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.Locked;
		}
		public override UILayerType uiLayerType { get { return UILayerType.GAME; } }
	}
}
