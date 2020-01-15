//------------------------------------------------------------------------------
// File : DBRegister.cs
// Desc : 注册所有需要缓存的表格
// Author : raorui
// Date : 2016.9.13
//------------------------------------------------------------------------------
using System;
namespace xc
{
    public class DBRegister
    {
        public static void RegisterAllDB()
        {
            // sqlite读取的表------------------------------------------------------------------------------
            // 中文字符索引表
            DBManager.GetInstance().RegisterDB(new DBCharIndex(GlobalConfig.DBFile, DBManager.CharIndexTable));
            
            // 提示和错误码
            DBManager.GetInstance().RegisterDB(new DBNotice(GlobalConfig.DBFile, "data_notice"));
            DBManager.GetInstance().RegisterDB(new DBErrorCode(GlobalConfig.DBFile, "error_code"));

            // 平台相关
            DBManager.GetInstance().RegisterDB(new DBSDKFilter(GlobalConfig.DBFile, "sdk_filter")); // Q渠道标识.xlsx
            DBManager.GetInstance().RegisterDB(new DBServerType(GlobalConfig.DBFile, "server_type")); // K控制服标识.xlsx
            DBManager.GetInstance().RegisterDB(new DBIOSDevice(GlobalConfig.DBFile, "data_ios_devices")); // IOS机型.xlsx

            DBManager.GetInstance().RegisterDB(new DBCurrencyInfo(GlobalConfig.DBFile, "data_currency_info")); //货币信息
            DBManager.GetInstance().RegisterDB(new DBCurrencyPanel(GlobalConfig.DBFile, "data_currency_window_display")); //货币信息

            //概率按钮
            DBManager.GetInstance().RegisterDB(new DBProbabilityBtn(GlobalConfig.DBFile, "data_probability_btn"));

            //七日退款按钮
            if (Const.Region == RegionType.KOREA)
                DBManager.GetInstance().RegisterDB(new DBRefundBtn(GlobalConfig.DBFile, "data_refund_btn"));

            // 角色相关
            DBManager.GetInstance().RegisterDB(new DBModel(GlobalConfig.DBFile, "model"));
            DBManager.GetInstance().RegisterDB(new DBActor(GlobalConfig.DBFile, "data_actor")); //J角色.xlsx
            DBManager.GetInstance().RegisterDB(new DBVocationInfo(GlobalConfig.DBFile, "vocation_info"));//Z职业.xlsx
            DBManager.GetInstance().RegisterDB(new DBLevelExp(GlobalConfig.DBFile,"data_lv_exp"));
            DBManager.GetInstance().RegisterDB(new DBVocationMountInfo(GlobalConfig.DBFile, "data_vocation_mount_info"));//Z职业.xlsx
            DBManager.GetInstance().RegisterDB(new DBShemale(GlobalConfig.DBFile, "data_shemale"));

            // UI管理
            DBManager.GetInstance().RegisterDB(new DBUIManager(GlobalConfig.DBFile, "data_ui_manager"));

            // 新手引导、系统开放
            DBManager.GetInstance().RegisterDB(new DBGuide(GlobalConfig.DBFile, "guide"));
            DBManager.GetInstance().RegisterDB(new DBGuideStep(GlobalConfig.DBFile, "guide_step"));
            DBManager.GetInstance().RegisterDB(new DBSysConfig(GlobalConfig.DBFile, "sys_config"));
            DBManager.GetInstance().RegisterDB(new DBMainmapAnimation(GlobalConfig.DBFile, "mainmap_animation"));
            DBManager.GetInstance().RegisterDB(new DBGuideCopyBehavior(GlobalConfig.DBFile, "guide_copy_behavior"));

            // 系统预览
            DBManager.GetInstance().RegisterDB(new DBSysPreview(GlobalConfig.DBFile, "sys_preview"));

            //物品特效图标
            DBManager.GetInstance().RegisterDB(new DBGoodsEffectIcon(GlobalConfig.DBFile, "data_goods_effectIcon"));

            //职业区分图标
            DBManager.GetInstance().RegisterDB(new DBGoodsVocationIcon(GlobalConfig.DBFile, "data_goods_vocation_icon"));

            //小红点
            DBManager.GetInstance().RegisterDB(new DBRedPoint(GlobalConfig.DBFile, "data_red_point"));

            // 换装相关
            DBManager.GetInstance().RegisterDB(new DBAvatarDefault(GlobalConfig.DBFile, "avatar_default"));
            DBManager.GetInstance().RegisterDB(new DBAvatarPart(GlobalConfig.DBFile, "avatar_part"));
            DBManager.GetInstance().RegisterDB(new DBSuitEffect(GlobalConfig.DBFile, "suit_effect"));

            // 战斗相关
            DBManager.GetInstance().RegisterDB(new DBDamageEffect(GlobalConfig.DBFile, "data_damage_effect"));//S伤害效果.xlsx
            DBManager.GetInstance().RegisterDB(new DBSkillEffect(GlobalConfig.DBFile, "data_skill_effect"));
            DBManager.GetInstance().RegisterDB(new DBBattleState(GlobalConfig.DBFile, "data_battle_state"));
            DBManager.GetInstance().RegisterDB(new DBBuffSev(GlobalConfig.DBFile, "data_buff"));
            DBManager.GetInstance().RegisterDB(new DBBulletTrace(GlobalConfig.DBFile, "bullet_trace"));
            DBManager.GetInstance().RegisterDB(new DBBattleFx(GlobalConfig.DBFile, "data_battle_fx"));
            DBManager.GetInstance().RegisterDB(new DBSkillSev(GlobalConfig.DBFile, "data_skill"));
            DBManager.GetInstance().RegisterDB(new DBSkillSelection(GlobalConfig.DBFile, "skill_selection"));
            DBManager.GetInstance().RegisterDB(new DBSkillSlot(GlobalConfig.DBFile, "data_skill_slot")); //技能槽(一定要在技能总表前面读取)
            DBManager.GetInstance().RegisterDB(new DBDataAllSkill(GlobalConfig.DBFile, "data_all_skill"));  //技能总表
            DBManager.GetInstance().RegisterDB(new DBHang(GlobalConfig.DBFile, "data_hang"));  // 离线挂机
            DBManager.GetInstance().RegisterDB(new DBPassiveSkill(GlobalConfig.DBFile, "data_passive_skill")); //被动技能
            DBManager.GetInstance().RegisterDB(new DBFightEfffectLayout(GlobalConfig.DBFile, "data_fight_effect_layout")); //战斗飘字的类型
            

            //宠物表
            DBManager.GetInstance().RegisterDB(new DBPet(GlobalConfig.DBFile, "data_pet"));  //宠物表
            DBManager.GetInstance().RegisterDB(new DBPetStep(GlobalConfig.DBFile, "data_pet_step"));  //宠物表
            DBManager.GetInstance().RegisterDB(new DBPetFetter(GlobalConfig.DBFile, "data_pet_fetter"));  //宠物表
            DBManager.GetInstance().RegisterDB(new DBPetQual(GlobalConfig.DBFile, "data_pet_qual"));    //守护升品
            //帮会
            DBManager.GetInstance().RegisterDB(new DBGuildLv(GlobalConfig.DBFile, "data_guild_lv"));  //公会等级表
            DBManager.GetInstance().RegisterDB(new DBGuildDuty(GlobalConfig.DBFile, "data_guild_duty"));  //公会权限表
            DBManager.GetInstance().RegisterDB(new DBGuildSkill(GlobalConfig.DBFile, "data_guild_skill"));  //公会技能表
            DBManager.GetInstance().RegisterDB(new DBGuildBoss(GlobalConfig.DBFile, "data_guild_boss"));  //公会BOSS
            DBManager.GetInstance().RegisterDB(new DBGuildWareColorFilter(GlobalConfig.DBFile, "data_guild_warehouse_colorFilter"));  //帮派仓库品质筛选
            DBManager.GetInstance().RegisterDB(new DBGuildWareStepFilter(GlobalConfig.DBFile, "data_guild_warehouse_stepFilter"));  //帮派仓库阶数筛选
            DBManager.GetInstance().RegisterDB(new DBGuildTotem(GlobalConfig.DBFile, "data_guild_totem"));  //帮派图腾
            //成长
            DBManager.GetInstance().RegisterDB(new DBGrowLv(GlobalConfig.DBFile, "data_grow_lv"));
            DBManager.GetInstance().RegisterDB(new DBGrowSkin(GlobalConfig.DBFile, "data_grow_skin"));
            //语音
            DBManager.GetInstance().RegisterDB(new DBVoice(GlobalConfig.DBFile, "data_voice"));

            //圣痕
            DBManager.GetInstance().RegisterDB(new DBStigma(GlobalConfig.DBFile, "data_stigma"));
            DBManager.GetInstance().RegisterDB(new DBStigmaLv(GlobalConfig.DBFile, "data_stigma_lv"));

            // 活动和副本
            DBManager.GetInstance().RegisterDB(new DBInstance(GlobalConfig.DBFile, "instance"));
            DBManager.GetInstance().RegisterDB(new DBInstanceType(GlobalConfig.DBFile, "instance_type"));
            DBManager.GetInstance().RegisterDB(new DBInstanceTypeControl(GlobalConfig.DBFile, "instance_type_control"));
            DBManager.GetInstance().RegisterDB(new DBMonster(GlobalConfig.DBFile, "data_monster"));
            DBManager.GetInstance().RegisterDB(new DBMap(GlobalConfig.DBFile, "map"));
            DBManager.GetInstance().RegisterDB(new DBInstancePhase(GlobalConfig.DBFile, "instance_phase"));
            DBManager.GetInstance().RegisterDB(new DBDeadSpaceLv(GlobalConfig.DBFile, "data_dead_space_lv"));
            DBManager.GetInstance().RegisterDB(new DBTrialBoss(GlobalConfig.DBFile, "data_trial_boss"));  //试炼BOSS
            DBManager.GetInstance().RegisterDB(new DBTrialBossDifficulty(GlobalConfig.DBFile, "data_trial_boss_difficulty"));  //试炼BOSS

            //新装备读表
            DBManager.GetInstance().RegisterDB(new DBEquipSubAttr(GlobalConfig.DBFile, "data_equip_sub_attr"));
            DBManager.GetInstance().RegisterDB(new DBEquipMod(GlobalConfig.DBFile, "data_ep"));
            DBManager.GetInstance().RegisterDB(new DBEquipAttr(GlobalConfig.DBFile, "data_exotic"));
            DBManager.GetInstance().RegisterDB(new DBEquipPos(GlobalConfig.DBFile, "data_ep_pos")); //装备位置表
            DBManager.GetInstance().RegisterDB(new DBStrengthLv(GlobalConfig.DBFile, "data_strength_lv")); //装备强化等级表
            DBManager.GetInstance().RegisterDB(new DBStrengthAttr(GlobalConfig.DBFile, "data_strength_attr")); //装备强化属性表
            DBManager.GetInstance().RegisterDB(new DBAttrs(GlobalConfig.DBFile, "data_attrs"));
            DBManager.GetInstance().RegisterDB(new DBBattlePower(GlobalConfig.DBFile, "data_battle_pw"));
            DBManager.GetInstance().RegisterDB(new DBGemHole(GlobalConfig.DBFile, "data_gem_hole")); // 宝石孔表
            DBManager.GetInstance().RegisterDB(new DBGem(GlobalConfig.DBFile, "data_gem")); // 宝石表
            DBManager.GetInstance().RegisterDB(new DBSuit(GlobalConfig.DBFile, "data_suit")); // 套装信息表
            DBManager.GetInstance().RegisterDB(new DBSuitAttr(GlobalConfig.DBFile, "data_suit_attr")); // 套装属性表
            DBManager.GetInstance().RegisterDB(new DBBaptizeGroove(GlobalConfig.DBFile, "data_baptize_groove")); // 洗练槽表
            DBManager.GetInstance().RegisterDB(new DBBaptizeColorPool(GlobalConfig.DBFile, "data_baptize_color_pool")); // 洗练属性颜色库表
            DBManager.GetInstance().RegisterDB(new DBBaptizeAttrStandard(GlobalConfig.DBFile, "data_baptize_attr_standard")); // 洗练属性标准值表
            DBManager.GetInstance().RegisterDB(new DBBaptizeCost(GlobalConfig.DBFile, "data_baptize_cos")); // 洗练消耗表
            DBManager.GetInstance().RegisterDB(new DBEngrave(GlobalConfig.DBFile, "data_engrave")); // 铭刻表

            DBManager.GetInstance().RegisterDB(new DBSensitiveWords(GlobalConfig.DBFile, "sensitive_words"));
            if (Const.Region == RegionType.KOREA)   // 韩国版
                DBManager.GetInstance().RegisterDB(new DBSensitiveWordsPlayerName(GlobalConfig.DBFile, "sensitive_words_player_name"));

            // 对话 
            DBManager.GetInstance().RegisterDB(new DBDialog(GlobalConfig.DBFile, "dialog"));
            DBManager.GetInstance().RegisterDB(new DBDialogContent(GlobalConfig.DBFile, "dialog_content"));

            // 杂项
            DBManager.GetInstance().RegisterDB(new DBConstText(GlobalConfig.DBFile, "const_text"));//W文本.xlsx
            DBManager.GetInstance().RegisterDB(new DBGameLocalize(GlobalConfig.DBFile, "game_localize"));//W文本2.xlsx
            DBManager.GetInstance().RegisterDB(new DBPay(GlobalConfig.DBFile, "data_pay"));
            DBManager.GetInstance().RegisterDB(new DBPayProduct(GlobalConfig.DBFile, "data_pay_product"));

            DBManager.GetInstance().RegisterDB(new DBSystemToggle(GlobalConfig.DBFile, "system_toggle")); // X系统开关.xlsx
            DBManager.GetInstance().RegisterDB(new DBServerIdMaping(GlobalConfig.DBFile, "svr_id_to_no"));// F服务器ID与区号映射.xlsx
            DBManager.GetInstance().RegisterDB(new DBWorldBoss(GlobalConfig.DBFile, "data_world_boss"));    //世界BOSS
            DBManager.GetInstance().RegisterDB(new DBEvilValue(GlobalConfig.DBFile, "data_evil_value"));    //浊气值(南天圣地)
            DBManager.GetInstance().RegisterDB(new DBElementAreaEvilValue(GlobalConfig.DBFile, "data_element_area_evil_value"));//浊气值(元素禁地)
            DBManager.GetInstance().RegisterDB(new DBSpecialMon(GlobalConfig.DBFile, "data_special_mon"));    //特殊刷怪控制

            DBManager.GetInstance().RegisterDB(new DBReward(GlobalConfig.DBFile, "reward")); // 奖励表
            DBManager.GetInstance().RegisterDB(new DBUISoundCommon(GlobalConfig.DBFile, "ui_sound_common")); // UI声音通用资源表
            DBManager.GetInstance().RegisterDB(new DBHonor(GlobalConfig.DBFile, "data_honor"));    //头衔

            DBManager.GetInstance().RegisterDB(new DBMallType(GlobalConfig.DBFile, "data_mall_type"));  //商城
            DBManager.GetInstance().RegisterDB(new DBWidgetShield(GlobalConfig.DBFile, "ui_widget_shield"));  //ui 控件屏蔽显示表

            DBManager.GetInstance().RegisterDB(new DBRewardGroup(GlobalConfig.DBFile, "reward_group")); // 奖励组表
            DBManager.GetInstance().RegisterDB(new DBLvEfficiency(GlobalConfig.DBFile, "lv_efficiency")); // 等级效率表

            //市场
            DBManager.GetInstance().RegisterDB(new DBMarketFilter(GlobalConfig.DBFile, "data_market_filter"));
            DBManager.GetInstance().RegisterDB(new DBMarketQualityAndStarFilter(GlobalConfig.DBFile, "data_market_quality_and_star_filter"));
            DBManager.GetInstance().RegisterDB(new DBMarketQualityFilter(GlobalConfig.DBFile, "data_market_quality_filter"));
            DBManager.GetInstance().RegisterDB(new DBMarketStepFilter(GlobalConfig.DBFile, "data_market_stepFilter"));
            DBManager.GetInstance().RegisterDB(new DBMarketPasswordFilter(GlobalConfig.DBFile, "data_market_password_filter"));
            DBManager.GetInstance().RegisterDB(new DBGoodsName(GlobalConfig.GoodsNameDBFile, "goods_name_index")); //物品名字搜索表

            // 饰品
            DBManager.GetInstance().RegisterDB(new DBDecorate(GlobalConfig.DBFile, "data_decorate"));// 饰品表
            DBManager.GetInstance().RegisterDB(new DBDecoratePos(GlobalConfig.DBFile, "data_dec_pos"));// 饰品部位表

            //神兵
            DBManager.GetInstance().RegisterDB(new DBGodEquipGoods(GlobalConfig.DBFile, "data_god_equip_goods"));// 神兵器灵

            // 光武兵魂
            DBManager.GetInstance().RegisterDB(new DBLightWeaponSoul(GlobalConfig.DBFile, "data_light_weapon_soul"));// 光武兵魂

            //元素装备
            //DBManager.GetInstance().RegisterDB(new DBElementEquipGoods(GlobalConfig.DBFile, "data_element_ep"));// 元素装备

            // 套装
            DBManager.GetInstance().RegisterDB(new DBSuitRefine(GlobalConfig.DBFile, "data_suit_refine"));// 套装精炼

            // 资源
            DBManager.GetInstance().RegisterDB(new DBPreloadInfo(GlobalConfig.DBFile, "preload_info"));//Z预加载.xlsx

            //称号
            DBManager.GetInstance().RegisterDB(new DBTitle(GlobalConfig.DBFile, "data_title"));
            DBManager.GetInstance().RegisterDB(new DBTitleEffect(GlobalConfig.DBFile, "title_effect_icon")); // 称号特效表

            // 任务
            DBManager.GetInstance().RegisterDB(new DBTaskPriority(GlobalConfig.DBFile, "data_task_priority"));
            DBManager.GetInstance().RegisterDB(new DBTaskGuide(GlobalConfig.DBFile, "data_task_guide"));
            DBManager.GetInstance().RegisterDB(new DBTask(GlobalConfig.DBFile, "data_task"));

            //足迹
            DBManager.GetInstance().RegisterDB(new DBFootprint(GlobalConfig.DBFile, "data_footprint"));

            //buff飘字
            DBManager.GetInstance().RegisterDB(new DBFlyWord(GlobalConfig.DBFile, "data_fly_word"));

            //坐骑装备
            DBManager.GetInstance().RegisterDB(new DBMountEquipGoods(GlobalConfig.DBFile, "data_ride_equip"));

            //武魂
            DBManager.GetInstance().RegisterDB(new DBSoulHole(GlobalConfig.DBFile, "data_soul_hole"));

           
            //婚戒
            DBManager.GetInstance().RegisterDB(new DBWeddingRingGoods(GlobalConfig.DBFile, "data_ring"));
            

            // 物品使用后增加的属性
            DBManager.GetInstance().RegisterDB(new DBGoodsShowAttrs(GlobalConfig.DBFile, "data_goods_show_attrs"));

            // 法宝
            DBManager.GetInstance().RegisterDB(new DBMagic(GlobalConfig.DBFile, "data_magic_weapon"));// 法宝表
            DBManager.GetInstance().RegisterDB(new DBMagicEquip(GlobalConfig.DBFile, "data_magic_weapon_goods"));// 法宝装备表

            // 安卓马甲包控制
            DBManager.GetInstance().RegisterDB(new DBAndroidMajia(GlobalConfig.DBFile, "data_android_majia"));// 安卓马甲包控制
        }
    }
}

