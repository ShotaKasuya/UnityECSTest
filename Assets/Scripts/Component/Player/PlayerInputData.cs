using Unity.Entities;
using Unity.Mathematics;

namespace Component.Player
{
    public struct PlayerInputData : IComponentData
    {
        public float2 MoveInput;
        public float2 LookInput;
    }
}
