using System;
using UnityEngine;

namespace MyPackages.Scripts.Behaviour
{

    public class LevelBehaviour : Singleton<LevelBehaviour>
    {
        public static event Action<bool> OnComplete;
        public EnemySpawnController SpawnController;
        public ObjectPool PoolObject;
        private void Start()
        {
            GameDataStructure.Instance.OnStart();
        }
        public void GameEnd(bool value) {
            Debug.Log("Game End" + value);
            OnComplete?.Invoke(value);
        }
    }
}