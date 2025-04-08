using Component.Player;
using NUnit.Framework;
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

                Assert.IsFalse(entity == Entity.Null);
                AddComponent(entity, new PlayerInputData());
            }
        }
    }
}