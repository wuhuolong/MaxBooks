using System.Collections.Generic;

namespace xc
{
    [wxb.Hotfix]
    public class CooldownCtrlMgr : xc.Singleton<CooldownCtrlMgr>
    {
        CooldownCtrl m_localPlayerCtrl;
        public CooldownCtrlMgr()
        {
            
        }
        bool IsSecretArea(uint scene_id)
        {
            var dbInstance = DBManager.GetInstance().GetDB<DBInstance>();
            DBInstance.InstanceInfo pre_instance_info = dbInstance.GetInstanceInfo(scene_id);
            if (pre_instance_info == null)
                return false;
            if (pre_instance_info.mWarType == GameConst.WAR_TYPE_DUNGEON &&
                pre_instance_info.mWarSubType == GameConst.WAR_SUBTYPE_SECRET_AREA)
                return true;
            return false;
        }
        public CooldownCtrl GetNewCoolDown(Actor owner)
        {
            if (owner == null)
                return null;
            if(owner.IsLocalPlayer)
            {
                uint pre_scene_id = SceneHelp.Instance.PreSceneID;
                bool pre_scene_is_secretArea = IsSecretArea(pre_scene_id);
                uint cur_scene_id = SceneHelp.Instance.CurSceneID;
                bool cur_scene_is_secretArea = IsSecretArea(cur_scene_id);
                
                bool can_reset_cd = false;
                DBInstance.InstanceInfo cur_instance_info = InstanceManager.Instance.InstanceInfo;
                if (DBInstanceTypeControl.Instance.ClearCd(cur_instance_info.mWarType, cur_instance_info.mWarSubType))
                {
                    can_reset_cd = true;
                }
                if((pre_scene_is_secretArea || cur_scene_is_secretArea) &&
                    pre_scene_id != cur_scene_id)
                {//进出武神塔(同一武神塔内切换不重置)，都要重置CD
                    can_reset_cd = true;
                }
                if(can_reset_cd == true)
                {
                    m_localPlayerCtrl = null;
                }
                if (m_localPlayerCtrl == null)
                    m_localPlayerCtrl = new CooldownCtrl(owner);
                else
                    m_localPlayerCtrl.SetOwner(owner);
                return m_localPlayerCtrl;
            }
            return new CooldownCtrl(owner);
        }

        public void RecyleCooldown(CooldownCtrl ctrl)
        {
            if (ctrl == null)
                return;
            if (ctrl.Owner != null)
                ctrl.Destroy();
        }


    }
}
