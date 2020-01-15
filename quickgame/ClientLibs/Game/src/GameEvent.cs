namespace xc{ public class GameEvent{

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%
//%% 源文件: 0K客户端切换游戏状态事件常量.xlsx []
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%

public const ushort GE_DISCONNECT = 1; //网络断开
public const ushort GE_SWITCH_PLAYING_TEST = 2; //单机测试状态
public const ushort GE_SWITCH_INSTANCE = 3; //切换到单人副本状态
public const ushort GE_SWITCH_WILD_INSTANCE = 4; //切换到野外状态
public const ushort GE_SWITCH_GUILD_BOSS_INSTANCE = 5; //切换到帮派BOSS状态
public const ushort GE_SWITCH_DEAD_SPACE_INSTANCE = 6; //切换到破碎死域状态
public const ushort GE_SWITCH_TRIAL_BOSS_INSTANCE = 7; //切换到试炼BOSS状态
public const ushort GE_SWITCH_CORSAIR_INSTANCE = 8; //切换到远洋海盗船状态
public const ushort GE_SWITCH_FAIRY_VALLEY_INSTANCE = 9; //切换到仙灵山谷状态
public const ushort GE_SWITCH_WORSHIP_MEETING_INSTANCE = 10; //切换到剑域盛会状态
public const ushort GE_SWITCH_FORGOTTEN_TOMB_INSTANCE = 11; //切换到遗忘墓地状态
public const ushort GE_SWITCH_WROLD_BOSS_EXPERIENCE_INSTANCE = 12; //切换到世界BOSS体验状态
public const ushort GE_SWITCH_GUILD_LEAGUE_INSTANCE = 13; //切换到帮派联赛状态
public const ushort GE_SWITCH_DRAGON_FOREST_INSTANCE = 14; //切换到御龙林状态
public const ushort GE_SWITCH_ARENA_INSTANCE = 15; //切换到比武场状态
public const ushort GE_SWITCH_SECRET_DEFEND_INSTANCE = 16; //切换到秘境守护状态
public const ushort GE_SWITCH_GUILD_MANOR_INSTANCE = 17; //切换到帮派领地状态
public const ushort GE_SWITCH_PERSONAL_BOSS_INSTANCE = 18; //切换到个人BOSS状态
public const ushort GE_SWITCH_PURGATORY_INSTANCE = 19; //切换到炼狱熔炉状态
public const ushort GE_SWITCH_MATERIAL_INSTANCE = 20; //切换到材料副本状态
public const ushort GE_SWITCH_BATTLE_FIELD_INSTANCE = 21; //切换到竞技场副本状态
public const ushort GE_SWITCH_SHURA_INSTANCE = 22; //切换到修罗战场副本状态
public const ushort GE_SWITCH_BROKEN_MIRROR_INSTANCE = 23; //切换到破境之道副本状态
public const ushort GE_SWITCH_CONTRACT_INHERIT_INSTANCE = 24; //切换到契约副本状态
public const ushort GE_SWITCH_WROLD_BOSS_FIRST_INSTANCE = 25; //切换到世界BOSS首个副本状态
public const ushort GE_SWITCH_WEDDING_INSTANCE = 26; //切换到婚宴副本状态
public const ushort GE_SWITCH_LOVE_INSTANCE = 27; //切换到情缘副本状态
public const ushort GE_SWITCH_DEVIL_COME_INSTANCE = 28; //切换到魔王降临副本状态
public const ushort GE_SWITCH_SERVER_BOSS_INSTANCE = 29; //切换到跨服BOSS副本状态
public const ushort GE_SWITCH_PEAK_BOSS_INSTANCE = 30; //切换到巅峰BOSS副本状态
public const ushort GE_SWITCH_PEAK_ARENA_INSTANCE = 31; //切换到巅峰对决副本状态
public const ushort GE_SWITCH_SPAN_GUILD_WAR_INSTANCE = 32; //切换到跨服帮战状态
public const ushort GE_SWITCH_PEAK_3P = 33; //切换到巅峰竞技状态
public const ushort GE_SWITCH_BOSS_BRAWL = 34; //切换到BOSS乱斗
public const ushort GE_SWITCH_EVIL_TOWER_INSTANCE = 35; //切换到封魔塔副本状态
public const ushort GE_SWITCH_CASTLE_CRASH_INSTANCE = 36; //切换到攻城战副本状态
public const ushort GE_SWITCH_FAIRY_MAUSOLEUM_INSTANCE = 37; //切换到五帝仙陵副本状态
public const ushort GE_SWITCH_GOD_DEMON_BATTLE_INSTANCE = 38; //切换到神魔对决副本状态
public const ushort GE_SWITCH_MAGIC_WORLD_INSTANCE = 39; //切换到魔界夹缝副本状态
public const ushort GE_SWITCH_GUILD_HOLY_BEAST_AREA_INSTANCE = 40; //切换到圣兽之域副本状态
public const ushort GE_SWITCH_FORSAKEN_VALLEY_INSTANCE = 41; //切换到遗忘战谷副本状态
public const ushort GE_INSTANCE_START = 101; //
public const ushort GE_ENTER_CAVE = 102; //
public const ushort GE_LEVEL_LOADED = 103; //
public const ushort GE_RES_LOADED = 104; //
public const ushort GE_STEP_TRIGGER = 105; //到达Step触发点
public const ushort GE_LEVEL_TRIGGER = 106; //到达Level触发点
public const ushort GE_STEP_COMPLETED = 107; //Step完成
public const ushort GE_STEP_WALK_WAIT = 108; //Step完成但是有血瓶
public const ushort GE_WALK_WAIT_FINISH = 109; //捡完了血瓶或者时间到
public const ushort GE_INSTANCE_COMPLETED = 110; //副本完成
public const ushort GE_INSTANCE_PAUSE = 111; //副本暂停
public const ushort GE_INSTANCE_WAIT = 112; //进入单人副本时等待用户输入
public const ushort GE_INSTANCE_RESUME = 113; //副本开始
public const ushort GE_INSTANCE_EXIT = 114; //退出副本
public const ushort GE_ROUND_COMPLETED = 115; //
public const ushort GE_NEW_VERSION = 116; //
public const ushort GE_UPLOAD_FINISHED = 117; //
public const ushort GE_VERSION_CHECKED = 118; //
public const ushort GE_ASSET_DOWNLOADED = 119; //
public const ushort GE_DB_LOADED = 120; //
public const ushort GE_INITED_MANAGERS = 121; //
public const ushort GE_LOGINED_PLATFORM = 122; //
public const ushort GE_RESET = 123; //内部事件，用于父状态切换走时，子状态恢复到默认状态
public const ushort GE_CHANGE_ROLE = 124; //更换角色
public const ushort GE_CHANGE_ROLE_FINISH = 125; //更换角色完成
}}
