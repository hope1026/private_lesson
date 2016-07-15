using UnityEngine;
using UnityEngine.EventSystems;

using System;
using System.Collections.Generic;
using System.Collections;

namespace Assets.Scripts.UI
{
	public sealed class UIManager
	{
		private UIManager() { }
		public void Initialize()
		{
			this._layerDic = new SortedDictionary<UILayerType, UILayerAbstract>();
			this._activeLayerStack = new Stack<UILayerAbstract>();
			this._lastOrderInLayer = 0;
		}
		public void Terminate()
		{
			if (null != this._activeLayerStack)
			{
				this._activeLayerStack.Clear();
				this._activeLayerStack = null;
			}

			if (null != this._layerDic)
			{
				this._layerDic.Clear();
				this._layerDic = null;
			}
			this._lastOrderInLayer = 0;
		}
		public void UpdateCustom()
		{
			foreach (UILayerAbstract layer in this._activeLayerStack)
			{
				layer.UpdateOnActive();
			}
		}
		private UILayerAbstract _InstantiateUILayer(UILayerType uiLayerType_)
		{
			if (null == this.rootComponent)
			{
				this.rootComponent = GameObject.FindObjectOfType<UICRoot>();
			}

			if (null != this.rootComponent)
			{
				UILayerAbstract uiLayer = this.rootComponent.InstantiateUILayer(uiLayerType_);
				if (null != uiLayer)
				{
					this._layerDic.Add(uiLayerType_, uiLayer);
				}
				return uiLayer;
			}
			return null;
		}
		public void DestroyUILayer(UILayerType uiLayerType_)
		{
			UILayerAbstract uiLayer = null;
			if (true == this._layerDic.TryGetValue(uiLayerType_, out uiLayer))
			{
				this._layerDic.Remove(uiLayerType_);
				if (null != uiLayer && null != uiLayer.layerCanvas)
				{
					GameObject.DestroyObject(uiLayer.layerCanvas.gameObject);
				}
			}
		}

		public void ActivateUILayer(UILayerType uiLayerType_)
		{
			UILayerAbstract requestLayer = null;
			if (false == this._layerDic.TryGetValue(uiLayerType_, out requestLayer))
			{
				requestLayer = _InstantiateUILayer(uiLayerType_);
			}
			if (null != requestLayer )
			{
				if (_activeLayerStack.Count < 1) this._lastOrderInLayer = 0;
				requestLayer.Activate(++this._lastOrderInLayer);
				this._activeLayerStack.Push(requestLayer);
				this.currentActiveLayerType = uiLayerType_;
			}
		}

		public void DeactivateUILayer(UILayerType uiLayrType_)
		{
			if (this._activeLayerStack.Count > 0)
			{
				UILayerAbstract uiLayer = null;
				if (uiLayrType_ != UILayerType.NONE)
				{
					if (uiLayrType_ == this._activeLayerStack.Peek().uiLayerType)
					{
						uiLayer = this._activeLayerStack.Pop();
					}
				}
				else
				{
					uiLayer = this._activeLayerStack.Pop();
				}

				if (null != uiLayer)
				{
					uiLayer.DeActivate();
				}
			}
		}



		public UICRoot rootComponent { get; private set; }
		public UILayerType currentActiveLayerType { get; private set; }
		private SortedDictionary<UILayerType, UILayerAbstract> _layerDic = null;
		private Stack<UILayerAbstract> _activeLayerStack = null;
		private int _lastOrderInLayer = 0;

		#region SINGLETON
		private static UIManager _instance = null;
		public static UIManager Instance { get { if (null != _instance) { return _instance; } else { return (_instance = new UIManager()); } } }
		#endregion
	}

}

