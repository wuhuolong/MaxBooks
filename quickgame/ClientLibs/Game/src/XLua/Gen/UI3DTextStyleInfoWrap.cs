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
    public class UI3DTextStyleInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UI3DText.StyleInfo), L, translator, 0, 0, 18, 18);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Offset", _g_get_Offset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HeadOffset", _g_get_HeadOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ScreenOffset", _g_get_ScreenOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Scale", _g_get_Scale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SpritName", _g_get_SpritName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SpriteWidth", _g_get_SpriteWidth);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SpriteHeight", _g_get_SpriteHeight);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TextPos", _g_get_TextPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TextColor", _g_get_TextColor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShowBg", _g_get_IsShowBg);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShowBgPreHead", _g_get_IsShowBgPreHead);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShowTeamIcon", _g_get_IsShowTeamIcon);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BgPreHeadOffset", _g_get_BgPreHeadOffset);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShowAffiliationPanel", _g_get_IsShowAffiliationPanel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShowBar", _g_get_IsShowBar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "HpBarName", _g_get_HpBarName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsEnemyRelation", _g_get_IsEnemyRelation);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LayoutIsVisiable", _g_get_LayoutIsVisiable);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Offset", _s_set_Offset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HeadOffset", _s_set_HeadOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ScreenOffset", _s_set_ScreenOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Scale", _s_set_Scale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SpritName", _s_set_SpritName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SpriteWidth", _s_set_SpriteWidth);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SpriteHeight", _s_set_SpriteHeight);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TextPos", _s_set_TextPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TextColor", _s_set_TextColor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowBg", _s_set_IsShowBg);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowBgPreHead", _s_set_IsShowBgPreHead);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowTeamIcon", _s_set_IsShowTeamIcon);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BgPreHeadOffset", _s_set_BgPreHeadOffset);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowAffiliationPanel", _s_set_IsShowAffiliationPanel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShowBar", _s_set_IsShowBar);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "HpBarName", _s_set_HpBarName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsEnemyRelation", _s_set_IsEnemyRelation);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LayoutIsVisiable", _s_set_LayoutIsVisiable);
            
			XUtils.EndObjectRegister(typeof(UI3DText.StyleInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UI3DText.StyleInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UI3DText.StyleInfo));
			
			
			XUtils.EndClassRegister(typeof(UI3DText.StyleInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UI3DText.StyleInfo __cl_gen_ret = new UI3DText.StyleInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UI3DText.StyleInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Offset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.Offset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HeadOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.HeadOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ScreenOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.ScreenOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Scale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.Scale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SpritName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.SpritName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SpriteWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.SpriteWidth);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SpriteHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.SpriteHeight);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TextPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.TextPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TextColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, __cl_gen_to_be_invoked.TextColor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShowBg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShowBg);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShowBgPreHead(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShowBgPreHead);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShowTeamIcon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShowTeamIcon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BgPreHeadOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.BgPreHeadOffset);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShowAffiliationPanel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShowAffiliationPanel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShowBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShowBar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HpBarName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.HpBarName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsEnemyRelation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsEnemyRelation);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LayoutIsVisiable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.LayoutIsVisiable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Offset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Offset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HeadOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.HeadOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ScreenOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ScreenOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Scale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Scale = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SpritName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SpritName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SpriteWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SpriteWidth = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SpriteHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SpriteHeight = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TextPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.TextPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TextColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Color __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.TextColor = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowBg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowBg = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowBgPreHead(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowBgPreHead = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowTeamIcon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowTeamIcon = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BgPreHeadOffset(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.BgPreHeadOffset = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowAffiliationPanel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowAffiliationPanel = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShowBar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShowBar = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HpBarName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.HpBarName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsEnemyRelation(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsEnemyRelation = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LayoutIsVisiable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UI3DText.StyleInfo __cl_gen_to_be_invoked = (UI3DText.StyleInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LayoutIsVisiable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
