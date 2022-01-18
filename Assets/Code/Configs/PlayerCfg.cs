using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(order = 3, fileName = "PlayerCfg", menuName = "Config/PlayerCfg")]
    public class PlayerCfg:ScriptableObject
    {
        public GameObject Prefab;
        [Range(1, 7)] public float Speed;
    }
}