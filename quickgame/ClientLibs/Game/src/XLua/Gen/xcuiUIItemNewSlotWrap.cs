#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class xcuiUIItemNewSlotWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.UIItemNewSlot), L, translator, 0, 41, 34, 35);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReplaceItemPrefab", _m_ReplaceItemPrefab);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetDoubleClick", _m_SetDoubleClick);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Dispose", _m_Dispose);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetNumLabelText", _m_SetNumLabelText);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CutBtnInit", _m_CutBtnInit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsSupportDown", _m_IsSupportDown);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GoodsTexturePixelPerfect", _m_GoodsTexturePixelPerfect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetShowCdImage", _m_SetShowCdImage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetGreyTexture", _m_SetGreyTexture);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DisableClick", _m_DisableClick);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetUI", _m_SetUI);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshExpireTime", _m_RefreshExpireTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshOverdueNotice", _m_RefreshOverdueNotice);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetColor", _m_SetColor);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "setItemInfo", _m_setItemInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "setItemInfoByNum", _m_setItemInfoByNum);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowEquippedIcon", _m_ShowEquippedIcon);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsShowEquipUp", _m_IsShowEquipUp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MatchMountEquip", _m_MatchMountEquip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MatchDecorate", _m_MatchDecorate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MatchMagicEquip", _m_MatchMagicEquip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MatchGoodsLightWeaponSoul", _m_MatchGoodsLightWeaponSoul);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshMatch", _m_RefreshMatch);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MatchEquip", _m_MatchEquip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsSelect", _m_IsSelect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowTips", _m_ShowTips);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPressCallBack", _m_OnPressCallBack);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshCost", _m_RefreshCost);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetGrey", _m_SetGrey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetTitleDesc", _m_SetTitleDesc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetBgImageVisiable", _m_SetBgImageVisiable);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetCircleBkgVisiable", _m_SetCircleBkgVisiable);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetEffectRootVisiable", _m_SetEffectRootVisiable);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetPlayerVocationAndLv", _m_SetPlayerVocationAndLv);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetCanNotUse", _m_SetCanNotUse);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetCheckImageActive", _m_SetCheckImageActive);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetShowExpJadeEffect", _m_SetShowExpJadeEffect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetNumActive", _m_SetNumActive);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetCustomFunc", _m_SetCustomFunc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowQualityEffect2", _m_ShowQualityEffect2);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SelectWid", _g_get_SelectWid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mShowType", _g_get_mShowType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mBindObj", _g_get_mBindObj);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mEquippedSprite", _g_get_mEquippedSprite);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mFrameSpr", _g_get_mFrameSpr);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mCircleBkg", _g_get_mCircleBkg);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedForceSetTipsPosition", _g_get_NeedForceSetTipsPosition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mCdtex", _g_get_mCdtex);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RealGameobj", _g_get_RealGameobj);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MainTexture", _g_get_MainTexture);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsCostItem", _g_get_IsCostItem);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsCostItemNoGrey", _g_get_IsCostItemNoGrey);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NeedNum", _g_get_NeedNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowNeedNum", _g_get_ShowNeedNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowZeroNum", _g_get_ShowZeroNum);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowCheckImage", _g_get_ShowCheckImage);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CanShowCircleBkg", _g_get_CanShowCircleBkg);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ItemInfo", _g_get_ItemInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mTextureMaterial", _g_get_mTextureMaterial);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_IsFrameSprShow", _g_get_m_IsFrameSprShow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_IsCircleBkgShow", _g_get_m_IsCircleBkgShow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_IsQualitySprShow", _g_get_m_IsQualitySprShow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mCustomFunc", _g_get_mCustomFunc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mFunc", _g_get_mFunc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mFunc1", _g_get_mFunc1);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mFunc2", _g_get_mFunc2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mCuntFunc", _g_get_mCuntFunc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShowTips", _g_get_IsShowTips);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ForceTipsPosition", _g_get_ForceTipsPosition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_CD", _g_get_is_CD);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetPanel", _g_get_TargetPanel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ClipPanel", _g_get_ClipPanel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GoodsItemPr", _g_get_GoodsItemPr);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "_mTypeParse", _g_get__mTypeParse);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SelectWid", _s_set_SelectWid);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mShowType", _s_set_mShowType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mBindObj", _s_set_mBindObj);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mEquippedSprite", _s_set_mEquippedSprite);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mFrameSpr", _s_set_mFrameSpr);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mCircleBkg", _s_set_mCircleBkg);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NeedForceSetTipsPosition", _s_set_NeedForceSetTipsPosition);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mCdtex", _s_set_mCdtex);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RealGameobj", _s_set_RealGameobj);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MainTexture", _s_set_MainTexture);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsCostItem", _s_set_IsCostItem);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsCostItemNoGrey", _s_set_IsCostItemNoGrey);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NeedNum", _s_set_NeedNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsBind", _s_set_IsBind);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowNeedNum", _s_set_ShowNeedNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowZeroNum", _s_set_ShowZeroNum);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowCheckImage", _s_set_ShowCheckImage);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CanShowCircleBkg", _s_set_CanShowCircleBkg);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ItemInfo", _s_set_ItemInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mTextureMaterial", _s_set_mTextureMaterial);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_IsFrameSprShow", _s_set_m_IsFrameSprShow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_IsCircleBkgShow", _s_set_m_IsCircleBkgShow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_IsQualitySprShow", _s_set_m_IsQualitySprShow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mCustomFunc", _s_set_mCustomFunc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mFunc", _s_set_mFunc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mFunc1", _s_set_mFunc1);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mFunc2", _s_set_mFunc2);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mCuntFunc", _s_set_mCuntFunc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowTips", _s_set_IsShowTips);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ForceTipsPosition", _s_set_ForceTipsPosition);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_CD", _s_set_is_CD);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TargetPanel", _s_set_TargetPanel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ClipPanel", _s_set_ClipPanel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GoodsItemPr", _s_set_GoodsItemPr);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "_mTypeParse", _s_set__mTypeParse);
            
			XUtils.EndObjectRegister(typeof(xc.ui.UIItemNewSlot), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.UIItemNewSlot), L, __CreateInstance, 8, 1, 1);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "InitEffectIconParam", _m_InitEffectIconParam_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Bind", _m_Bind_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReplaceItemPrefab_static", _m_ReplaceItemPrefab_static_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReplaceItemUseCache", _m_ReplaceItemUseCache_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateUIItemTypeParse", _m_CreateUIItemTypeParse_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsBetterEquip", _m_IsBetterEquip_xlua_st_);
            
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "GOODS_ID_EXP_JADE", xc.ui.UIItemNewSlot.GOODS_ID_EXP_JADE);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.UIItemNewSlot));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "m_is_load_effectIcon", _g_get_m_is_load_effectIcon);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "m_is_load_effectIcon", _s_set_m_is_load_effectIcon);
            
			XUtils.EndClassRegister(typeof(xc.ui.UIItemNewSlot), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.UIItemNewSlot __cl_gen_ret = new xc.ui.UIItemNewSlot();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIItemNewSlot constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitEffectIconParam_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.ui.UIItemNewSlot.InitEffectIconParam(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceItemPrefab(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool newInstace = LuaAPI.lua_toboolean(L, 2);
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = __cl_gen_to_be_invoked.ReplaceItemPrefab( newInstace );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1) 
                {
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = __cl_gen_to_be_invoked.ReplaceItemPrefab(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float scale = (float)LuaAPI.lua_tonumber(L, 2);
                    bool newInstance = LuaAPI.lua_toboolean(L, 3);
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = __cl_gen_to_be_invoked.ReplaceItemPrefab( scale, newInstance );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float scale = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = __cl_gen_to_be_invoked.ReplaceItemPrefab( scale );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.RectTransform>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.RectTransform rectTrans = (UnityEngine.RectTransform)translator.GetObject(L, 2, typeof(UnityEngine.RectTransform));
                    bool newInstance = LuaAPI.lua_toboolean(L, 3);
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = __cl_gen_to_be_invoked.ReplaceItemPrefab( rectTrans, newInstance );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.RectTransform>(L, 2)) 
                {
                    UnityEngine.RectTransform rectTrans = (UnityEngine.RectTransform)translator.GetObject(L, 2, typeof(UnityEngine.RectTransform));
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = __cl_gen_to_be_invoked.ReplaceItemPrefab( rectTrans );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIItemNewSlot.ReplaceItemPrefab!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDoubleClick(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& translator.Assignable<System.Action<xc.ui.UIItemNewSlot>>(L, 2)&& translator.Assignable<System.Action<xc.ui.UIItemNewSlot>>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    System.Action<xc.ui.UIItemNewSlot> doubleClickCallback = translator.GetDelegate<System.Action<xc.ui.UIItemNewSlot>>(L, 2);
                    System.Action<xc.ui.UIItemNewSlot> singleClickCallback = translator.GetDelegate<System.Action<xc.ui.UIItemNewSlot>>(L, 3);
                    bool useDoubleClick = LuaAPI.lua_toboolean(L, 4);
                    float delay = (float)LuaAPI.lua_tonumber(L, 5);
                    
                    __cl_gen_to_be_invoked.SetDoubleClick( doubleClickCallback, singleClickCallback, useDoubleClick, delay );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<System.Action<xc.ui.UIItemNewSlot>>(L, 2)&& translator.Assignable<System.Action<xc.ui.UIItemNewSlot>>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    System.Action<xc.ui.UIItemNewSlot> doubleClickCallback = translator.GetDelegate<System.Action<xc.ui.UIItemNewSlot>>(L, 2);
                    System.Action<xc.ui.UIItemNewSlot> singleClickCallback = translator.GetDelegate<System.Action<xc.ui.UIItemNewSlot>>(L, 3);
                    bool useDoubleClick = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.SetDoubleClick( doubleClickCallback, singleClickCallback, useDoubleClick );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIItemNewSlot.SetDoubleClick!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Bind_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<UnityEngine.Canvas>(L, 2)&& translator.Assignable<UnityEngine.RectTransform>(L, 3)) 
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UnityEngine.Canvas canvas = (UnityEngine.Canvas)translator.GetObject(L, 2, typeof(UnityEngine.Canvas));
                    UnityEngine.RectTransform clipPanel = (UnityEngine.RectTransform)translator.GetObject(L, 3, typeof(UnityEngine.RectTransform));
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = xc.ui.UIItemNewSlot.Bind( obj, canvas, clipPanel );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<UnityEngine.Canvas>(L, 2)) 
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UnityEngine.Canvas canvas = (UnityEngine.Canvas)translator.GetObject(L, 2, typeof(UnityEngine.Canvas));
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = xc.ui.UIItemNewSlot.Bind( obj, canvas );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.GameObject>(L, 1)) 
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = xc.ui.UIItemNewSlot.Bind( obj );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIItemNewSlot.Bind!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceItemPrefab_static_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<UnityEngine.Canvas>(L, 2)&& translator.Assignable<UnityEngine.RectTransform>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.GameObject re_obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UnityEngine.Canvas canvas = (UnityEngine.Canvas)translator.GetObject(L, 2, typeof(UnityEngine.Canvas));
                    UnityEngine.RectTransform clipPanel = (UnityEngine.RectTransform)translator.GetObject(L, 3, typeof(UnityEngine.RectTransform));
                    bool newInstace = LuaAPI.lua_toboolean(L, 4);
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = xc.ui.UIItemNewSlot.ReplaceItemPrefab_static( re_obj, canvas, clipPanel, newInstace );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<UnityEngine.Canvas>(L, 2)&& translator.Assignable<UnityEngine.RectTransform>(L, 3)) 
                {
                    UnityEngine.GameObject re_obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UnityEngine.Canvas canvas = (UnityEngine.Canvas)translator.GetObject(L, 2, typeof(UnityEngine.Canvas));
                    UnityEngine.RectTransform clipPanel = (UnityEngine.RectTransform)translator.GetObject(L, 3, typeof(UnityEngine.RectTransform));
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = xc.ui.UIItemNewSlot.ReplaceItemPrefab_static( re_obj, canvas, clipPanel );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<UnityEngine.Canvas>(L, 2)) 
                {
                    UnityEngine.GameObject re_obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UnityEngine.Canvas canvas = (UnityEngine.Canvas)translator.GetObject(L, 2, typeof(UnityEngine.Canvas));
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = xc.ui.UIItemNewSlot.ReplaceItemPrefab_static( re_obj, canvas );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.GameObject>(L, 1)) 
                {
                    UnityEngine.GameObject re_obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = xc.ui.UIItemNewSlot.ReplaceItemPrefab_static( re_obj );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIItemNewSlot.ReplaceItemPrefab_static!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceItemUseCache_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<xc.ui.ugui.UIBaseWindow>(L, 2)&& translator.Assignable<UnityEngine.Canvas>(L, 3)&& translator.Assignable<UnityEngine.RectTransform>(L, 4)) 
                {
                    UnityEngine.GameObject re_obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    xc.ui.ugui.UIBaseWindow wnd = (xc.ui.ugui.UIBaseWindow)translator.GetObject(L, 2, typeof(xc.ui.ugui.UIBaseWindow));
                    UnityEngine.Canvas canvas = (UnityEngine.Canvas)translator.GetObject(L, 3, typeof(UnityEngine.Canvas));
                    UnityEngine.RectTransform clipPanel = (UnityEngine.RectTransform)translator.GetObject(L, 4, typeof(UnityEngine.RectTransform));
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = xc.ui.UIItemNewSlot.ReplaceItemUseCache( re_obj, wnd, canvas, clipPanel );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<xc.ui.ugui.UIBaseWindow>(L, 2)&& translator.Assignable<UnityEngine.Canvas>(L, 3)) 
                {
                    UnityEngine.GameObject re_obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    xc.ui.ugui.UIBaseWindow wnd = (xc.ui.ugui.UIBaseWindow)translator.GetObject(L, 2, typeof(xc.ui.ugui.UIBaseWindow));
                    UnityEngine.Canvas canvas = (UnityEngine.Canvas)translator.GetObject(L, 3, typeof(UnityEngine.Canvas));
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = xc.ui.UIItemNewSlot.ReplaceItemUseCache( re_obj, wnd, canvas );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<xc.ui.ugui.UIBaseWindow>(L, 2)) 
                {
                    UnityEngine.GameObject re_obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    xc.ui.ugui.UIBaseWindow wnd = (xc.ui.ugui.UIBaseWindow)translator.GetObject(L, 2, typeof(xc.ui.ugui.UIBaseWindow));
                    
                        xc.ui.UIItemNewSlot __cl_gen_ret = xc.ui.UIItemNewSlot.ReplaceItemUseCache( re_obj, wnd );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIItemNewSlot.ReplaceItemUseCache!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNumLabelText(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isuint64(L, 2))) 
                {
                    ulong tx = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.SetNumLabelText( tx );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string tx = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetNumLabelText( tx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIItemNewSlot.SetNumLabelText!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CutBtnInit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ui.UIItemNewSlot.OnClickFunc2 func = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickFunc2>(L, 2);
                    
                    __cl_gen_to_be_invoked.CutBtnInit( func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSupportDown(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isSupport = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.IsSupportDown( isSupport );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoodsTexturePixelPerfect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.GoodsTexturePixelPerfect(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetShowCdImage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetShowCdImage( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGreyTexture(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool state = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetGreyTexture( state );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DisableClick(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.DisableClick(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUI(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetUI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshExpireTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RefreshExpireTime(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshOverdueNotice(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RefreshOverdueNotice(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetColor(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetColor( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setItemInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<xc.ui.UIItemNewSlot.TypeParse>(L, 3)) 
                {
                    uint goodsId = LuaAPI.xlua_touint(L, 2);
                    xc.ui.UIItemNewSlot.TypeParse parse;translator.Get(L, 3, out parse);
                    
                    __cl_gen_to_be_invoked.setItemInfo( goodsId, parse );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<xc.ui.UIItemNewSlot.TypeParse>(L, 4)) 
                {
                    uint goodsId = LuaAPI.xlua_touint(L, 2);
                    uint bind = LuaAPI.xlua_touint(L, 3);
                    xc.ui.UIItemNewSlot.TypeParse parse;translator.Get(L, 4, out parse);
                    
                    __cl_gen_to_be_invoked.setItemInfo( goodsId, bind, parse );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.Goods>(L, 2)&& translator.Assignable<xc.ui.UIItemNewSlot.TypeParse>(L, 3)) 
                {
                    xc.Goods itemInfo = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
                    xc.ui.UIItemNewSlot.TypeParse parse;translator.Get(L, 3, out parse);
                    
                    __cl_gen_to_be_invoked.setItemInfo( itemInfo, parse );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<xc.Goods>(L, 2)&& translator.Assignable<xc.ui.UIItemNewSlot.TypeParse>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    xc.Goods itemInfo = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
                    xc.ui.UIItemNewSlot.TypeParse parse;translator.Get(L, 3, out parse);
                    bool IsScale = LuaAPI.lua_toboolean(L, 4);
                    
                    __cl_gen_to_be_invoked.setItemInfo( itemInfo, parse, IsScale );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 6&& translator.Assignable<xc.Goods>(L, 2)&& translator.Assignable<xc.ui.UIItemNewSlot.TypeParse>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    xc.Goods itemInfo = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
                    xc.ui.UIItemNewSlot.TypeParse parse;translator.Get(L, 3, out parse);
                    uint needNum = LuaAPI.xlua_touint(L, 4);
                    string windowName = LuaAPI.lua_tostring(L, 5);
                    int maxDepth = LuaAPI.xlua_tointeger(L, 6);
                    
                    __cl_gen_to_be_invoked.setItemInfo( itemInfo, parse, needNum, windowName, maxDepth );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIItemNewSlot.setItemInfo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setItemInfoByNum(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint goodsId = LuaAPI.xlua_touint(L, 2);
                    ulong num = LuaAPI.lua_touint64(L, 3);
                    xc.ui.UIItemNewSlot.TypeParse parse;translator.Get(L, 4, out parse);
                    
                    __cl_gen_to_be_invoked.setItemInfoByNum( goodsId, num, parse );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowEquippedIcon(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool show = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowEquippedIcon( show );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateUIItemTypeParse_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int type = LuaAPI.xlua_tointeger(L, 1);
                    
                        xc.ui.UIItemNewSlot.TypeParse __cl_gen_ret = xc.ui.UIItemNewSlot.CreateUIItemTypeParse( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 0) 
                {
                    
                        xc.ui.UIItemNewSlot.TypeParse __cl_gen_ret = xc.ui.UIItemNewSlot.CreateUIItemTypeParse(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIItemNewSlot.CreateUIItemTypeParse!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsShowEquipUp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool show = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.IsShowEquipUp( show );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MatchMountEquip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsMountEquip mountEquip = (xc.GoodsMountEquip)translator.GetObject(L, 2, typeof(xc.GoodsMountEquip));
                    
                    __cl_gen_to_be_invoked.MatchMountEquip( mountEquip );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MatchDecorate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsDecorate decorate = (xc.GoodsDecorate)translator.GetObject(L, 2, typeof(xc.GoodsDecorate));
                    
                    __cl_gen_to_be_invoked.MatchDecorate( decorate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MatchMagicEquip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsMagicEquip magicEquip = (xc.GoodsMagicEquip)translator.GetObject(L, 2, typeof(xc.GoodsMagicEquip));
                    
                    __cl_gen_to_be_invoked.MatchMagicEquip( magicEquip );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MatchGoodsLightWeaponSoul(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsLightWeaponSoul LightWeaponSoul = (xc.GoodsLightWeaponSoul)translator.GetObject(L, 2, typeof(xc.GoodsLightWeaponSoul));
                    
                    __cl_gen_to_be_invoked.MatchGoodsLightWeaponSoul( LightWeaponSoul );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBetterEquip_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.GoodsEquip equip1 = (xc.GoodsEquip)translator.GetObject(L, 1, typeof(xc.GoodsEquip));
                    xc.GoodsEquip equip2 = (xc.GoodsEquip)translator.GetObject(L, 2, typeof(xc.GoodsEquip));
                    uint player_vocation = LuaAPI.xlua_touint(L, 3);
                    
                        bool __cl_gen_ret = xc.ui.UIItemNewSlot.IsBetterEquip( equip1, equip2, player_vocation );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshMatch(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.Goods>(L, 2)) 
                {
                    xc.Goods matchGoods = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
                    
                    __cl_gen_to_be_invoked.RefreshMatch( matchGoods );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.RefreshMatch(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIItemNewSlot.RefreshMatch!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MatchEquip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsEquip equip = (xc.GoodsEquip)translator.GetObject(L, 2, typeof(xc.GoodsEquip));
                    
                    __cl_gen_to_be_invoked.MatchEquip( equip );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSelect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool show = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.IsSelect( show );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowTips(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ShowTips(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPressCallBack(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object obj = translator.GetObject(L, 2, typeof(object));
                    
                    __cl_gen_to_be_invoked.OnPressCallBack( obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshCost(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RefreshCost(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGrey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_grey = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetGrey( is_grey );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTitleDesc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string title_desc = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetTitleDesc( title_desc );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBgImageVisiable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_visiable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetBgImageVisiable( is_visiable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCircleBkgVisiable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_visiable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetCircleBkgVisiable( is_visiable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEffectRootVisiable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_visiable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetEffectRootVisiable( is_visiable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPlayerVocationAndLv(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint vocation = LuaAPI.xlua_touint(L, 2);
                    uint player_lv = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.SetPlayerVocationAndLv( vocation, player_lv );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCanNotUse(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool canNotUse = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetCanNotUse( canNotUse );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCheckImageActive(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_active = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetCheckImageActive( is_active );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetShowExpJadeEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_active = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetShowExpJadeEffect( is_active );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNumActive(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_active = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetNumActive( is_active );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCustomFunc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ui.UIItemNewSlot.OnClickCustomFunc customFunc = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickCustomFunc>(L, 2);
                    
                    __cl_gen_to_be_invoked.SetCustomFunc( customFunc );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowQualityEffect2(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowQualityEffect2( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SelectWid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SelectWid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mShowType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.mShowType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mBindObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mBindObj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mEquippedSprite(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mEquippedSprite);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mFrameSpr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mFrameSpr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mCircleBkg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mCircleBkg);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedForceSetTipsPosition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NeedForceSetTipsPosition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mCdtex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mCdtex);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RealGameobj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.RealGameobj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MainTexture(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MainTexture);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCostItem(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsCostItem);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCostItemNoGrey(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsCostItemNoGrey);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NeedNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NeedNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowNeedNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShowNeedNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowZeroNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShowZeroNum);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowCheckImage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShowCheckImage);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CanShowCircleBkg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CanShowCircleBkg);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_is_load_effectIcon(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.ui.UIItemNewSlot.m_is_load_effectIcon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ItemInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ItemInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mTextureMaterial(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mTextureMaterial);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_IsFrameSprShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_IsFrameSprShow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_IsCircleBkgShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_IsCircleBkgShow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_IsQualitySprShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_IsQualitySprShow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mCustomFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mCustomFunc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mFunc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mFunc1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mFunc1);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mFunc2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mFunc2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mCuntFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mCuntFunc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShowTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShowTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ForceTipsPosition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ForceTipsPosition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_CD(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_CD);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetPanel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TargetPanel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ClipPanel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ClipPanel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GoodsItemPr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.GoodsItemPr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__mTypeParse(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked._mTypeParse);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SelectWid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SelectWid = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mShowType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mShowType = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mBindObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mBindObj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mEquippedSprite(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mEquippedSprite = (UnityEngine.UI.Image)translator.GetObject(L, 2, typeof(UnityEngine.UI.Image));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mFrameSpr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mFrameSpr = (UnityEngine.UI.Image)translator.GetObject(L, 2, typeof(UnityEngine.UI.Image));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mCircleBkg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mCircleBkg = (UnityEngine.UI.Image)translator.GetObject(L, 2, typeof(UnityEngine.UI.Image));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NeedForceSetTipsPosition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NeedForceSetTipsPosition = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mCdtex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mCdtex = (UnityEngine.UI.RawImage)translator.GetObject(L, 2, typeof(UnityEngine.UI.RawImage));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RealGameobj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RealGameobj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MainTexture(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MainTexture = (UnityEngine.UI.RawImage)translator.GetObject(L, 2, typeof(UnityEngine.UI.RawImage));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsCostItem(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsCostItem = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsCostItemNoGrey(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsCostItemNoGrey = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NeedNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NeedNum = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsBind(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsBind = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowNeedNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowNeedNum = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowZeroNum(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowZeroNum = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowCheckImage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowCheckImage = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CanShowCircleBkg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CanShowCircleBkg = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_is_load_effectIcon(RealStatePtr L)
        {
            
            try {
			    xc.ui.UIItemNewSlot.m_is_load_effectIcon = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ItemInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ItemInfo = (xc.Goods)translator.GetObject(L, 2, typeof(xc.Goods));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mTextureMaterial(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mTextureMaterial = (UnityEngine.Material)translator.GetObject(L, 2, typeof(UnityEngine.Material));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_IsFrameSprShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_IsFrameSprShow = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_IsCircleBkgShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_IsCircleBkgShow = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_IsQualitySprShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_IsQualitySprShow = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mCustomFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mCustomFunc = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickCustomFunc>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mFunc = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickFunc>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mFunc1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mFunc1 = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickFunc1>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mFunc2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mFunc2 = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickFunc2>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mCuntFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mCuntFunc = translator.GetDelegate<xc.ui.UIItemNewSlot.OnClickFunc2>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowTips = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ForceTipsPosition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ForceTipsPosition = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_CD(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_CD = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TargetPanel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TargetPanel = (UnityEngine.Canvas)translator.GetObject(L, 2, typeof(UnityEngine.Canvas));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ClipPanel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ClipPanel = (UnityEngine.RectTransform)translator.GetObject(L, 2, typeof(UnityEngine.RectTransform));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GoodsItemPr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GoodsItemPr = (SGameEngine.PrefabResource)translator.GetObject(L, 2, typeof(SGameEngine.PrefabResource));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__mTypeParse(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIItemNewSlot __cl_gen_to_be_invoked = (xc.ui.UIItemNewSlot)translator.FastGetCSObj(L, 1);
                xc.ui.UIItemNewSlot.TypeParse __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked._mTypeParse = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
