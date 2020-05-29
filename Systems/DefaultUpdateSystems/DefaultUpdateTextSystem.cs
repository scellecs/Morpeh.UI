﻿namespace Morpeh.UI.Systems.DefaultUpdateSystems {
    using Components.UpdateComponents;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DefaultUpdateTextSystem))]
    public sealed class DefaultUpdateTextSystem : UpdateSystem {
        private Filter filter;

        public override void OnAwake() {
            this.filter = this.World.Filter.With<UpdateTextComponent>().With<UpdateMarker>();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in this.filter)
            {
                ref var component = ref entity.GetComponent<UpdateTextComponent>();
                foreach (var text in component.texts) {
                    text.text = component.value;
                }
                entity.RemoveComponent<UpdateMarker>();
            }
        }
    }
}