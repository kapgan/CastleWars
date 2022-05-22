using System;

namespace MyPackages.Scripts.Behaviour
{

    public class LevelBehaviour : Singleton<LevelBehaviour>
    {
        public static event Action<bool> OnComplete;
        private void Start()
        {
            GameDataStructure.Instance.OnStart();
        }
        public void GameEnd(bool value) {
            OnComplete?.Invoke(value);
        }
    }
}