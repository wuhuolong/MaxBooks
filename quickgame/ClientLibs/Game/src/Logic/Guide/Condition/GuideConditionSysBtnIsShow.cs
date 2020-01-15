using xc;
using xc.ui;
using xc.ui.ugui;

namespace Guide.Condition
{
    [wxb.Hotfix]
    public class GuideConditionSysBtnIsShow : ICondition
    {
        public uint SysId { get; private set; }

        public GuideConditionSysBtnIsShow(ECondtionType type, string param)
            : base(type, param)
        { }

        public override void Init(string param)
        {
            uint targetId = 0;
            if(uint.TryParse(param, out targetId) == false)
            {
                GameDebug.LogError("Guide.Condition.GuideConditionSysBtnIsShow is error,invalid parameter:" + param);
                return;
            }

            SysId = targetId;
        }

        public override bool IsAchieve(Guide.Step step)
        {
            var mainmap_window = UIManager.Instance.GetWindow("UIMainmapWindow");
            if (mainmap_window == null || !mainmap_window.IsShow)
            {
                return false;
            }

            var mainmap_system = mainmap_window.GetBehaviour("UIMainMapSysOpenBehaviour") as UIMainMapSysOpenBehaviour;
            if (mainmap_system == null)
                return false;

            var sys_config = DBManager.Instance.GetDB<DBSysConfig>().GetConfigById(SysId);
            if (sys_config == null)
                return false;

            var target_btn = mainmap_system.GetConfingBtn(sys_config);
            if (target_btn == null)
                return false;

            if (target_btn.Btn == null)
                return false;

            UIFinishGuideBtn finishGuideBtn = target_btn.Btn.gameObject.GetComponent<UIFinishGuideBtn>();
            if (finishGuideBtn == null)
            {
                finishGuideBtn = target_btn.Btn.gameObject.AddComponent<UIFinishGuideBtn>();
                finishGuideBtn.GuideId = step.GuideId;
                finishGuideBtn.StepId = step.StepId;
            }

            // 强制指引需要展开系统所在的按钮栏
            if (!GuideManager.Instance.IsWidgetVisible(target_btn.Btn.gameObject))
            {
                if(step.IsForcible)
                {
                    switch (sys_config.Pos)
                    {
                        case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
                            {
                                if (SceneHelp.Instance.IsInWildInstance())
                                {
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SYS_WAIT_OPEN_SWITCH_ANIMATION, new CEventBaseArgs("LBRect"));
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GUIDE_UNFOLD_SYS_BTN, new CEventBaseArgs("LBRect"));
                                }
                                else
                                {
                                    ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_SYS_WAIT_OPEN_SWITCH_ANIMATION, new CEventBaseArgs("LBRect"));
                                    ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_GUIDE_UNFOLD_SYS_BTN, new CEventBaseArgs("LBRect"));
                                }
                            }
                            break;
                        case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
                            {
                                if (SceneHelp.Instance.IsInWildInstance())
                                {
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SYS_WAIT_OPEN_SWITCH_ANIMATION, new CEventBaseArgs("TRRect"));
                                }
                                else
                                    ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_SYS_WAIT_OPEN_SWITCH_ANIMATION, new CEventBaseArgs("TRRect"));
                            }
                            break;
                    }
                }
                
                return false;
            }

            return true;
        }
    }
}
