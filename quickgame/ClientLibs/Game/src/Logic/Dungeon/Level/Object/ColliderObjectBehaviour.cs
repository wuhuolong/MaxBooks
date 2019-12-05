using UnityEngine;
using Uranus.Runtime;

namespace xc.Dungeon
{
    public class ColliderObjectBehaviour : MonoBehaviour
    {
        public int Id { set; get; }
        public uint EnterId { set; get; }
        public uint ExitId { set; get; }
        public Neptune.Collider.ETypeLifeTime LifeTime { set; get; }

        void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == null || other.gameObject.layer != LayerMask.NameToLayer("Player"))
            {
                return;
            }

            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer != null && localPlayer.GetModelParent().Equals(other.gameObject) == false)
            {
                return;
            }

            ActorMono act_mono = ActorHelper.GetActorMono(other.gameObject);
            if (act_mono == null)
                return;

            Player act = act_mono.BindActor as Player;
            if (act != null && act.UID.Equals(Game.GetInstance().LocalPlayerID))
            {
                if (EnterId > 0)
                {
                    UranusManager.Instance.ActiveLevelNode(EnterId);

                    if (LifeTime == Neptune.Collider.ETypeLifeTime.ONCE)
                    {
                        ColliderObjectManager.Instance.RemoveColliderObject(Id);
                    }
                }

                ColliderObjectManager.Instance.TriggerColliderObject(Id);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject == null || other.gameObject.layer != LayerMask.NameToLayer("Player"))
            {
                return;
            }

            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer != null && localPlayer.GetModelParent().Equals(other.gameObject) == false)
            {
                return;
            }

            ActorMono act_mono = ActorHelper.GetActorMono(other.gameObject);
            if (act_mono == null)
                return;

            Player act = act_mono.BindActor as Player;
            if (act != null && act.UID.Equals(Game.GetInstance().LocalPlayerID))
            {
                if (ExitId > 0)
                {
                    UranusManager.Instance.ActiveLevelNode(ExitId);

                    if (LifeTime == Neptune.Collider.ETypeLifeTime.ONCE)
                    {
                        ColliderObjectManager.Instance.RemoveColliderObject(Id);
                    }
                }

                ColliderObjectManager.Instance.TriggerColliderObject(Id);
            }
        }

        void OnColliderEnter(Collider other)
        {
            if (EnterId > 0)
            {
                UranusManager.Instance.ActiveLevelNode(EnterId);

                if (LifeTime == Neptune.Collider.ETypeLifeTime.ONCE)
                {
                    ColliderObjectManager.Instance.RemoveColliderObject(Id);
                }
            }

            ColliderObjectManager.Instance.TriggerColliderObject(Id);
        }

        void OnColliderExit(Collider other)
        {
            if (ExitId > 0)
            {
                UranusManager.Instance.ActiveLevelNode(ExitId);

                if (LifeTime == Neptune.Collider.ETypeLifeTime.ONCE)
                {
                    ColliderObjectManager.Instance.RemoveColliderObject(Id);
                }
            }

            ColliderObjectManager.Instance.TriggerColliderObject(Id);
        }
    }
}
