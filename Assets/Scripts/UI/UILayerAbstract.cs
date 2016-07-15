using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public abstract class UILayerAbstract
	{
		public void Initialize(GameObject ownedGameObject_)
		{
			this.layerCanvas = ownedGameObject_.GetComponent<Canvas>();
			_OnInitialize();
		}
		public void Terminate()
		{
			_OnTerminate();
		}

		public void Activate(int orderInLayer_)
		{
			if (null != this.layerCanvas)
			{
				this.layerCanvas.gameObject.SetActive(true);
				this.layerCanvas.sortingOrder = orderInLayer_;
			}
			_OnActivate();
		}
		public void DeActivate()
		{
			_OnDeActivate();
			if (null != this.layerCanvas)
			{
				this.layerCanvas.gameObject.SetActive(false);
			}
		}
		public void UpdateOnActive()
		{
			_OnUpdateOnActive();
		}

		public virtual bool CanActivate() { return true; }
		protected virtual void _OnInitialize() { }
		protected virtual void _OnTerminate() { }
		protected virtual void _OnActivate() { }
		protected virtual void _OnDeActivate() { }
		protected virtual void _OnUpdateOnActive() { }
		public Canvas layerCanvas { get; private set; }
		public abstract UILayerType uiLayerType { get; }
	}
}
