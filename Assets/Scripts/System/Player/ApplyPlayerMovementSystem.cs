using Component.Player;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;

namespace System.Player
{
    public partial struct ApplyPlayerMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (input, physicsVelocity) in SystemAPI.Query<RefRO<PlayerInputData>, RefRW<PhysicsVelocity>>())
            {
                var currentLinear = physicsVelocity.ValueRO.Linear;
                var moveInput = input.ValueRO.MoveInput;
                Debug.Log($"move input: {moveInput}");
                physicsVelocity.ValueRW.Linear = new float3(moveInput.x, currentLinear.y, moveInput.y);
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}