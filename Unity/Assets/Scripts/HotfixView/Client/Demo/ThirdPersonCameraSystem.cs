using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ThirdPersonCameraComponent))]
    [FriendOf(typeof(ThirdPersonCameraComponent))]
    public static partial class CameraComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ThirdPersonCameraComponent self)
        {
            self.Camera = Camera.main;
            self.Camera.transform.rotation = Quaternion.Euler(new Vector3(20, 0, 0));
        }

        [EntitySystem]
        private static void LateUpdate(this ThirdPersonCameraComponent self)
        {
            Scene root = self.Root();
            Unit myUnit = UnitHelper.GetMyUnitFromClientScene(root);
            if (myUnit == null)
            {
                return;
            }

            Transform myTrans = myUnit.GetComponent<GameObjectComponent>().Transform;
            Vector3 pos = myTrans.position;
            self.Transform.position = new Vector3(pos.x, pos.y + 3, pos.z - 5);
        }

        [EntitySystem]
        private static void Destroy(this ThirdPersonCameraComponent self)
        {
            self.Camera = null;
            self.Unit = null;
        }

        public static void SetTargetUnit(this ThirdPersonCameraComponent self, Unit unit)
        {
            self.Unit = unit;
            //self.OffsetPosition = self.Camera.transform.position - self.Unit.Position;
        }
    }
}