
using xc.ui;

using System.Collections;
using System.Collections.Generic;
namespace xc
{

	// 游戏事件
	public enum ClientEvent
	{				
		CE_Normal = 0,

        /// <summary>
        /// 登录更新SDK
        /// </summary>
        CE_SDK_LOGINED,
        CE_SDK_INITED,
        CE_SDK_LOGINSUCC,
        CE_SDK_BIND_MOBILE_SUC,
        CE_RANDNAME_UPDATE,
        CE_DATA_HOTUP,
        CE_SELECT_SERVER, // 选中的服务器发生变化
        CE_START_GET_SERVER_INFOS,

        CE_SDK_SEND_VERIFY_CODE_RET,
        CE_SDK_BIND_PHONE_RET,

        CE_SDK_FACEBOOK_SHARE_SUCCESS,
        CE_SDK_FACEBOOK_SHARE_FAILED,

        /// <summary>
        /// 网络层
        /// </summary>
        CE_NET_MAIN_CONNECTED, // 主连接连上了
        CE_NET_CROSS_CONNECTED, //副连接连上了
        CE_NET_MAIN_DISCONNECT,// 主连接网络断开
        CE_NET_CROSS_DISCONNECT, // 副连接网络断开
        CE_NET_RECONNECT, // 断线重连成功
        CE_NETWORK_CHANGE, // 网络状态发生变化

        /// <summary>
        /// 充值
        /// </summary>
        CE_CHARGEINFO_UPDATE, // 充值信息发生变化
        CE_FIRST_PAY_TIPS_SHOW, // 显示首充提示

        /// <summary>
        /// 通用
        /// </summary>
        CE_SERVER_TIME_CHANGED, // 服务器时间
        CE_CHECK_MINIPACK,// 小包更新
        CE_QUIT_GAME,//退出游戏
        CE_ENTER_GAME, // 进入
        CE_GAME_INITED, // 游戏初始化完毕
        CE_ALL_SYSTEM_INITED, // 所有的系统网络数据初始化完毕
        CE_SYS_ERROR, // 系统错误
        CE_APPLICATION_PAUSE,   // 游戏应用程序暂停
        CE_PLAYER_DAILY_RESET,  // 玩家触发每日更新

        /// <summary>
        /// 跨服
        /// </summary>
        CE_SPAN_SERVER_OPEN, // 跨服开启
        CE_SPAN_SERVER_CLOSE, // 跨服关闭

        /// <summary>
        /// 设置
        /// </summary>
        CE_SETTING_AUTOADJUST,
        CE_SETTING_CHANGED,
        CE_SETTING_HOOK_CHANGED,
        CE_SETTING_OFFLINE_REWARD,
        CE_SETTING_QUALITY_CHANGED, // 游戏画质改变
        CE_SETTING_LOW_FPS, // fps较低

        /// <summary>
        /// 角色和怪物
        /// </summary>
        CE_LOCALPLAYER_CREATED,
        CE_LOCALPLAYER_MODEL_CHANGE,
        CE_REMOTEPLAYER_CREATED,    //远程玩家创建完成
        CE_ACTOR_BASEINFO_UPDATE,
        CE_ACTOR_LEVEL_UPDATE,
        CE_WORLD_LEVEL_UPDATE,  // 世界等级变化
        CE_LOCALPLAYER_EXP_ADDED,   // 玩家经验增加
        CE_LOCALPLAYER_BATTLE_POWER_CHANGED,   // 玩家战力变化
		CE_MONSTER_DEAD, // 接到服务端消息时，怪物死亡事件
		CE_MONSTERDEAD,
        CE_MONSTERCREATEED, // 怪物创建
        CE_LOCALMONSTERCREATEED,
		CE_REMOTEMONSTERCREATEED,
        CE_PLAYERDEAD,
        CE_NPCDEAD,
        CE_NPCCLICKED,
        CE_NPCLEAVED,
        CE_ACTOR_RES_LOADED, // 角色资源加载完毕
        CE_ACTOR_FRIEND_MARCK_CHANGED,
        CE_LOCAL_PLAYER_NWAR_CHANGED,//本地玩家血量蓝量同步
        CE_ACTOR_SET_CHAOS_MODE, //设置角色的混乱模式
        CE_ACTOR_PATH_POINTS_CHANGED,   // 角色寻路路点变化
        CE_LOCAL_PLAYER_ADD_ENEMY,      //主角仇恨列表新增一个敌人
        CE_LOCAL_PLAYER_EXCHANGE_PVP_STATE,      //主角切换PVP状态
        CE_LOCAL_PLAYER_NWAR_DEAD,//本地玩家死亡
        CE_LOCAL_PLAYER_NWAR_REVIVE,//本地玩家复活
        //--------------状态机-------------
        CE_STATUS_TRANSFER_EXIT,
        // --------------------------------
        // ----------寻路和AI---------------
        CE_DISABLE_CLICKEFFECT, // 取消点击地面的特效
        // --------------------------------
        // ---------本地玩家事件------------
        PLAYER_DEAD,
        PLAYER_BE_ATTACKED,
        PLAYER_EXIT_IDLE,
        EC_PLAYER_LV_POINT_UPDATE,
        EC_PLAYER_ATTRS_UPDATE,
        EC_ACTOR_HP_CHANGE,
        CE_SHOW_ATTRS_UPDATE_WINDOW,
        EC_ACTOR_MP_CHANGE,
        EC_ACTOR_UNDER_ATTACK_CHANGE,   //恶意攻击目标更改
        EC_ACTOR_ADD_UNDER_ATTACK,   //新增恶意攻击目标
        CE_GUARDED_NPC_HP_CHANGE, // 守护npc血量变化
        // --------------------------------
        CE_CUSTOM_DATA_UPDATE, // 客户端自定义数据更新


        /// <summary>
        /// 主城系统
        /// </summary>
        // -------------场景切换-----------
        CE_FIRST_ENTER_SCENE,   //玩家登录后首次进入场景
        CE_START_SWITCHSCENE, //开始切换场景,SwitchScene调用的时候触发
        CE_FINISH_LOAD_LEVEL,   // 结束加载场景，资源下载完后触发
        CE_FINISH_SWITCHSCENE,//完成切换场景，场景加载完毕后触发（只切换副本状态也会触发）
        CE_FINISH_LOAD_SCENE,   // 结束加载场景，等loading界面隐藏后才触发
        CE_SWITCHINSTANCE,// 进入副本状态时候触发(此时也已经完成了副本资源的记载)
        CE_START_SWITCH_PLANE_INSTANCE,//开始切换位面副本场景

        CE_SCENE_DESTROY_ALL_INTER_OBJECT, //销毁所有场景中的InterObject
        // --------------------------------
        // -------------点击玩家-----------
        CE_CLICKPLAYER,// 点击其他玩家
        CE_CLICKPLAYER_INFO,// 点击其他玩家的弹出头像
        CE_CLICKNPC,// 点击NPC
        CE_CLICKCHEST,// 点击宝箱
        CE_CLICKMONSTER,// 点击怪物
        CE_CLICKCOLLISION, //点击地面
        CE_CLICKCOLLISION_INFO, // 点击地面(添加坐标点信息)
        CE_CLICKINTEROBJECTLAYER,   // 点击InterObject
        CE_COVER_STATE_CHANGE, // 主角被遮挡状态发生变化
        CE_CLICKPLAY_DISPLAY_INFO, // 点击的玩家显示的信息更新
        // --------------------------------
        CE_PLAYERCONTROLED,
        CE_PLAYER_IN_PORTAL,
        CE_TRANSFER,
        CE_MAINMAP_STATE_CHANGED,//主城BOSS血条状态切换
        CE_MAINMAP_ANIMATION_PLAY_END,//主城动画播放完毕
        CE_MAINMAP_SWITCH_ANIMATION,//当打开或关闭系统界面主城动画播放事件
        CE_MAINMAP_SWTICH_TR_SYSBTN, // 切换主UI右上角的按钮状态
        CE_TOUCH_NOT_UI,//主城用的触摸到非UI发送事件
        CE_MAINMAP_OPEN,//主城UI打开          
        CE_MAIN_MAP_CHECK_MARK, //主城红点更新事件要传参若null全部更新
        CE_UPDATE_SYS_MARK,//通知各个系统指定细分模块更新红点
        CE_MAINMAP_CLICK_BL_PACKUP_BTN, //点击左下角按钮

        CE_MAINMAP_CHANGE_BOSSHP_VISIBLE,//改变BOSS血条的可见
        // -------------地图---------------
        CE_CHANGE_LINE_CD_TIME, //换线cd
        CE_CHANGE_LINE,
        CE_LINE_INFO,
        // --------------------------------
        // ------------新手引导------------
        CE_GUIDESTART,
        CE_GUIDEEND,
        CE_GUIDE_STORY_END,
        CE_GUIDE_UNFOLD_SYS_BTN,

        // --------------------------------
        // ------------系统开放------------
        CE_SYS_CONFIG_INIT, // 系统开放初始化完成
        CE_NEW_WAITING_SYS, // 有新的可开放系统
        CE_RE_OPEN_SYS, // 系统被关闭后重开
        CE_SYS_RED_SPOT_CHANGE, // 系统状态有更新时，显示红点
        CE_SYS_OPEN, // 系统开放
        CE_SYS_OPEN_POST, // 新系统开放（只在野外响应）
        CE_SYS_OPEN_NOTIFY, // 系统开放通知（不等系统开放动画完成）
        CE_SYS_CLOSE,// 系统关闭
        CE_SYS_BTN_CLOSE,// 系统按钮关闭
        CE_SYS_OPEN_ANIM_START,   // 系统开放动画开始
        CE_SYS_OPEN_ANIM_END,   // 系统开放动画结束
        CE_HSYSBTN_CHANGE, // 屏幕上放的按钮需要偏移时
        CE_SYS_WAIT_OPEN_SWITCH_ANIMATION,//系统开放通知主城展开系统
        CE_SYS_SPECIAL,// 特殊的系统开放（比如怒气技能按钮）
        CE_POST_SHOW_TREASURE_OPEN,// 打宝特殊事件
        CE_POST_OPEN_TREASURE_PREVIEW,
        CE_SHOW_TREASURE_OPEN,// 打宝特殊事件
        // --------------------------------
        // ------------系统预览------------
        CE_SYS_PREVIEW_REWARDED_LISTS, // 已领奖励的系统
        CE_SYS_PREVIEW_REWARD, // 应答领取奖励
        // --------------------------------
        // ----------小红点----------------
        CE_NEW_REDPOINT_SHOW,       //显示小红点(新)
        CE_NEW_REDPOINT_DISAPPEAR,  //消失小红点(新)
        CE_NEW_REDPOINT_BIND,       //注册小红点(新)
        CE_NEW_REDPOINT_UNBIND,       //取消注册(新)

        //----------注册锁头-------------------
        CE_LOCK_ICON_BIND,         //注册锁头
        CE_LOCK_ICON_UNBIND,       //取消锁头

	    //----------注册New标记----------------
	    CE_NEW_MARKER_BIND,         //注册New
        CE_NEW_MARKER_UNBIND,       //取消New

        // --------------------------------
        // -------------系统提示-----------
        CE_SHOW_ROLLING_NOTICE, // 滚动系统提示（跑马灯）
        CE_SHOW_ROLLING_NOTICE_END, // 滚动系统提示结束（跑马灯）
        CE_SHOW_COMMON_TIPS_WARNNING,   // 系统警告
        CE_SHOW_DANMAKU,    // 弹幕
        CE_CLEAR_DANMAKU,    // 清除弹幕
        CE_SHOW_BOTTOM_MESSAGE, // 屏幕底部提示
        CE_SHOW_COMMON_TEXT_TIPS,   // 通用文字提示
        CE_SHOW_BIG_COMMON_TEXT_TIPS,   // 通用文字提示，大界面的
        // --------------------------------
        // ------------小地图显示控制------
        NEW_MINIMAP_SELECT_MONSTER_MINIMAPINFO,//选择怪物TagID事件
        CE_MINI_MAP_COM_POS,//小地图传递坐标
        // --------------------------------

        /// <summary>
        /// 副本
        /// </summary>
        CE_INSTANCE_START,  // 副本开始
        CE_LOCALPLAYER_CREATE,
        CE_REMOTEPLAYER_CREATE,
        CE_EXITINSTANCE,
        CE_INSTANCE_POLL_INFO_CHANGED,
        CE_INSTANCE_PHASE_CHANGED,  // 副本阶段改变
        CE_INSTANCE_PHASE_PROGRESS_CHANGED,  // 副本阶段进度改变
        CE_INSTANCE_MARK_CHANGED,   // 副本评分改变
        CE_INSTANCE_KUNGFUGOD_CHANGED,   // 武神塔改变
        CE_INSTANCE_DEAD_SPACE_LV_CHANGED,   // 破碎死域阶段改变
        CE_INSTANCE_DEAD_SPACE_SCORE_CHANGED,   // 破碎死域积分改变
        CE_INSTANCE_DEAD_SPACE_EXP_CHANGED,   // 破碎死域经验值改变
        CE_INSTANCE_FAIRY_VALLEY_INFO_CHANGED,  // 仙灵山谷信息改变
        CE_INSTANCE_FAIRY_VALLEY_INSPIRE_NUM_CHANGED,  // 仙灵山谷鼓舞次数改变
        CE_WILD_HUMAN_COUNT_CHANGED,// 野外
        CE_INSTANCE_SHOW_EXIT_INSTANCE_TIME_LABEL,  // 离开副本倒计时（离开按钮旁边的倒计时文本）
        //---------AOI--------------------
        CE_LEAVEAOI,
        CE_CLEAR_UNITCACHE,   // 清除所有创建角色的缓存信息
        // --------------------------------
        //---------副本界面的事件----------
        UPDATE_AUTO_BATTLE_UI,
        SHOW_AUTO_BATTLE_GET_EXP,
        SHOW_SKILL_PANEL, // 通知主ui显示技能面板
        // --------------------------------
        //-------------拾取----------------
        CE_PICK_DROP,    // 拾取掉落的物品
        CE_DESTROY_DROP,    // 销毁掉落物品
        CE_DROP_DISAPPEAR, // 掉落消失
        CE_SHOW_PICK_DROP_FLOAT_TIPS,   // 显示掉落飘字
        CE_PICK_DROP_SHOW_BOSS_CHIP,    // 显示拾取掉落的物品(BOSS碎片)
        CE_PICK_DROP_DISAPPEAR_BOSS_CHIP,    //不显示拾取掉落的物品(BOSS碎片)
        CE_PICK_DROP_BREAK_PICK_UP,     //打断采集BOSS碎片的掉落物
        CE_PICK_DROP_START_PICK_UP_LOCALPLAYER,     //开始采集BOSS碎片的掉落物（主角）
        CE_PICK_DROP_CONTROL_SLIDER,     //吸取魂魄碎片的进度条
        CE_LOCAL_PLAYER_EXIT_INTERACTION,   //主角退出“互动”状态
        // --------------------------------

        /// <summary>
        /// 邮件
        /// </summary>
        CE_MAIL_UPDATE,
        CE_MAIL_DETAIL,
        CE_MAIL_NEW,
        CE_MAIL_READ,
        CE_MAIL_GET,    // 领取邮件附件
        CE_MAIL_DEL,
        NEW_MAIL_RECEIVED,

        /// <summary>
        /// 物品背包
        /// </summary>
        CE_BAG_UPDATE,
        CE_BAG_UPDATE_SLOT, //更新某些格子(新增物品)
        CE_BAG_UPDATE_SLOT_DEL, //更新某些格子(删除物品)
        CE_BAG_UPDATE_SLOT_INSTALL, //更新某些格子（由于穿戴或者卸下装备引起的）
        CE_BAG_UPDATE_SLOT_EXTEND,  //扩展背包格子

        /// <summary>
        /// 仓库整理事件
        /// </summary>
        CE_WARE_UPDATE_SLOT, //更新某些格子
        CE_WARE_UPDATE_SLOT_INSTALL, //更新某些格子（由于穿戴或者卸下装备引起的）
        CE_WARE_UPDATE_SLOT_EXTEND,  //扩展仓库格子

        CE_BAG_ADD, // 普通背包新增物品
        CE_BAG_DEL, // 普通背包删除物品
        CE_BAG_GOODS_ADD_NUM, // 普通背包物品增加数量（包括新增）
        CE_BAG_GOODS_ADD_NUM_OPERATE_NONE, // 普通背包物品增加数量(包括新增, 仅限获取新物品)
        CE_BAG_PAGE_UPDATE,
        CE_WAREHOUSE_UPDATE,
        CE_WAREHOUSE_PAGE_UPDATE,
        CE_INSTALL_1_UPDATE,
        CE_SOUL_UPDATE,//武魂背包更新
        CE_SOUL_PAGE_UPDATE,
        CE_INSTALL_2_UPDATE,//武魂装备背包更新
        CE_INSTALL_2_PAGE_UPDATE,//装备武魂更新
        CE_GOODS_CD_UPDATE,
        CE_MONEY_UPDATE,
        CE_OFFLINE_HANGE_TIME_UPDATE, // 离线挂机时间更新
        CE_GOODS_ADD_TIP,   // 物品增加提示
        CE_ONE_BAGTYPE_SIZE_UPDATE, //某个类型的背包大小刷新
        CE_INSTALL_1_EFLIN_UPDATE, //身上小精灵刷新
        CE_GOODS_UPDATE_EXPIRE_TIME, //更新物品的有效期
        CE_GOODS_USE_TIMES_UPDATE,  // 物品每日已使用次数的刷新

        CE_INSTALL_3_UPDATE,// 已穿戴饰品更新
        CE_DECORATE_BAG_SIZE_UPDATE, // 饰品背包格子数更新
        CE_DECORATE_BAG_UPDATE, // 饰品背包更新
        CE_TREASURE_HUNT_UPDATE,    //寻宝仓库更新
        CE_ID_TREASURE_BAG_UPDATE,    //鉴宝仓库更新
        CE_HANDBOOK_BAG_SIZE_UPDATE, // 图鉴背包格子数更新
        CE_HANDBOOK_UPDATE,    //图鉴背包更新

        CE_WEARING_MAGIC_EQUIP_UPDATE, // 已穿戴法宝装备更新
        CE_MAGIC_EQUIP_BAG_UPDATE, // 法宝装备背包更新
        CE_MAGIC_EQUIP_BAG_SIZE_UPDATE, // 法宝装备背包格子数更新

        CE_GOD_EQUIP_UPDATE,// 已穿戴神兵更新
        CE_GOD_EQUIP_BAG_SIZE_UPDATE, // 神兵背包格子数更新
        CE_GOD_EQUIP_BAG_UPDATE, // 神兵背包更新

        CE_ELEMENT_EQUIP_UPDATE,// 已穿戴元素装备更新
        CE_ELEMENT_EQUIP_BAG_UPDATE, // 元素装备背包更新

        CE_MOUNT_EQUIP_UPDATE,// 已穿戴坐骑更新
        CE_MOUNT_EQUIP_BAG_UPDATE,// 坐骑装备更新
        CE_MOUNT_EQUIP_BAG_SIZE_UPDATE,//坐骑背包格子更新

        CE_LIGHT_WEAPON_SOUL_UPDATE_INSTALLED,        // 已穿戴神魂更新
        CE_LIGHT_WEAPON_SOUL_BAG_UPDATE,    //光武神魂背包更新
        CE_LIGHT_WEAPON_SOUL_BAG_SIZE_UPDATE,    // 光武神魂背包格子数更新

        CE_GOODS_LIST_UPDATE,   // 所有背包类型的物品信息变化，主要响应s2c_goods_list和s2c_goods_del两个协议

        /// <summary>
        /// 武魂
        /// </summary>
        CE_OPEN_SPIRIT_RUNES_WINDOW,// 打开武魂界面
        CE_SOUL_OPEN_UPDATE,//武魂图鉴发生改变

        /// <summary>
        /// 组队
        /// </summary>
        CE_TEAM_INFO_CHANGED,
        CE_TEAM_APPLY_INFO_CHANGED,
        CE_TEAM_BE_INVITED,
        CE_TEAM_TARGET_CHANGED,
        CE_TEAM_AUTO_MATCHING_STATE_CHANGED,
        CE_TEAM_INVITE_ALL_CD_CHANGED,
        CE_TEAM_SYSTEM_MESSAGE_SHOW, // 组队系统消息
        CE_TEAM_CLICK_CLOSE_WINDOW_BTN, // 点击关闭界面按钮
        CE_TEAM_HIDE_WINDOW, // 隐藏界面

        /// <summary>
        /// 装备
        /// </summary>
        CE_INSTALLED_EQUIP_CHANGED, // 穿上或者卸下装备
        CE_EQUIP_INFO_CHANGED, // 任意装备信息改变
        CE_INSTALLED_EQUIP_INFO_CHANGED,
        CE_STRENGTH_RESULT,//强化反馈
        CE_STRENGTH_UP_LV,//强化升级反馈
        CE_STRENGTH_EQUIP_CHANGED,//强化改變
        CE_BAPTIZE_EQUIP_CHANGED,//洗练改变
        CE_BAPTIZE_EQUIP_RESULT,//洗练反馈
        CE_SUIT_EQUIP_CHANGED,//套装更新
        CE_SUIT_REFINE_CHANGED, // 套装精炼更新
        CE_EQUIP_GEM_CHANGED,//装备宝石更新
        CE_OPEN_EQUIP_STRENGTH_WINDOW,//打开装备强化界面
        CE_EQUIP_FASHION_CHANGED,//装备时装变化

        /// <summary>
        /// 饰品
        /// </summary>
        CE_DECORATE_STRENGTH_RESULT,    // 强化反馈
        CE_DECORATE_BREAK_RESULT,    // 突破反馈
        CE_DECORATE_POS_INFO_UPDATE, // 饰品部位信息更新

        /// <summary>
        /// 战斗和技能
        /// </summary>
        CE_CHANGE_LOCKTARGET, //切换锁定的目标
        CE_TRIGGER_SKILL_CLICK_BUTTON, //点击技能按钮
        CE_TRIGGER_SKILL_PRESS_BUTTON, //按下技能按钮
        CE_TRIGGER_SKILL_RELEASE_BUTTON, //释放技能按钮
        CE_TRIGGER_SKILL,
        CE_ATTACK_SUCC, //技能触发成功
        CE_SELECTACTOR_CHANGE, // 战斗中选中的目标(手动或自动)发生改变
        CE_SELECTACTOR_WHEN_CAST_SKILL, // 在准备释放技能，选中的目标
        CE_BATTLESTATUS_CHANGE, // 战斗状态发生改变（进入、退出战斗状态）
        CE_SHAPE_SHIFT_BEGIN, //角色进行了变身
        CE_SHAPE_SHIFT_END, //角色结束了变身
        CE_CHANGE_LOCALPLAYER_CASTINGREADY_STATGE,  //改变localPlayer是否处于吟唱阶段
        CE_CHANGE_LOCALPLAYER_PKMODE,           //改变localPlayer的PK模式
        CE_CHANGE_LOCALPLAYER_PKVALUE,          //改变localPlayer的PK值
        CE_CHANGE_LOCALPLAYER_IN_SAFE_AREA,     //改变localPlayer是否在安全区域
        CE_CHANGE_LOCALPLAYER_IN_PK_AREA,       //改变localPlayer是否在PK区域
        CE_BUFF_LIST_CHANGE, // buff列表发生改变
        CE_CHANGE_LOCALPLAYER_RADIUS,       //改变主角的模型大小
        CE_CHANGE_LOCALPLAYER_SKILL_SLOT_LIST,  //改变主角技能槽列表
        CE_AUTO_FIGHT_STATE_CHANGED,    // 自动战斗状态改变
        CE_BUFF_UPDATE, // 本地玩家的buff进行了更新
        CE_CLICK_MATE_SKILL,//点击情侣技能
        CE_MATE_SKILL_ACTION,//情侣动作返回
        CE_FIVE_ATTR_NOENOUGH, // 五行属性不足
        // --------------技能--------------
        SKILL_LIST_RECEIVED,
        SKILL_UPGRADED,
        SKILL_KEY_POS_SET,
        SKILL_KEY_CONFIG_CHOOSED,
        INBORN_INFO_RECEIVED,
        CE_SKILL_OPENNEW, // 开启了新的技能
        CE_FURYSKILL_CANUSE, // 怒气技能可释放
        SKILL_MATE_UPDATE,//情侣技能刷新显示主UI的icon
        SKILL_MATE_USE_SUCCESS,//情侣技能使用成功
        // --------------------------------

        /// <summary>
        /// 好友
        /// </summary>
        CE_FRIENDS_ONLINE_CHANGE,//好友在线变化
        CE_FRIENDS_CHANGE,
        CE_FRIENDS_ENEMY_POS,
        CE_FRIENDS_SEARCH_RESULT,
        CE_FRIENDS_RECOMMEND,//推荐好友
        CE_FRIENDS_RECOMMEND_CD,//推荐好友CD
        CE_FRIENDS_APPLICANTS_CHANGE,    // 好友申请变化
        CE_FRIENDS_INTIMACY_CHANGE,    // 好友亲密度变化
        CE_FRIENDS_ADD_BOTH_SIDES, //双方都加为好友
        CE_RECEIVE_FLOWER,    // 收花
        CE_SEND_FLOWER_KISS,

        /// <summary>
        /// 聊天
        /// </summary>
        CE_CHAT_UNREAD_MESSAGE_CHANGED, // 未读消息变化
        CE_CHAT_PLAY_NOTICE_MESSAGE,    // 播放公告
        CC_CHAT_PLAY_VOICE_MESSAGE,     // 播放语音
        CE_CHAT_VOICE_CLICK_MESSAGE,    
        CE_CHAT_VOICE_START_MESSAGE,    // 主界面录音开始
        CE_CHAT_VOICE_END_MESSAGE,     // 主界面录音结束
        CE_CHAT_TOOLKIT_SEND_TEXT_TO_INPUTFIELD,//操作按钮
        CE_CHAT_HISTORY_TO_INPUTFIELD,
        CE_CHAT_TRUMPET_CONTENT,//喇叭内容
        WORLD_MESSAGE_RECEIVED,
        SOCIETY_MESSAGE_RECEIVED,
        PRIVATE_MESSAGE_RECEIVED,
        TEAMENLIST_MESSAGE_RECEIVED,
        INVITE_MESSAGE_RECEIVED,
        TEAM_MESSAGE_RECEIVED,
        WILD_MESSAGE_RECEIVED,
        SYSYTEM_MESSAGE_RECEIVED,
        SPAN_MESSAGE_RECEIVIED, // 跨服
        INTEGRATE_MESSAGE_RECEIVED,//主界面汇总
        CHAT_VOICE_RECORDING_CANCELD,//取消录音
        TRUMPET_MESSAGE_RECEIVED,
        UNION_MESSAGE_RECEIVED,
        CROSS_SERVER_CAMP_MESSAGE_RECEIVED,
        CROSS_SERVER_PUBLIC_MESSAGE_RECEIVED,
        AOI_MESSAGE_RECEIVED,
        VOICE_AUTOPLAY_NOTIFY,
        SEND_CHAT_NOTIFY,
        VOICE_PLAY_NOTIFY,
        CLOSE_CHAT_WINDOW,
        CE_CHAT_JUMP_TO_CONST_POSITION,

        CHAT_CLICK_RECHARGE_RED_PACKET, // 点击充值红包
        CE_CHAT_SET_OPERATE_RECHARGE_RED_PACKET, // 标记操作过充值红包

        // -------------录音-----------------
        CE_GVOICE_START_RECORD,     //开始录音
        CE_GVOICE_STOP_RECORD,      //停止录音
        CE_GVOICE_SPEECH_TO_TEXT_COMPLETE,  //录音完成
        CE_GVOICE_RECORD_PLAY_DONE,  //录音播放完成
        CE_VOICE_CONTROL_POINTER_ENTER,
        CE_VOICE_CONTROL_POINTER_EXIT,
        CE_VOICE_CONTROL_POINTER_CLICK,
        // --------------------------------

        /// <summary>
        /// UI框架
        /// </summary>
        SELECT_UI,  // 当选中某一UI控件
        OPEN_SYS_WIN,   // 打开系统窗口
        CLOSE_SYS_WIN,      // 关闭系统窗口
        SHOW_WIN,  // 打开窗口
        CLOSE_WIN,  // 关闭窗口
        KEYBOARD_CHANGE,//增加keyBoard事件用作传递键盘
        CONTROL_COMMON_SLIDER,//控制通用的进度条
        SHOW_INTERACT_BUTTON,   // 显示或隐藏交互按钮
        INTERACT_BUTTON_CLICK_CALLBACK, // 交互按钮点击回调

        /// <summary>
        /// 任务
        /// </summary>
        TASK_CHANGED,
        TASK_PROGRESS_CHANGED,  // 任务进度变化
        TASK_ADDED,         // 有新添加的任务
        TASK_FINISHED,      // 有新完成的任务
        TASK_NEW_ACCEPTED,  // 有新接取的任务
        TASK_CAN_SUBMIT,    // 有可提交的任务
        TASK_NAVIGATION_ACTIVE,
        INTERACT_TASK_NPC_TOUCHED,  // 玩家触碰了交互任务的NPC
        INTERACT_TASK_NPC_UNTOUCHED,
        BOUNTY_TASK_CHANGED,    // 赏金任务更新
        NAVIGATING_MAIN_TASK_CHANGED,   // 导航中的主线任务改变
        NAVIGATING_BOUNTY_TASK_CHANGED,    // 导航中的赏金任务改变
        NAVIGATING_GUILD_TASK_CHANGED,    // 导航中的帮派任务改变
        GUILD_TASK_CHANGED,     // 帮派任务更新
        TITLE_TASK_CHANGED,     // 头衔任务更新
        ESCORT_TASK_CHANGED,    // 护送任务更新
        OPEN_TASK_WINDOW,       // 打开帮派任务界面
        TRANSFER_TO_TASK_POS,   // 传送到任务地点，用于飞鞋
        TASK_GUIDE, // 任务导航事件
        TRANSFER_TASK_CHANGED,    // 赏金任务更新

        /// <summary>
        /// 商店事件
        /// </summary>
        SELL_INFO_RECEIVED,
        BUY_SUCCESSED,
        CE_MALL_RECV_SHOP_GOODS, //收到商城数据

        /// <summary>
        /// 对话
        /// </summary>
        CE_UPDATE_DIALOG_WINDOW_INFO,
        CE_DIALOG_END,

        /// <summary>
        /// 世界BOSS
        /// </summary>
        CE_WORLD_BOSS_UPDATE_BOSS_INFO_ALL, //更新所有BOSS信息
        CE_WORLD_BOSS_CANCEL_NOTICE,       //取消一个关注BOSS

        /// <summary>
        /// 宠物
        /// </summary>
        CE_PET_UPDATE_PET_INFO, //更新所有的宠物列表
        CE_PET_UPDATE_PET_EXP,  //更新宠物经验
        CE_PET_UPDATE_PET_STEP_EXP,     //更新某个宠物的等阶经验
        CE_PET_CHANGE_SKIN,         //更新出战皮肤
        CE_PET_UNLOCK_SKIN,         //解锁皮肤
        CE_PET_UI_SELECT_SKIN,         //选中某个皮肤
        CE_PET_UI_TRY_SELECT_PRE_SKIN,         //选中上个某个皮肤
        CE_PET_UI_TYE_SELECT_NEXT_SKIN,         //选中下个某个皮肤
        CE_PET_UPDATE_ALL_PET_PROP,         //更新所有宠物的属性
        CE_PET_CLICK_TRY_OPEN_SKIN,         //尝试解锁皮肤界面
        CE_PET_OPEN_INFO_PANEL,             //打开信息界面
        CE_PET_OPEN_DEGREE_PANEL,           //打开进阶界面
        CE_PET_MAIN_CHANGED_IN_SCENE,       //改变了场景上的宠物ID（主角）
        CE_PET_SHOW_LEVLE_UP_PANEL,     //宠物升级界面
        CE_OPEN_PET_WINDOW, // 打开宠物界面
        CE_PET_SHOW_LEVLE_UP_STEP_LV,   //宠物升级
        CE_PET_CREATED, // 本地玩家的宠物创建好
        CE_PET_TRIGGER_SKILL,   //本地玩家的宠物触发技能

        /// <summary>
        /// 帮派
        /// </summary>
        CE_GUILD_CHANGED_GUILD_ID_IN_SCENE,       //改变了场景上的帮派ID（主角）
        CE_GUILD_SUCCESS_CREATE_GUILD,              //成功创建帮会
        CE_GUILD_SUCCESS_JOIN_GUILD,            //成功加入公会
        CE_GUILD_UPDATE_GUILD_INFO,              //更新帮会信息
        CE_GUILD_SUCCESS_EDIT_NOTICE,           //成功修改公告（公会公告或者招募公告）
        CE_GUILD_RECV_INTRO_LIST,                //收到公会列表
        CE_GUILD_SHOW_MAIN_PANEL,                //显示主页
        CE_GUILD_RECV_INTRO_EXTRA,              //收到某个公会的额外信息
        CE_GUILD_SHOW_GUILD_LIST_PANEL,                //显示公会列表
        CE_GUILD_LOCAL_PLAYER_LEAVE_GUILD,                //(主角)离开公会
        CE_GUILD_OTHER_PLAYER_LEAVE_GUILD,                //(其他玩家)离开公会
        CE_GUILD_RECV_MEMBER_LIST,          //收到公会成员列表
        CE_GUILD_RECV_DUTY_APPOINT,         //收到某个玩家的职务任免
        CE_GUILD_RECV_LOCAL_PLAYER_DUTY_APPOINT,         //收到LocalPlayer的职务任免
        CE_GUILD_RECV_APPLY_INFO,           //收到申请列表
        CE_GUILD_RECV_HANDLE_APPLY,         //收到申请处理结果
        CE_GUILD_RECV_AUTO_APPROVE,         //收到修改“自动加入帮派”状态
        CE_GUILD_RECV_ADD_MEMBER,       //收到有新加入加入帮派
        CE_GUILD_RECV_SKILL_LIST,       //收到帮派技能列表
        CE_GUILD_RECV_APPLY_NOTICE,     //收到申请列表小红点提示
        CE_GUILD_SHOW_GUILD_SKILL_PANEL, //显示帮派技能面板
        CE_GUILD_GUILD_HAS_BEEN_DELETED,    //访问的公会已经被删除
        CE_GUILD_CHANGED_ID_IN_SCENE,       //主角帮派ID更新
        CE_GUILD_RECV_BOSS_INFO,            //收到帮派BOSS的信息
        CE_GUILD_RECV_CHANGE_BOSS_LEVEL,    //改变帮派BOSS难度
        CE_GUILD_SUCCESS_OPEN_BOSS,     //成功开启BOSS
        CE_GUILD_CLOSE_BOSS,                //关闭BOSS
        CE_GUILD_RECV_REWARD_PERDAY,        //每日奖励领取
        CE_GUILD_FUND_CHANGE,               //改变帮派资金

        /// <summary>
        /// 帮派联赛
        /// </summary>
        CE_GUILD_LEAGUE_INFO_CHANGED,   // 帮派联赛信息改变

        /// <summary>
        /// 坐骑
        /// </summary>
        CE_MOUNT_UPDATE_GROW_INFO,  //更新成长信息
        CE_MOUNT_SUCCESS_UPGRADE,   //成功升级
        CE_MOUNT_SUCCESS_GET_NEW_SKIN,  //成功获得新皮肤
        CE_MOUNT_SUCCESS_USE_SKIN,      //使用皮肤
        CE_MOUNT_SUCCESS_CHANGE_CUR_SKIN,      //改变正在使用的皮肤
        CE_MOUNT_UI_SELECT_SKIN,        //选中的皮肤
        CE_MOUNT_OPEN_DEGREE_PANEL, //打开进阶界面
        CE_MOUNT_OPEN_SKIN_PANEL,   //打开皮肤界面
        CE_MOUNT_OPEN_GET_NEW_MOUNT_PANEL,  //打开获得新坐骑的界面
        CE_MOUNT_CLOSE_GET_NEW_MOUNT_PANEL,  //关闭获得新坐骑的界面
        CE_MOUNT_LOCAL_PLAYER_CHANGED_ID_IN_SCENE,   //改变主角在场景中的坐骑ID
        CE_OPEN_MOUNT_WINDOW,   //打开坐骑界面
        CE_MOUNT_EXCHANGE_FIRST_GETING_NEW_MOUNT_ID,  //第一次(坐骑系统未开放)获得新坐骑

        /// <summary>
        /// 试炼BOSS
        /// </summary>
        CE_TRIALBOSS_RECV_PASS_INFOS,   //收到通关数据
        CE_TRIALBOSS_RECV_GRADE,        //收到进度信息
        CE_TRIALBOSS_RECV_INSPIRE,        //收到鼓舞信息
        CE_TRIALBOSS_RECV_WIN_DUNGEON_RESULT,   //收到获胜的副本结算消息

        /// <summary>
        /// 圣痕
        /// </summary>
        CE_STIGMATA_RECV_INFO,      //收到列表信息
        CE_STIGMATA_RECV_SUCCESS_ADD_EXP,      //收到成功加经验
        CE_STIGMATA_RECV_SHOW_LEVEL_UP,      //收到成功升级
        CE_STIGMATA_UI_SELECT_SKIN,      //选中某个圣痕

        /// <summary>
        /// 剧情
        /// </summary>
        CE_TIMELINE_START,
        CE_TIMELINE_FINISH,

        /// <summary>
        /// 副本信息
        /// </summary>
        CE_COLLECTION_OBJECTS_COUNT_CHANGED,  // 采集物数量变化

        /// <summary>
        /// 分包下载
        /// </summary>
        CE_SCENE_NOT_DOWNLOAD,

        /// 打开 功能UI 界面
        CE_GENERIC_GOTO_SYS_WINDOW,         //打开系统界面的通用接口
        CE_OPEN_ARENA_WINDOW,               //比武场
        CE_OPEN_PEAK_ARENA_WINDOW,          //巅峰竞技
        CE_OPEN_FORGOTTEN_TOMB_WINDOW,      //遗忘墓地
        CE_OPEN_BATTLE_FIELD_WINDOW,        //竞技场
        CE_OPEN_BROKEN_MIRROR_WINDOW,       // 破境之道 
        CE_OPEN_MATERIAL_INSTANCE_WINDOW,   // 材料副本
        CE_OPEN_SECRET_DEFEND_WINDOW,       // 秘境守护（八荒秘境） 
        CE_OPEN_PIRATE_SHIP_WINDOW,         // 远洋海盗船 
        CE_OPEN_TRIAL_BOSS_WINDOW,          // 试炼BOSS 
        CE_OPEN_FAIRY_WINDOW,               // 仙灵山谷
        CE_OPEN_FAIRY_WINDOW_AND_USE_GOODS, // 仙灵山谷和使用道具
        CE_OPEN_FAIRY_WINDOW_AND_BUY_VIP,   // 仙灵山谷和提升VIP
        CE_OPEN_DEED_INHERIT_WINDOW,        // 契约传承 
        CE_OPEN_PURGATORY_WINDOW,           // 炼狱熔炉
        CE_OPEN_PERSONAL_BOSS_WINDOW,       // 个人BOSS
        CE_OPEN_VIP_GIFT_WINDOW,            // VIP4礼包推送
        CE_OPEN_PEAK_BOSS_WINDOW,           // 巅峰BOSS 

        /// <summary>
        /// 活动
        /// </summary>
        CE_ACTIVITY_DAILY,  // 日常活动开放列表的消息
        CE_ACTIVITY_STATE_CHANGED,  // 限时活动状态变化
        CE_OPERATING_ACTIVITY_INIT, // 运营活动初始化
        CE_OPERATING_ACTIVITY_OPEN,  // 运营活动开启
        CE_OPERATING_ACTIVITY_CLOSE,  // 运营活动关闭
        CE_UPDATE_SYS_SHOW_CHANGE,  // 刷新系统显示变化

        /// <summary>
        /// 在线奖励
        /// </summary>
        CE_ONLINE_REWARD_INFO_CHANGED,   // 在线奖励信息改变

        /// <summary>
        /// 转职
        /// </summary>
        CE_TRANSFER_TASK_FINISH,   // 完成转职任务
        CE_TRANSFER_FINISH_SHOW_SUC,  //转职成功界面展示完成


        CE_SHORT_CUT_TIPS_NO_GOODS,//快速穿戴的物品被删除


        CE_GOD_WARE_ANI_FINISH,//神器解锁动画完成

        CE_CHAT_RESPONSE_CLICK_TEXT_HREF, // 聊天触发超链接

        CE_BUNDLE_RES_LOAD_FAILED,  // bundle资源加载失败
        
        // 用于控制韩国版loading图加载
        CE_SERVERLIST_TO_CREATEACTOR_BEGIN, // 选服后到创角的loading开始
        CE_SERVERLIST_TO_CREATEACTOR_END, // 选服后到创角的loading结束

        CE_CREATEACTOR_TO_GAMESCENE_BEGIN, // 创角后到进入游戏场景的loading开始
        CE_CREATEACTOR_TO_GAMESCENE_END, // 创角后到进入游戏场景的loading结束
    }
}