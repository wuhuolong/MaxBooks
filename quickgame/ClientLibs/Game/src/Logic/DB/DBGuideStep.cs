//---------------------------------------
// File:    DBGuideStep.cs
// Desc:    引导步骤的表格
// Author:  Raorui
// Date:    2017.9.21
//---------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;
using xc.ui;
using System.Collections;
using Guide;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGuideStep : DBSqliteTableResource
    {
        private Dictionary<uint, List<Step>> mGuideStepDict;
        
        public DBGuideStep(string strName, string strPath)
            : base(strName, strPath)
        {
            mGuideStepDict = new Dictionary<uint, List<Step>>();
        }

        public override void Unload()
        {
            base.Unload();
            mGuideStepDict.Clear();
        }

        // Utils
        private void AddGuideStep(Step guideStep)
        {
            var guideId = guideStep.GuideId;
            List<Step> stepList = null;
            if (!mGuideStepDict.ContainsKey(guideId))
            {
                stepList = new List<Step>();
                stepList.Add(guideStep);
                mGuideStepDict.Add(guideId, stepList);
            }
            else
            {
                stepList = mGuideStepDict [guideId];
                if (stepList == null)
                {
                    stepList = new List<Step>();
                    mGuideStepDict [guideId] = stepList;
                }
                stepList.Add(guideStep);
            }
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                var guide_step = new Step(0, 0, false);
                guide_step.GuideId = DBTextResource.ParseUI(GetReaderString(reader, "guide_id"));
                guide_step.StepId = DBTextResource.ParseUI(GetReaderString(reader, "step_id"));
                guide_step.EventType = DBTextResource.ParseBT_s(GetReaderString(reader, "event_type"),1);

                var is_forcible = DBTextResource.ParseUI_s(GetReaderString(reader, "forcible"), (uint)0) > (uint)0 ? true : false;
                guide_step.IsForcible = is_forcible;
                var click_any = DBTextResource.ParseUI_s(GetReaderString(reader, "click_any"), (uint)0) > (uint)0 ? true : false;
                guide_step.ClickAny = click_any;
                guide_step.IsPause = DBTextResource.ParseUI_s(GetReaderString(reader, "pause"), 0) == 1;
                guide_step.IsCanFinish = DBTextResource.ParseUI_s(GetReaderString(reader, "can_finish"), 0) == 1;
                guide_step.IsCanSkip = DBTextResource.ParseUI_s(GetReaderString(reader, "can_skip"), 0) == 1;
                guide_step.HideWidget = GetReaderString(reader, "hide_widget");

                var icon_dir = (EGuideIconDir)DBTextResource.ParseI_s(GetReaderString(reader, "icon_dir"), 1);
                guide_step.IconDir = icon_dir;

                var icon_desc = GetReaderString(reader, "icon_desc");
                if (icon_desc.Contains("\n"))
                {
                    icon_desc = icon_desc.Substring(1, icon_desc.Length - 2);
                }
                guide_step.IconDesc = icon_desc;
                guide_step.PicName = GetReaderString(reader, "pic_name");
                guide_step.DisplayType = (EDisplayType)DBTextResource.ParseI_s(GetReaderString(reader, "display_type"), 1);
                guide_step.AnimationName = GetReaderString(reader, "animation_name");
                guide_step.Offset_X = DBTextResource.ParseF_s(GetReaderString(reader, "offset_x"), 0);
                guide_step.VoiceId = DBTextResource.ParseUI_s(GetReaderString(reader, "voice"), 0);

                int guide_condition_count = DBTextResource.ParseI_s(GetReaderString(reader, "trigger_count"), 0);
                for (int index = 1; index <= guide_condition_count; index++)
                {
                    var index_str = index.ToString();

                    var condition_type = (ECondtionType)Enum.Parse(typeof(ECondtionType), GetReaderString(reader, "trigger_type_" + index_str));
                    var condition_params = GetReaderString(reader, "trigger_params_" + index_str);

                    var condition = Guide.Condition.Factory.CreateCondition(condition_type, condition_params);

                    guide_step.GuideTriggerList.Add(condition);
                }

                try
                {
                    // 设置完成条件
                    var trigger_type = (ETriggerType)Enum.Parse(typeof(ETriggerType), GetReaderString(reader, "target_type"));
                    var trigger_params = GetReaderString(reader, "target_params");

                    guide_step.TargetTrigger = Guide.Trigger.Factory.CreateTrigger(trigger_type, trigger_params);
                    guide_step.TargetTrigger.Parent = guide_step;
                }
                catch (Exception e)
                {
                    GameDebug.LogError(string.Format("引导步骤（{0}-{1}）的“完成条件”配置错误：{2}", guide_step.GuideId, guide_step.StepId, e.Message));
                    guide_step.TargetTrigger = null;
                }

                guide_step.IsFinished = false;
                AddGuideStep(guide_step);
            }

            foreach (var step_list in mGuideStepDict.Values)
            {
                step_list.Sort();
            }
        }

        // APIs
        public void Reset()
        {
            foreach (var guideSteps in mGuideStepDict.Values)
            {
                foreach (var guideStep in guideSteps)
                {
                    guideStep.Reset();
                }
            }
        }

        public List<Step> GetGuideStepListByGuideId(uint guideId)
        {
            if (!mGuideStepDict.ContainsKey(guideId))
            {
                return null;
            }
            return mGuideStepDict [guideId];
        }

        /// <summary>
        /// 通过guideId来获取当前未完成的指引步骤
        /// </summary>
        /// <param name="guideId"></param>
        /// <returns></returns>
        public Step GetCurrentStep(uint guideId)
        {
            if (!mGuideStepDict.ContainsKey(guideId))
            {
                return null;
            }
            var stepList = mGuideStepDict [guideId];
            for (int i = 0; i < stepList.Count; i ++)
            {
                var guideStep = stepList [i];
                if (!guideStep.IsFinished)
                {
                    return guideStep;
                }
            }
            return null;
        }

        public Step GetStepByGuideId(uint guide_id, uint step_id)
        {
            if (!mGuideStepDict.ContainsKey(guide_id))
            {
                return null;
            }

            var step_list = mGuideStepDict[guide_id];
            for (int i = 0; i < step_list.Count; i++)
            {
                var guide_step = step_list[i];
                if (guide_step.StepId == step_id)
                {
                    return guide_step;
                }
            }
            return null;
        }

        /// <summary>
        /// Step是否是引导序列的最后一步
        /// </summary>
        /// <param name="guideStep"></param>
        /// <returns></returns>
        public bool IsLastGuidesStep(Step guideStep)
        {
            var guideId = guideStep.GuideId;
            if (!mGuideStepDict.ContainsKey(guideId))
            {
                return true;
            }
            var stepList = mGuideStepDict [guideId];
            return guideStep == stepList [stepList.Count - 1];
        }

        public void ResetAllStepStateByGuideId(uint guideId)
        {
            if (mGuideStepDict.ContainsKey(guideId))
            {
                var stepList = mGuideStepDict [guideId];
                foreach (var guideStep in stepList)
                {
                    guideStep.Reset();
                }
            }
        }

        public void ForceToResetAllStepByGuideId(uint guideId)
        {
            if (!mGuideStepDict.ContainsKey(guideId))
            {
                return;
            }
            foreach (var step in mGuideStepDict[guideId])
            {
                step.IsFinished = false;
            }
        }
    }
}