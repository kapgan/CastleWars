namespace MyPackages.Scripts.Behaviour
{

    public class LevelBehaviour : Singleton<LevelBehaviour>
    {
        private void Start()
        {
            GameDataStructure.Instance.OnStart();
        }
    }
}