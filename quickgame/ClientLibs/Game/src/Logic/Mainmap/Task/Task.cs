//------------------------------------------------------------------------------
// Desc   :  任务对象类
// Author :  ljy
// Date   :  2017.6.1
//------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using xc.protocol;
using Net;
using xc;

namespace xc
{
    [wxb.Hotfix]
    public class Task : IComparable
    {
        public class StepProgress : IComparable
        {
            public uint StepId;
            public uint CurrentValue;

            public StepProgress()
            {
            }

            public int CompareTo(object obj)
            {
                StepProgress targetStep = (StepProgress)obj;

                if (this.StepId < targetStep.StepId)
                {
                    return -1;
                }

                return 0;
            }
        }

        TaskDefine mDefine;

        public uint State = 0;
        public List<StepProgress> StepProgresss = new List<StepProgress>();
        public uint StartTime;

        public static int CurDynamicShowPriority = 99999;
        /// <summary>
        /// 动态显示优先级，优先判断这个优先级，如果相等再判断Define.ShowPriority的优先级
        /// </summary>
        public int DynamicShowPriority = CurDynamicShowPriority;

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsOnTop = false;

        public Task(TaskDefine task)
        {
            mDefine = task;

            IsOnTop = mDefine.IsTemporaryOnTop;
        }

        public int CompareTo(object targetObj)
        {
            int result = 1;
            Task targetInfo = targetObj as Task;

            if (targetInfo.IsOnTop == true && this.IsOnTop == false)
            {
                result = 1;
            }
            else if (targetInfo.IsOnTop == false && this.IsOnTop == true)
            {
                result = -1;
            }
            else
            {
                if (targetInfo.State == GameConst.QUEST_STATE_DONE && this.State != GameConst.QUEST_STATE_DONE)
                {
                    result = 1;
                }
                else if (targetInfo.State != GameConst.QUEST_STATE_DONE && this.State == GameConst.QUEST_STATE_DONE)
                {
                    result = -1;
                }
                else
                {
                    if (targetInfo.Define.ShowPriority2 < this.Define.ShowPriority2)
                    {
                        result = 1;
                    }
                    else if (targetInfo.Define.ShowPriority2 > this.Define.ShowPriority2)
                    {
                        result = -1;
                    }
                    else
                    {
                        if (targetInfo.DynamicShowPriority < this.DynamicShowPriority)
                        {
                            result = 1;
                        }
                        else if (targetInfo.DynamicShowPriority > this.DynamicShowPriority)
                        {
                            result = -1;
                        }
                        else
                        {
                            if (targetInfo.Define.ShowPriority < this.Define.ShowPriority)
                            {
                                result = 1;
                            }
                            else if (targetInfo.Define.ShowPriority > this.Define.ShowPriority)
                            {
                                result = -1;
                            }
                            else
                            {
                                if (targetInfo.Define.SubType < this.Define.SubType)
                                {
                                    result = 1;
                                }
                                else if (targetInfo.Define.SubType > this.Define.SubType)
                                {
                                    result = -1;
                                }
                                else
                                {
                                    result = 0;
                                }
                            }
                        }
                    }
                }
            }

            //GameDebug.LogError("Task " + targetInfo.Define.Id + " compare to " + this.Define.Id + ", result: " + result);

            return result;
        }

        public static void IncreaseCurDynamicShowPriority()
        {
            CurDynamicShowPriority--;
        }

        public uint GetStepProgressValue(int stepIndex)
        {
            if (stepIndex >= StepProgresss.Count)
            {
                return 0;
            }

            return StepProgresss[stepIndex].CurrentValue;
        }

        public StepProgress GetStepProgress(int stepIndex)
        {
            if (stepIndex >= StepProgresss.Count)
            {
                return null;
            }

            return StepProgresss[stepIndex];
        }

        public void Update()
        {

        }

        public TaskDefine Define
        {
            get
            {
                return mDefine;
            }
        }

        public string CurrentGoal
        {
            get
            {
                var step = mDefine.GetStep((int)CurrentStepIndex);

                if (step == null)
                {
                    return string.Empty;
                }

                return step.Goal;
            }
        }

        public string CurrentStepFixedDescription
        {
            get
            {
                return GetStepFixedDescription((int)CurrentStepIndex);
            }
        }

        public uint CurrentStepIndex
        {
            get; set;
        }

        public TaskDefine.TaskStep CurrentStep
        {
            get
            {
                return mDefine.GetStep((int)CurrentStepIndex);
            }
        }

        public TaskDefine.TaskStep FirstStep
        {
            get
            {
                return mDefine.GetStep(0);
            }
        }

        public TaskDefine.TaskStep NextStep
        {
            get
            {
                return mDefine.GetStep((int)CurrentStepIndex + 1);
            }
        }

        public StepProgress CurrentStepProgress
        {
            get
            {
                if (CurrentStepIndex >= StepProgresss.Count)
                {
                    return null;
                }

                return StepProgresss[(int)CurrentStepIndex];
            }
        }

        public StepProgress NextStepProgress
        {
            get
            {
                int nextStepIndex = (int)CurrentStepIndex + 1;
                if (nextStepIndex >= StepProgresss.Count)
                {
                    return null;
                }

                return StepProgresss[nextStepIndex];
            }
        }

        public string GetStepFixedDescription(int stepIndex)
        {
            return Define.GetStepFixedDescription(stepIndex);
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("progress:{");
            for (int i = 0; i < StepProgresss.Count; ++i)
            {
                sb.Append(string.Format("[{0}]:{1}", i, StepProgresss[i].ToString()));
            }
            sb.Append("}");
            if (FirstStep != null)
            {
                sb.Append(",first_step:{");
                sb.Append(FirstStep.ToString());
                sb.Append("}");
            }
            if (NextStep != null)
            {
                sb.Append(",next_step:{");
                sb.Append(NextStep.ToString());
                sb.Append("}");
            }
            return sb.ToString();
        }
    }
}