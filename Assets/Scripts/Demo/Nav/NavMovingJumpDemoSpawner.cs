﻿using UnityEngine;
using Unity.Mathematics;
using Reese.Nav;
using Reese.Spawning;
using Unity.Entities;
using Unity.Transforms;

namespace Reese.Demo
{
    class NavMovingJumpDemoSpawner : MonoBehaviour
    {
        EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;

        void Start()
        {
            var prefabEntity = entityManager.CreateEntityQuery(typeof(NavAgentPrefab)).GetSingleton<NavAgentPrefab>().Value;

            SpawnSystem.Enqueue(new Spawn()
                .WithPrefab(prefabEntity)
                .WithComponentList(
                    new NavAgent
                    {
                        JumpDegrees = 45,
                        JumpGravity = 200,
                        TranslationSpeed = 20,
                        TypeID = NavUtil.GetAgentType(NavConstants.HUMANOID),
                        Offset = new float3(0, 1, 0)
                    },
                    new NavNeedsSurface { },
                    new Parent { },
                    new LocalToParent { },
                    new Translation
                    {
                        Value = new float3(0, 1, 0)
                    }
                ),
                50
            );
        }
    }
}
