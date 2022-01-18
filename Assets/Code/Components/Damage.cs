using Leopotam.Ecs;
using UnityEngine;

namespace Code.Components
{
    public struct Damage
    {
        public Vector3 Point;
        public Vector3 Direction;
        public Rigidbody PartOfBody;
    }
}