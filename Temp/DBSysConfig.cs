using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using wxb;

namespace xc
{
	[Hotfix]
	public class DBSysConfig : DBSqliteTableResource
	{
		public enum ESysTaskType : byte
		{
			SYS_TASK_TYPE_NONE,
			SYS_TASK_TYPE_ACCEPT,
			SYS_TASK_TYPE_FINISH
		}

		public enum ESysBtnPos : byte
		{
			NONE,
			SYS_LBBTN_POS,
			SYS_TRBTN_POS,
			SYS_RIGHT_POS
		}

		public enum ESysBtnFixType : byte
		{
			NOT_FIX,
			FIX,
			FIX_WHEN_REDPOINT
		}

		public class SysConfig : IComparable
		{
			private DateTime timeLimit;

			public static byte NONE_ID = 0;

			public uint Id
			{
				get;
				protected set;
			}

			public ushort Level
			{
				get;
				protected set;
			}

			public DBSysConfig.ESysTaskType TaskType
			{
				get;
				protected set;
			}

			public uint TaskId
			{
				get;
				set;
			}

			public DBSysConfig.ESysBtnPos Pos
			{
				get;
				set;
			}

			public uint SubPos
			{
				get;
				set;
			}

			public DBSysConfig.ESysBtnFixType FixedPos
			{
				get;
				set;
			}

			public bool ShowBg
			{
				get;
				set;
			}

			public bool IsActivity
			{
				get;
				set;
			}

			public uint MainMapSysBtnId
			{
				get;
				set;
			}

			public string Desc
			{
				get;
				protected set;
			}

			public string BtnSprite
			{
				get;
				protected set;
			}

			public string BtnText
			{
				get;
				protected set;
			}

			public byte SortOrder
			{
				get;
				protected set;
			}

			public bool RedSpot
			{
				get;
				set;
			}

			public uint TransferLimit
			{
				get;
				set;
			}

			public string NotOpenTips
			{
				get;
				set;
			}

			public string Title
			{
				get;
				set;
			}

			public bool InitNeedShow
			{
				get;
				set;
			}

			public bool NeedAnim
			{
				get;
				set;
			}

			public int PatchId
			{
				get;
				set;
			}

			public bool HideBtnWhenActNotOpen
			{
				get;
				set;
			}

			public uint SysIdClosePresent
			{
				get;
				set;
			}

			public uint TabOrder
			{
				get;
				set;
			}

			public List<uint> DropDown
			{
				get;
				set;
			}

			public uint DropDownType
			{
				get;
				set;
			}

			public List<string> UIBehavior
			{
				get;
				set;
			}

			public string TimeLimitStr
			{
				get;
				set;
			}

			public bool CustomCondition
			{
				get;
				set;
			}

			public bool IsOpened
			{
				get
				{
					return Singleton<SysConfigManager>.Instance.CheckSysHasOpened(this.Id);
				}
			}

			public bool IsWaitingSystem
			{
				get
				{
					bool flag = this.Id == 18u;
					bool result;
					if (flag)
					{
						result = true;
					}
					else
					{
						bool flag2 = this.Id == 211u;
						if (flag2)
						{
							result = true;
						}
						else
						{
							bool flag3 = this.TransferLimit > 0u;
							result = flag3;
						}
					}
					return result;
				}
			}

			public bool IsWaitFinished
			{
				get
				{
					bool flag = !this.IsWaitingSystem;
					bool result;
					if (flag)
					{
						result = true;
					}
					else
					{
						bool flag2 = this.Id == 18u;
						if (flag2)
						{
							result = Singleton<LocalPlayerManager>.Instance.IsFinishOpenMountAnim();
						}
						else
						{
							bool flag3 = this.Id == 211u;
							if (flag3)
							{
								result = GodWareHelper.GetHasFinishShowGodWare();
							}
							else
							{
								bool flag4 = this.TransferLimit > 0u;
								result = (flag4 && TransferHelper.HasFinishShowTransferSuc(this.TransferLimit));
							}
						}
					}
					return result;
				}
			}

			public DateTime TimeLimit
			{
				get
				{
					bool flag = this.TimeLimitStr != "" && this.timeLimit.Year == 1 && this.timeLimit.Month == 1 && this.timeLimit.Day == 1;
					if (flag)
					{
						this.TimeLimitStr = this.TimeLimitStr.Replace(" ", "");
						MatchCollection matchCollection = Regex.Matches(this.TimeLimitStr, "\\{(\\w+),(\\d+),\\{(\\d+),(\\d+),(\\d+)\\}\\}");
						Dictionary<uint, float> dictionary = new Dictionary<uint, float>();
						foreach (Match match in matchCollection)
						{
							bool success = match.Success;
							if (success)
							{
								string value = match.Groups[1].Value;
								bool flag2 = value == "open";
								if (flag2)
								{
									DateTime serverOpenDateTime = Game.Instance.ServerOpenDateTime;
									int num = DBTextResource.ParseI(match.Groups[2].Value);
									int hour = DBTextResource.ParseI(match.Groups[3].Value);
									int minute = DBTextResource.ParseI(match.Groups[4].Value);
									int second = DBTextResource.ParseI(match.Groups[5].Value);
									this.timeLimit = new DateTime(serverOpenDateTime.Year, serverOpenDateTime.Month, serverOpenDateTime.Day, hour, minute, second);
									this.timeLimit = this.timeLimit.AddDays((double)(num - 1));
								}
							}
						}
					}
					return this.timeLimit;
				}
			}

			public uint TimeLimitDay
			{
				get
				{
					bool flag = string.IsNullOrEmpty(this.TimeLimitStr);
					uint result;
					if (flag)
					{
						result = 0u;
					}
					else
					{
						this.TimeLimitStr = this.TimeLimitStr.Replace(" ", "");
						MatchCollection matchCollection = Regex.Matches(this.TimeLimitStr, "\\{(\\w+),(\\d+),\\{(\\d+),(\\d+),(\\d+)\\}\\}");
						Dictionary<uint, float> dictionary = new Dictionary<uint, float>();
						IEnumerator enumerator = matchCollection.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								Match match = (Match)enumerator.Current;
								bool success = match.Success;
								if (success)
								{
									string value = match.Groups[1].Value;
									bool flag2 = value == "open";
									if (flag2)
									{
										result = DBTextResource.ParseUI(match.Groups[2].Value);
										return result;
									}
								}
								result = 0u;
								return result;
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
						result = 0u;
					}
					return result;
				}
			}

			public SysConfig(uint id)
			{
				this.Id = id;
				this.RedSpot = false;
			}

			public void Init(ushort lv, DBSysConfig.ESysTaskType task_type, uint task_id, DBSysConfig.ESysBtnPos pos, uint sub_pos, DBSysConfig.ESysBtnFixType fixed_pos, bool show_bg, bool is_activity, string desc, string btn_sprite, string btn_text, byte sort_order, uint transfer_limit, string not_open_tips, string sys_title, uint main_ui_id)
			{
				this.Level = lv;
				this.TaskType = task_type;
				this.TaskId = task_id;
				this.Pos = pos;
				this.SubPos = sub_pos;
				this.FixedPos = fixed_pos;
				this.ShowBg = show_bg;
				this.IsActivity = is_activity;
				this.Desc = desc;
				this.BtnSprite = btn_sprite;
				this.BtnText = btn_text;
				this.SortOrder = sort_order;
				this.TransferLimit = transfer_limit;
				this.NotOpenTips = not_open_tips;
				this.Title = sys_title;
				this.MainMapSysBtnId = main_ui_id;
			}

			public int CompareTo(object obj)
			{
				DBSysConfig.SysConfig sysConfig = obj as DBSysConfig.SysConfig;
				bool flag = sysConfig == null;
				int result;
				if (flag)
				{
					result = -1;
				}
				else
				{
					bool flag2 = this.Pos == DBSysConfig.ESysBtnPos.NONE && sysConfig.Pos > DBSysConfig.ESysBtnPos.NONE;
					if (flag2)
					{
						result = 1;
					}
					else
					{
						bool flag3 = this.Pos != DBSysConfig.ESysBtnPos.NONE && sysConfig.Pos == DBSysConfig.ESysBtnPos.NONE;
						if (flag3)
						{
							result = -1;
						}
						else
						{
							bool flag4 = this.FixedPos == DBSysConfig.ESysBtnFixType.FIX && sysConfig.FixedPos != DBSysConfig.ESysBtnFixType.FIX;
							if (flag4)
							{
								result = -1;
							}
							else
							{
								bool flag5 = this.FixedPos != DBSysConfig.ESysBtnFixType.FIX && sysConfig.FixedPos == DBSysConfig.ESysBtnFixType.FIX;
								if (flag5)
								{
									result = 1;
								}
								else
								{
									int num = this.SortOrder.CompareTo(sysConfig.SortOrder);
									bool flag6 = num != 0;
									if (flag6)
									{
										result = num;
									}
									else
									{
										result = this.Id.CompareTo(sysConfig.Id);
									}
								}
							}
						}
					}
				}
				return result;
			}
		}

		private List<DBSysConfig.SysConfig> mConfigList;

		private Dictionary<uint, DBSysConfig.SysConfig> mConfigMap;

		private Dictionary<uint, List<uint>> mConfigRelation;

		private static DBSysConfig mInstance;

		public static DBSysConfig Instance
		{
			get
			{
				return DBSysConfig.mInstance;
			}
		}

		public DBSysConfig(string strName, string strPath) : base(strName, strPath)
		{
			DBSysConfig.mInstance = this;
			this.mConfigList = new List<DBSysConfig.SysConfig>();
			this.mConfigMap = new Dictionary<uint, DBSysConfig.SysConfig>();
			this.mConfigRelation = new Dictionary<uint, List<uint>>();
		}

		public override void Unload()
		{
			base.Unload();
			this.mConfigList.Clear();
			this.mConfigMap.Clear();
			this.mConfigRelation.Clear();
		}

		protected override void ParseData(SqliteDataReader reader)
		{
			bool flag = reader == null || !reader.HasRows;
			if (!flag)
			{
				while (reader.Read())
				{
					uint num = DBTextResource.ParseUI(base.GetReaderString(reader, "sys_id"));
					DBSysConfig.SysConfig sysConfig = new DBSysConfig.SysConfig(num);
					string readerString = base.GetReaderString(reader, "sys_title");
					ushort lv = DBTextResource.ParseUS_s(base.GetReaderString(reader, "lv_open"), 0);
					string value = base.GetReaderString(reader, "task_limit");
					bool flag2 = string.IsNullOrEmpty(value);
					if (flag2)
					{
						value = "0";
					}
					DBSysConfig.ESysTaskType task_type = (DBSysConfig.ESysTaskType)Enum.Parse(typeof(DBSysConfig.ESysTaskType), value);
					uint task_id = DBTextResource.ParseUI_s(base.GetReaderString(reader, "task_args"), 0u);
					string value2 = base.GetReaderString(reader, "position");
					bool flag3 = string.IsNullOrEmpty(value2);
					if (flag3)
					{
						value2 = "0";
					}
					DBSysConfig.ESysBtnPos eSysBtnPos = (DBSysConfig.ESysBtnPos)Enum.Parse(typeof(DBSysConfig.ESysBtnPos), value2);
					uint sub_pos = DBTextResource.ParseUI_s(base.GetReaderString(reader, "sub_pos"), 0u);
					string text = base.GetReaderString(reader, "fixed_pos");
					bool flag4 = string.IsNullOrEmpty(text);
					if (flag4)
					{
						text = "0";
					}
					DBSysConfig.ESysBtnFixType fixed_pos = (DBSysConfig.ESysBtnFixType)DBTextResource.ParseUI_s(text, 1u);
					bool show_bg = DBTextResource.ParseUI_s(base.GetReaderString(reader, "show_bg"), 0u) == 1u;
					uint num2 = DBTextResource.ParseUI_s(base.GetReaderString(reader, "is_activity"), 0u);
					string readerString2 = base.GetReaderString(reader, "desc");
					string readerString3 = base.GetReaderString(reader, "btn_spr");
					string readerString4 = base.GetReaderString(reader, "btn_text");
					byte sort_order = DBTextResource.ParseBT_s(base.GetReaderString(reader, "sort_order"), 0);
					uint transfer_limit = DBTextResource.ParseUI_s(base.GetReaderString(reader, "transfer_limit"), 0u);
					string readerString5 = base.GetReaderString(reader, "not_open_tips");
					uint main_ui_id = DBTextResource.ParseUI_s(base.GetReaderString(reader, "main_ui_btn_id"), 0u);
					sysConfig.Init(lv, task_type, task_id, eSysBtnPos, sub_pos, fixed_pos, show_bg, num2 == 1u, readerString2, readerString3, readerString4, sort_order, transfer_limit, readerString5, readerString, main_ui_id);
					sysConfig.NeedAnim = (DBTextResource.ParseUI_s(base.GetReaderString(reader, "is_need_anim"), 0u) != 0u);
					bool flag5 = eSysBtnPos == DBSysConfig.ESysBtnPos.NONE;
					if (flag5)
					{
						bool needAnim = sysConfig.NeedAnim;
						if (needAnim)
						{
							sysConfig.NeedAnim = false;
							GameDebug.LogError(string.Format("sys:{0} 在主ui上没有图标, 却配置了开启动画", num));
						}
					}
					sysConfig.InitNeedShow = (DBTextResource.ParseUI_s(base.GetReaderString(reader, "is_need_show"), 0u) != 0u);
					sysConfig.PatchId = DBTextResource.ParseI_s(base.GetReaderString(reader, "patch_id"), 0);
					sysConfig.HideBtnWhenActNotOpen = (DBTextResource.ParseUI_s(base.GetReaderString(reader, "hide_btn_when_act_not_open"), 0u) != 0u);
					sysConfig.SysIdClosePresent = DBTextResource.ParseUI_s(base.GetReaderString(reader, "sys_id_close_present"), 0u);
					bool flag6 = sysConfig.SysIdClosePresent > 0u;
					if (flag6)
					{
						List<uint> list = null;
						bool flag7 = !this.mConfigRelation.TryGetValue(sysConfig.SysIdClosePresent, out list);
						if (flag7)
						{
							list = new List<uint>();
							this.mConfigRelation[sysConfig.SysIdClosePresent] = list;
						}
						bool flag8 = !list.Contains(sysConfig.Id);
						if (flag8)
						{
							list.Add(sysConfig.Id);
						}
					}
					sysConfig.TabOrder = DBTextResource.ParseUI_s(base.GetReaderString(reader, "tab_order"), 0u);
					sysConfig.DropDown = DBTextResource.ParseArrayUint(base.GetReaderString(reader, "drop_down"), ",", true);
					sysConfig.DropDownType = DBTextResource.ParseUI(base.GetReaderString(reader, "drop_down_type"));
					sysConfig.UIBehavior = DBTextResource.ParseArrayString(base.GetReaderString(reader, "ui_behavior"));
					sysConfig.TimeLimitStr = base.GetReaderString(reader, "time_limit");
					sysConfig.CustomCondition = (DBTextResource.ParseUI_s(base.GetReaderString(reader, "custom_condition"), 0u) != 0u);
					this.mConfigList.Add(sysConfig);
					this.mConfigMap[sysConfig.Id] = sysConfig;
				}
				this.mConfigList.Sort();
			}
		}

		public List<DBSysConfig.SysConfig> GetAllSysConfig()
		{
			return this.mConfigList;
		}

		public DBSysConfig.SysConfig GetConfigById(uint sys_id)
		{
			DBSysConfig.SysConfig result = null;
			this.mConfigMap.TryGetValue(sys_id, out result);
			return result;
		}

		public List<uint> GetRelationSysById(uint sys_id)
		{
			List<uint> result = null;
			this.mConfigRelation.TryGetValue(sys_id, out result);
			return result;
		}

		public DBSysConfig.SysConfig GetFirstMainId(uint mainId)
		{
			DBSysConfig.SysConfig sysConfig = null;
			DBSysConfig.SysConfig result;
			foreach (DBSysConfig.SysConfig current in this.mConfigList)
			{
				bool flag = current.MainMapSysBtnId == mainId;
				if (flag)
				{
					sysConfig = current;
				}
				bool flag2 = current.Id == mainId;
				if (flag2)
				{
					result = current;
					return result;
				}
			}
			result = sysConfig;
			return result;
		}

		public bool IsShowLock(uint sys_id)
		{
			DBSysConfig.SysConfig configById = this.GetConfigById(sys_id);
			bool flag = configById == null;
			return !flag && configById.InitNeedShow;
		}
	}
}
