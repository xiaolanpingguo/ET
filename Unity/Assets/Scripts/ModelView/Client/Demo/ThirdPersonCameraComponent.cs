using UnityEngine;

namespace ET.Client
{
    [ComponentOf]
    public class ThirdPersonCameraComponent : Entity, IAwake, ILateUpdate, IDestroy
    {
        public Unit Unit { get; set; }

        private Camera camera;
        public Transform Transform;

        public Vector3 OffsetPosition { get; set; }

        public Camera Camera
        {
            get
            {
                return this.camera;
            }
            set
            {
                this.camera = value;
                this.Transform = this.camera.transform;
            }
        }

        public int index;
    }
}