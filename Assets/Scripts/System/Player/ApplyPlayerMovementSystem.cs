using Component.Player;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

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
            foreach (var (input, transform) in SystemAPI.Query<RefRO<PlayerInputData>, RefRW<LocalTransform>>())
            {
                var moveInput = input.ValueRO.MoveInput;
                transform.ValueRW.Translate(new float3(moveInput.x, 0, moveInput.y));
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}