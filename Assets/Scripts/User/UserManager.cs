using System;
using UnityEngine;
using Assets.Scripts.Game;

namespace Assets.Scripts.User
{
	public sealed class UserManager
	{
		private const float PLAYER_HEIGHT = 2.0f;
		private UserManager() { }
		public void SetPlayerCamera(Camera camera_)
		{
			if (null != camera_ )
			{
				if( null != this.userGO )
				{
					camera_.transform.SetParent(this.userGO.transform);
					camera_.transform.localRotation = Quaternion.identity;
					camera_.transform.localPosition = new Vector3(0f, PLAYER_HEIGHT, 0f);
				}
				this.playerCamera = camera_;	
			}
		}
		public void SetUserGameObject(GameObject userGameObject_)
		{
			this.userGO = userGameObject_;
			if( null != this.userGO )
			{
				this._navMeshAgent = this.userGO.GetComponentInChildren<NavMeshAgent>();
			}
		}

		public void UpdateCustomPre()
		{
			_UpdateInput();
		}

		public void UpdateCustom()
		{
			_UpdatRotation();
			_UpdateMove();
			_RayCasting();
		}
		private void _UpdateInput()
		{
			this._moveDirection = Vector3.zero;
			//앞방향
			if (true == Input.GetKey(KeyCode.UpArrow))
			{
				this._moveDirection += new Vector3(0f, 0f, 1f);
			}
			//뒤방향
			if (true == Input.GetKey(KeyCode.DownArrow))
			{
				this._moveDirection += new Vector3(0f, 0f, -1f);
			}
			//앞방향
			if (true == Input.GetKey(KeyCode.RightArrow))
			{
				this._moveDirection += new Vector3(1f, 0f, 0f);
			}
			//뒤방향
			if (true == Input.GetKey(KeyCode.LeftArrow))
			{
				this._moveDirection += new Vector3(-1f, 0f, 0f);
			}

			this._axisDeltaX = Input.GetAxis("Mouse X");
			this._axisDeltaY = Input.GetAxis("Mouse Y");

			//마우스 왼쪽 버튼 클릭시
			if( true == Input.GetMouseButtonDown(0) )
			{
				this._fired = true;
			}
		}
		private void _UpdatRotation()
		{
			if( this._axisDeltaX != 0f && this.userGO )
			{
				this.userGO.transform.Rotate(Vector3.up, this._axisDeltaX);
			}
			if (this._axisDeltaY != 0f && this.playerCamera)
			{
				this.playerCamera.transform.Rotate(Vector3.right, -this._axisDeltaY);
			}
		}
		private void _UpdateMove()
		{
			if (null != this._navMeshAgent && this._moveDirection != Vector3.zero )
			{
				Vector3 forward = this._navMeshAgent.transform.TransformDirection(this._moveDirection);
				Vector3 moveOffset = forward.normalized * this._navMeshAgent.speed * Time.deltaTime;
				this._navMeshAgent.Move(moveOffset);
			}
		}
		private void _RayCasting()
		{
			if( true == this._fired && null != this.playerCamera )
			{
				RaycastHit hit;
				Ray ray = new Ray(this.playerCamera.transform.position, this.playerCamera.transform.forward);
				int enemyLayerMask = 1 << 20;
				if( true == Physics.Raycast(ray, out hit, enemyLayerMask) )
				{
					if( null != hit.collider )
					{
						EnemyCharacter enemyCharacter = hit.collider.GetComponentInChildren<EnemyCharacter>();
						if( null != enemyCharacter )
						{
							enemyCharacter.Die();
						}
					}
				}
				this._fired = false;
			}
		}

		public string userID { get; set; }
		public GameObject userGO { get; private set; }
		public Camera playerCamera { get; private set; }
		private NavMeshAgent _navMeshAgent = null;
		private Vector3 _moveDirection = Vector3.zero;
		private float _axisDeltaX = 0f;
		private float _axisDeltaY = 0f;
		private bool _fired = false;
		#region SINGLETON
		private static UserManager _instance = null;
		public static UserManager Instance { get { if (null != _instance) { return _instance; } else { return (_instance = new UserManager()); } } }
		#endregion
	}
}
