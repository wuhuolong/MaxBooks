using System;
using xc;
using xc.ui;
using xc.ui.ugui;

namespace Guide.Trigger
{
    [wxb.Hotfix]
    public class ClickSysBtn : ITrigger
    {
        public uint SysId;

        public ClickSysBtn(ETriggerType type, string param)
            : base(type, param)
        { }

        public override void Init(string param)
        {
            SysId = uint.Parse(param);
        }

        public override void Finish()
        {
            SysConfigManager.Instance.AutoExpandLeft = true;

            base.Finish();
        }

        public override bool TryToStartUp()
        {
            if (!IsMainUIReady())
                return false;

            var db_sys_config = DBManager.GetInstance().GetDB<DBSysConfig>();
            var config = db_sys_config.GetConfigById(SysId);
            if (config == null)
                return false;

            var mainmap_window = UIManager.Instance.GetWindow("UIMainmapWindow");
            if (mainmap_window == null || !mainmap_window.IsShow)
                return false;

            var mainmap_system = mainmap_window.GetBehaviour("UIMainMapSysOpenBehaviour") as UIMainMapSysOpenBehaviour;
            if (mainmap_system == null)
                return false;

            var target_btn = mainmap_system.GetConfingBtn(config);
            if (target_btn == null)
                return false;

            if (target_btn.Btn == null)
                return false;

            var target = target_btn.Btn.gameObject;
            if (GuideManager.Instance.IsWidgetVisible(target))
            {
                Parent.PrepareModel();
                SysConfigManager.Instance.AutoExpandLeft = false;

                Parent.GuideClick(target);
                return true;
            }

            return true;
        }
    }
}
