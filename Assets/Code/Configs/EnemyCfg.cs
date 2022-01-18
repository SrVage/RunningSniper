using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(order = 4, fileName = "EnemyCfg", menuName = "Config/EnemyCfg")]
    public class EnemyCfg:ScriptableObject
    {
        public GameObject Prefab;
    }
}