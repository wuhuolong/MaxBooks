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
    public class xcuiUIWidgetHelpWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.UIWidgetHelp), L, translator, 0, 16, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateAndCheckProbabilityBtn", _m_CreateAndCheckProbabilityBtn);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateAndCheckRefundBtn", _m_CreateAndCheckRefundBtn);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateAndCheckMoneyBar", _m_CreateAndCheckMoneyBar);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateGoodsItem", _m_CreateGoodsItem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreateGoodsItemCache", _m_CreateGoodsItemCache);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGoodsIdByVGoodesId", _m_GetGoodsIdByVGoodesId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowDamageValue_Critic", _m_ShowDamageValue_Critic);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowBuffTip", _m_ShowBuffTip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowDamageEffect", _m_ShowDamageEffect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowBubbleDlg", _m_ShowBubbleDlg);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowDamageValue", _m_ShowDamageValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryShowDamageWordAnim", _m_TryShowDamageWordAnim);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetBlockNoticeDlg", _m_SetBlockNoticeDlg);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowNoticeDlg", _m_ShowNoticeDlg);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HideNoticeDlg", _m_HideNoticeDlg);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mTips", _g_get_mTips);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mLabelTips", _g_get_mLabelTips);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mTips", _s_set_mTips);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mLabelTips", _s_set_mLabelTips);
            
			XUtils.EndObjectRegister(typeof(xc.ui.UIWidgetHelp), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.UIWidgetHelp), L, __CreateInstance, 9, 6, 6);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMoneySpriteName", _m_GetMoneySpriteName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GiveTypeStringToUint", _m_GiveTypeStringToUint_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSpecialGIdByType", _m_GetSpecialGIdByType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetLargeNumberString", _m_GetLargeNumberString_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetLargeNumberString2", _m_GetLargeNumberString2_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetLargeNumberString3", _m_GetLargeNumberString3_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetLargeNumberString4", _m_GetLargeNumberString4_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ConvertToDecimal", _m_ConvertToDecimal_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.UIWidgetHelp));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "BlockOtherNoticeDlg", _g_get_BlockOtherNoticeDlg);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "mHasBlock", _g_get_mHasBlock);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "NoticeDlgAutoCancelTime", _g_get_NoticeDlgAutoCancelTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "NoticeDlgAutoOKTime", _g_get_NoticeDlgAutoOKTime);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "NoticeDlgAlignment", _g_get_NoticeDlgAlignment);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "ToggleValue", _g_get_ToggleValue);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "BlockOtherNoticeDlg", _s_set_BlockOtherNoticeDlg);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "mHasBlock", _s_set_mHasBlock);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "NoticeDlgAutoCancelTime", _s_set_NoticeDlgAutoCancelTime);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "NoticeDlgAutoOKTime", _s_set_NoticeDlgAutoOKTime);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "NoticeDlgAlignment", _s_set_NoticeDlgAlignment);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "ToggleValue", _s_set_ToggleValue);
            
			XUtils.EndClassRegister(typeof(xc.ui.UIWidgetHelp), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.UIWidgetHelp __cl_gen_ret = new xc.ui.UIWidgetHelp();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateAndCheckProbabilityBtn(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject parentGo = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string windName = LuaAPI.lua_tostring(L, 3);
                    float scale = (float)LuaAPI.lua_tonumber(L, 4);
                    string param1_str = LuaAPI.lua_tostring(L, 5);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateAndCheckProbabilityBtn( parentGo, windName, scale, param1_str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateAndCheckRefundBtn(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject parentGo = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string windName = LuaAPI.lua_tostring(L, 3);
                    float scale = (float)LuaAPI.lua_tonumber(L, 4);
                    string param1_str = LuaAPI.lua_tostring(L, 5);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateAndCheckRefundBtn( parentGo, windName, scale, param1_str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateAndCheckMoneyBar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject parentGo = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string windName = LuaAPI.lua_tostring(L, 3);
                    float scale = (float)LuaAPI.lua_tonumber(L, 4);
                    string param1_str = LuaAPI.lua_tostring(L, 5);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateAndCheckMoneyBar( parentGo, windName, scale, param1_str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateGoodsItem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 7&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)) 
                {
                    UnityEngine.GameObject template = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    uint goodsID = LuaAPI.xlua_touint(L, 3);
                    ulong num = LuaAPI.lua_touint64(L, 4);
                    bool isShowTips = LuaAPI.lua_toboolean(L, 5);
                    bool isScale = LuaAPI.lua_toboolean(L, 6);
                    uint isBind = LuaAPI.xlua_touint(L, 7);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItem( template, goodsID, num, isShowTips, isScale, isBind );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.GameObject template = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    uint goodsID = LuaAPI.xlua_touint(L, 3);
                    ulong num = LuaAPI.lua_touint64(L, 4);
                    bool isShowTips = LuaAPI.lua_toboolean(L, 5);
                    bool isScale = LuaAPI.lua_toboolean(L, 6);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItem( template, goodsID, num, isShowTips, isScale );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.GameObject template = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    uint goodsID = LuaAPI.xlua_touint(L, 3);
                    ulong num = LuaAPI.lua_touint64(L, 4);
                    bool isShowTips = LuaAPI.lua_toboolean(L, 5);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItem( template, goodsID, num, isShowTips );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))) 
                {
                    UnityEngine.GameObject template = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    uint goodsID = LuaAPI.xlua_touint(L, 3);
                    ulong num = LuaAPI.lua_touint64(L, 4);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItem( template, goodsID, num );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 8&& translator.Assignable<UnityEngine.Transform>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    uint goodsID = LuaAPI.xlua_touint(L, 3);
                    ulong num = LuaAPI.lua_touint64(L, 4);
                    bool isShowTips = LuaAPI.lua_toboolean(L, 5);
                    bool isScale = LuaAPI.lua_toboolean(L, 6);
                    uint isBind = LuaAPI.xlua_touint(L, 7);
                    bool newInstace = LuaAPI.lua_toboolean(L, 8);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItem( parent, goodsID, num, isShowTips, isScale, isBind, newInstace );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& translator.Assignable<UnityEngine.Transform>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)) 
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    uint goodsID = LuaAPI.xlua_touint(L, 3);
                    ulong num = LuaAPI.lua_touint64(L, 4);
                    bool isShowTips = LuaAPI.lua_toboolean(L, 5);
                    bool isScale = LuaAPI.lua_toboolean(L, 6);
                    uint isBind = LuaAPI.xlua_touint(L, 7);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItem( parent, goodsID, num, isShowTips, isScale, isBind );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& translator.Assignable<UnityEngine.Transform>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    uint goodsID = LuaAPI.xlua_touint(L, 3);
                    ulong num = LuaAPI.lua_touint64(L, 4);
                    bool isShowTips = LuaAPI.lua_toboolean(L, 5);
                    bool isScale = LuaAPI.lua_toboolean(L, 6);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItem( parent, goodsID, num, isShowTips, isScale );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& translator.Assignable<UnityEngine.Transform>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    uint goodsID = LuaAPI.xlua_touint(L, 3);
                    ulong num = LuaAPI.lua_touint64(L, 4);
                    bool isShowTips = LuaAPI.lua_toboolean(L, 5);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItem( parent, goodsID, num, isShowTips );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.Transform>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) || LuaAPI.lua_isuint64(L, 4))) 
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    uint goodsID = LuaAPI.xlua_touint(L, 3);
                    ulong num = LuaAPI.lua_touint64(L, 4);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItem( parent, goodsID, num );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp.CreateGoodsItem!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateGoodsItemCache(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 9&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Transform>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) || LuaAPI.lua_isuint64(L, 6))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)) 
                {
                    UnityEngine.GameObject template = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string wnd_name = LuaAPI.lua_tostring(L, 3);
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    uint goodsID = LuaAPI.xlua_touint(L, 5);
                    ulong num = LuaAPI.lua_touint64(L, 6);
                    bool isShowTips = LuaAPI.lua_toboolean(L, 7);
                    bool isScale = LuaAPI.lua_toboolean(L, 8);
                    uint isBind = LuaAPI.xlua_touint(L, 9);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItemCache( template, wnd_name, parent, goodsID, num, isShowTips, isScale, isBind );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 8&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Transform>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) || LuaAPI.lua_isuint64(L, 6))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    UnityEngine.GameObject template = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string wnd_name = LuaAPI.lua_tostring(L, 3);
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    uint goodsID = LuaAPI.xlua_touint(L, 5);
                    ulong num = LuaAPI.lua_touint64(L, 6);
                    bool isShowTips = LuaAPI.lua_toboolean(L, 7);
                    bool isScale = LuaAPI.lua_toboolean(L, 8);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItemCache( template, wnd_name, parent, goodsID, num, isShowTips, isScale );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Transform>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) || LuaAPI.lua_isuint64(L, 6))&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    UnityEngine.GameObject template = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string wnd_name = LuaAPI.lua_tostring(L, 3);
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    uint goodsID = LuaAPI.xlua_touint(L, 5);
                    ulong num = LuaAPI.lua_touint64(L, 6);
                    bool isShowTips = LuaAPI.lua_toboolean(L, 7);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItemCache( template, wnd_name, parent, goodsID, num, isShowTips );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Transform>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) || LuaAPI.lua_isuint64(L, 6))) 
                {
                    UnityEngine.GameObject template = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string wnd_name = LuaAPI.lua_tostring(L, 3);
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    uint goodsID = LuaAPI.xlua_touint(L, 5);
                    ulong num = LuaAPI.lua_touint64(L, 6);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.CreateGoodsItemCache( template, wnd_name, parent, goodsID, num );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp.CreateGoodsItemCache!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGoodsIdByVGoodesId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint vGoodsId = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetGoodsIdByVGoodesId( vGoodsId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDamageValue_Critic(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int damageValue = LuaAPI.xlua_tointeger(L, 2);
                    float displayTimeScale = (float)LuaAPI.lua_tonumber(L, 3);
                    bool isLocalPlayer = LuaAPI.lua_toboolean(L, 4);
                    Actor actor = (Actor)translator.GetObject(L, 5, typeof(Actor));
                    UnityEngine.Vector3 attacker_world_pos;translator.Get(L, 6, out attacker_world_pos);
                    xc.FightEffectHelp.FightEffectType type;translator.Get(L, 7, out type);
                    
                    __cl_gen_to_be_invoked.ShowDamageValue_Critic( damageValue, displayTimeScale, isLocalPlayer, actor, attacker_world_pos, type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowBuffTip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string tip = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowBuffTip( tip );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDamageEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.FightEffectHelp.FightEffectType type;translator.Get(L, 2, out type);
                    long value = LuaAPI.lua_toint64(L, 3);
                    float displayTimeScale = (float)LuaAPI.lua_tonumber(L, 4);
                    Actor actor = (Actor)translator.GetObject(L, 5, typeof(Actor));
                    bool show_percent = LuaAPI.lua_toboolean(L, 6);
                    string push_str = LuaAPI.lua_tostring(L, 7);
                    
                    __cl_gen_to_be_invoked.ShowDamageEffect( type, value, displayTimeScale, actor, show_percent, push_str );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowBubbleDlg(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Transform target = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    string content = LuaAPI.lua_tostring(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowBubbleDlg( target, content );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowDamageValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int damageValue = LuaAPI.xlua_tointeger(L, 2);
                    float displayTimeScale = (float)LuaAPI.lua_tonumber(L, 3);
                    xc.EUnitType unitType;translator.Get(L, 4, out unitType);
                    bool isLocalPlayer = LuaAPI.lua_toboolean(L, 5);
                    Actor actor = (Actor)translator.GetObject(L, 6, typeof(Actor));
                    UnityEngine.Vector3 attacker_world_pos;translator.Get(L, 7, out attacker_world_pos);
                    xc.FightEffectHelp.FightEffectType type;translator.Get(L, 8, out type);
                    
                    __cl_gen_to_be_invoked.ShowDamageValue( damageValue, displayTimeScale, unitType, isLocalPlayer, actor, attacker_world_pos, type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryShowDamageWordAnim(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.FightEffectHelp.FightEffectType effect_type;translator.Get(L, 2, out effect_type);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryShowDamageWordAnim( effect_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBlockNoticeDlg(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool block = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetBlockNoticeDlg( block );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowNoticeDlg(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    string text = LuaAPI.lua_tostring(L, 2);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 3);
                    object ok_callback_param = translator.GetObject(L, 4, typeof(object));
                    
                    __cl_gen_to_be_invoked.ShowNoticeDlg( text, ok_callback, ok_callback_param );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 3)) 
                {
                    string text = LuaAPI.lua_tostring(L, 2);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowNoticeDlg( text, ok_callback );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string text = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowNoticeDlg( text );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 4)&& translator.Assignable<object>(L, 5)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string text = LuaAPI.lua_tostring(L, 3);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 4);
                    object ok_callback_param = translator.GetObject(L, 5, typeof(object));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, text, ok_callback, ok_callback_param );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 4)&& translator.Assignable<object>(L, 5)&& (LuaAPI.lua_isnil(L, 6) || LuaAPI.lua_type(L, 6) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string text = LuaAPI.lua_tostring(L, 3);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 4);
                    object ok_callback_param = translator.GetObject(L, 5, typeof(object));
                    string wnd_name = LuaAPI.lua_tostring(L, 6);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, text, ok_callback, ok_callback_param, wnd_name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 15&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)&& translator.Assignable<object>(L, 6)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7)&& translator.Assignable<object>(L, 8)&& (LuaAPI.lua_isnil(L, 9) || LuaAPI.lua_type(L, 9) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 10) || LuaAPI.lua_type(L, 10) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 11) || LuaAPI.lua_type(L, 11) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 12)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate>(L, 13)&& (LuaAPI.lua_isnil(L, 14) || LuaAPI.lua_type(L, 14) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OnClickToggleDelegate>(L, 15)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    object ok_callback_param = translator.GetObject(L, 6, typeof(object));
                    xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7);
                    object cancel_callback_param = translator.GetObject(L, 8, typeof(object));
                    string ok_btn_text = LuaAPI.lua_tostring(L, 9);
                    string cancel_btn_text = LuaAPI.lua_tostring(L, 10);
                    string toggle_text = LuaAPI.lua_tostring(L, 11);
                    bool toggle_isOn = LuaAPI.lua_toboolean(L, 12);
                    xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate ok_with_toggle_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate>(L, 13);
                    string wnd_name = LuaAPI.lua_tostring(L, 14);
                    xc.ui.ugui.UINoticeWindow.OnClickToggleDelegate on_click_toggle_delegate = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OnClickToggleDelegate>(L, 15);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback, ok_callback_param, cancel_callback, cancel_callback_param, ok_btn_text, cancel_btn_text, toggle_text, toggle_isOn, ok_with_toggle_callback, wnd_name, on_click_toggle_delegate );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 14&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)&& translator.Assignable<object>(L, 6)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7)&& translator.Assignable<object>(L, 8)&& (LuaAPI.lua_isnil(L, 9) || LuaAPI.lua_type(L, 9) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 10) || LuaAPI.lua_type(L, 10) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 11) || LuaAPI.lua_type(L, 11) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 12)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate>(L, 13)&& (LuaAPI.lua_isnil(L, 14) || LuaAPI.lua_type(L, 14) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    object ok_callback_param = translator.GetObject(L, 6, typeof(object));
                    xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7);
                    object cancel_callback_param = translator.GetObject(L, 8, typeof(object));
                    string ok_btn_text = LuaAPI.lua_tostring(L, 9);
                    string cancel_btn_text = LuaAPI.lua_tostring(L, 10);
                    string toggle_text = LuaAPI.lua_tostring(L, 11);
                    bool toggle_isOn = LuaAPI.lua_toboolean(L, 12);
                    xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate ok_with_toggle_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate>(L, 13);
                    string wnd_name = LuaAPI.lua_tostring(L, 14);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback, ok_callback_param, cancel_callback, cancel_callback_param, ok_btn_text, cancel_btn_text, toggle_text, toggle_isOn, ok_with_toggle_callback, wnd_name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 13&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)&& translator.Assignable<object>(L, 6)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7)&& translator.Assignable<object>(L, 8)&& (LuaAPI.lua_isnil(L, 9) || LuaAPI.lua_type(L, 9) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 10) || LuaAPI.lua_type(L, 10) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 11) || LuaAPI.lua_type(L, 11) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 12)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate>(L, 13)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    object ok_callback_param = translator.GetObject(L, 6, typeof(object));
                    xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7);
                    object cancel_callback_param = translator.GetObject(L, 8, typeof(object));
                    string ok_btn_text = LuaAPI.lua_tostring(L, 9);
                    string cancel_btn_text = LuaAPI.lua_tostring(L, 10);
                    string toggle_text = LuaAPI.lua_tostring(L, 11);
                    bool toggle_isOn = LuaAPI.lua_toboolean(L, 12);
                    xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate ok_with_toggle_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate>(L, 13);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback, ok_callback_param, cancel_callback, cancel_callback_param, ok_btn_text, cancel_btn_text, toggle_text, toggle_isOn, ok_with_toggle_callback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 12&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)&& translator.Assignable<object>(L, 6)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7)&& translator.Assignable<object>(L, 8)&& (LuaAPI.lua_isnil(L, 9) || LuaAPI.lua_type(L, 9) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 10) || LuaAPI.lua_type(L, 10) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 11) || LuaAPI.lua_type(L, 11) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 12)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    object ok_callback_param = translator.GetObject(L, 6, typeof(object));
                    xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7);
                    object cancel_callback_param = translator.GetObject(L, 8, typeof(object));
                    string ok_btn_text = LuaAPI.lua_tostring(L, 9);
                    string cancel_btn_text = LuaAPI.lua_tostring(L, 10);
                    string toggle_text = LuaAPI.lua_tostring(L, 11);
                    bool toggle_isOn = LuaAPI.lua_toboolean(L, 12);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback, ok_callback_param, cancel_callback, cancel_callback_param, ok_btn_text, cancel_btn_text, toggle_text, toggle_isOn );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 11&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)&& translator.Assignable<object>(L, 6)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7)&& translator.Assignable<object>(L, 8)&& (LuaAPI.lua_isnil(L, 9) || LuaAPI.lua_type(L, 9) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 10) || LuaAPI.lua_type(L, 10) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 11) || LuaAPI.lua_type(L, 11) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    object ok_callback_param = translator.GetObject(L, 6, typeof(object));
                    xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7);
                    object cancel_callback_param = translator.GetObject(L, 8, typeof(object));
                    string ok_btn_text = LuaAPI.lua_tostring(L, 9);
                    string cancel_btn_text = LuaAPI.lua_tostring(L, 10);
                    string toggle_text = LuaAPI.lua_tostring(L, 11);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback, ok_callback_param, cancel_callback, cancel_callback_param, ok_btn_text, cancel_btn_text, toggle_text );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 10&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)&& translator.Assignable<object>(L, 6)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7)&& translator.Assignable<object>(L, 8)&& (LuaAPI.lua_isnil(L, 9) || LuaAPI.lua_type(L, 9) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 10) || LuaAPI.lua_type(L, 10) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    object ok_callback_param = translator.GetObject(L, 6, typeof(object));
                    xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7);
                    object cancel_callback_param = translator.GetObject(L, 8, typeof(object));
                    string ok_btn_text = LuaAPI.lua_tostring(L, 9);
                    string cancel_btn_text = LuaAPI.lua_tostring(L, 10);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback, ok_callback_param, cancel_callback, cancel_callback_param, ok_btn_text, cancel_btn_text );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 9&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)&& translator.Assignable<object>(L, 6)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7)&& translator.Assignable<object>(L, 8)&& (LuaAPI.lua_isnil(L, 9) || LuaAPI.lua_type(L, 9) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    object ok_callback_param = translator.GetObject(L, 6, typeof(object));
                    xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7);
                    object cancel_callback_param = translator.GetObject(L, 8, typeof(object));
                    string ok_btn_text = LuaAPI.lua_tostring(L, 9);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback, ok_callback_param, cancel_callback, cancel_callback_param, ok_btn_text );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 8&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)&& translator.Assignable<object>(L, 6)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7)&& translator.Assignable<object>(L, 8)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    object ok_callback_param = translator.GetObject(L, 6, typeof(object));
                    xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7);
                    object cancel_callback_param = translator.GetObject(L, 8, typeof(object));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback, ok_callback_param, cancel_callback, cancel_callback_param );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 7&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)&& translator.Assignable<object>(L, 6)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    object ok_callback_param = translator.GetObject(L, 6, typeof(object));
                    xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate>(L, 7);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback, ok_callback_param, cancel_callback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)&& translator.Assignable<object>(L, 6)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    object ok_callback_param = translator.GetObject(L, 6, typeof(object));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback, ok_callback_param );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = translator.GetDelegate<xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate>(L, 5);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content, ok_callback );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    string content = LuaAPI.lua_tostring(L, 4);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title, content );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    string title = LuaAPI.lua_tostring(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type, title );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<xc.ui.ugui.UINoticeWindow.EWindowType>(L, 2)) 
                {
                    xc.ui.ugui.UINoticeWindow.EWindowType window_type;translator.Get(L, 2, out window_type);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg( window_type );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1) 
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ShowNoticeDlg(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp.ShowNoticeDlg!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideNoticeDlg(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string wnd_name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.HideNoticeDlg( wnd_name );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.HideNoticeDlg(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp.HideNoticeDlg!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMoneySpriteName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    uint moneyType = LuaAPI.xlua_touint(L, 1);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.GetMoneySpriteName( moneyType );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GiveTypeStringToUint_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string type = LuaAPI.lua_tostring(L, 1);
                    
                        uint __cl_gen_ret = xc.ui.UIWidgetHelp.GiveTypeStringToUint( type );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSpecialGIdByType_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint type = LuaAPI.xlua_touint(L, 1);
                    uint defaultGId = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = xc.ui.UIWidgetHelp.GetSpecialGIdByType( type, defaultGId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string type = LuaAPI.lua_tostring(L, 1);
                    uint defaultGId = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = xc.ui.UIWidgetHelp.GetSpecialGIdByType( type, defaultGId );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp.GetSpecialGIdByType!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLargeNumberString_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    ulong number = LuaAPI.lua_touint64(L, 1);
                    uint decimalPlaces = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.GetLargeNumberString( number, decimalPlaces );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong number = LuaAPI.lua_touint64(L, 1);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.GetLargeNumberString( number );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp.GetLargeNumberString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLargeNumberString2_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    ulong number = LuaAPI.lua_touint64(L, 1);
                    uint decimalPlaces = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.GetLargeNumberString2( number, decimalPlaces );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong number = LuaAPI.lua_touint64(L, 1);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.GetLargeNumberString2( number );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp.GetLargeNumberString2!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLargeNumberString3_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    ulong number = LuaAPI.lua_touint64(L, 1);
                    uint decimalPlaces = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.GetLargeNumberString3( number, decimalPlaces );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong number = LuaAPI.lua_touint64(L, 1);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.GetLargeNumberString3( number );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp.GetLargeNumberString3!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLargeNumberString4_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    ulong number = LuaAPI.lua_touint64(L, 1);
                    uint decimalPlaces = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.GetLargeNumberString4( number, decimalPlaces );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong number = LuaAPI.lua_touint64(L, 1);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.GetLargeNumberString4( number );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp.GetLargeNumberString4!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConvertToDecimal_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    uint decimalPlaces = LuaAPI.xlua_touint(L, 2);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.ConvertToDecimal( str, decimalPlaces );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.ui.UIWidgetHelp.ConvertToDecimal( str );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIWidgetHelp.ConvertToDecimal!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BlockOtherNoticeDlg(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.ui.UIWidgetHelp.BlockOtherNoticeDlg);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mLabelTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mLabelTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mHasBlock(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.ui.UIWidgetHelp.mHasBlock);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NoticeDlgAutoCancelTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, xc.ui.UIWidgetHelp.NoticeDlgAutoCancelTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NoticeDlgAutoOKTime(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, xc.ui.UIWidgetHelp.NoticeDlgAutoOKTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NoticeDlgAlignment(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.PushUnityEngineTextAnchor(L, xc.ui.UIWidgetHelp.NoticeDlgAlignment);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ToggleValue(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.ui.UIWidgetHelp.ToggleValue);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BlockOtherNoticeDlg(RealStatePtr L)
        {
            
            try {
			    xc.ui.UIWidgetHelp.BlockOtherNoticeDlg = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mTips = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mLabelTips(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIWidgetHelp __cl_gen_to_be_invoked = (xc.ui.UIWidgetHelp)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mLabelTips = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mHasBlock(RealStatePtr L)
        {
            
            try {
			    xc.ui.UIWidgetHelp.mHasBlock = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NoticeDlgAutoCancelTime(RealStatePtr L)
        {
            
            try {
			    xc.ui.UIWidgetHelp.NoticeDlgAutoCancelTime = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NoticeDlgAutoOKTime(RealStatePtr L)
        {
            
            try {
			    xc.ui.UIWidgetHelp.NoticeDlgAutoOKTime = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NoticeDlgAlignment(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			UnityEngine.TextAnchor __cl_gen_value;translator.Get(L, 1, out __cl_gen_value);
				xc.ui.UIWidgetHelp.NoticeDlgAlignment = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ToggleValue(RealStatePtr L)
        {
            
            try {
			    xc.ui.UIWidgetHelp.ToggleValue = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
