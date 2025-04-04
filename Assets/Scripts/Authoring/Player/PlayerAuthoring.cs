using Component.Player;
using Unity.Entities;
using UnityEngine;

namespace Authoring.Player
{
    public class PlayerAuthoring : MonoBehaviour
    {
        private class PlayerAuthoringBaker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new PlayerInputData());
            }
        }
    }
}