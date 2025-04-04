using Component.Player;
using Scripts.Runtime;
using Unity.Entities;
using UnityEngine;

namespace System.Player
{
    public partial class ProcessInputSystem : SystemBase
    {
        private InputSystem_Actions _inputSystemActions;
        private InputSystem_Actions.PlayerActions _playerActions;

        protected override void OnCreate()
        {
            _inputSystemActions = new InputSystem_Actions();
            _inputSystemActions.Enable();
            _playerActions = _inputSystemActions.Player;
        }

        protected override void OnUpdate()
        {
            var moveInput = _playerActions.Move.ReadValue<Vector2>();
            var lookInput = _playerActions.Look.ReadValue<Vector2>();

            foreach (var inputData in SystemAPI.Query<RefRW<PlayerInputData>>())
            {
                inputData.ValueRW.MoveInput = moveInput;
                inputData.ValueRW.LookInput = lookInput;
            }
        }

        protected override void OnDestroy()
        {
            _inputSystemActions.Disable();
            _inputSystemActions.Dispose();
        }
    }
}