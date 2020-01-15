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
    public class xcGoodsHelperColorQualityItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GoodsHelper.ColorQualityItem), L, translator, 0, 0, 5, 5);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isQuality", _g_get_isQuality);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "quality", _g_get_quality);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "whiteBkgColor", _g_get_whiteBkgColor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "blackBkgColor", _g_get_blackBkgColor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "qualityName", _g_get_qualityName);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isQuality", _s_set_isQuality);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "quality", _s_set_quality);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "whiteBkgColor", _s_set_whiteBkgColor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "blackBkgColor", _s_set_blackBkgColor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "qualityName", _s_set_qualityName);
            
			XUtils.EndObjectRegister(typeof(xc.GoodsHelper.ColorQualityItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GoodsHelper.ColorQualityItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GoodsHelper.ColorQualityItem));
			
			
			XUtils.EndClassRegister(typeof(xc.GoodsHelper.ColorQualityItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GoodsHelper.ColorQualityItem __cl_gen_ret = new xc.GoodsHelper.ColorQualityItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GoodsHelper.ColorQualityItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isQuality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsHelper.ColorQualityItem __cl_gen_to_be_invoked = (xc.GoodsHelper.ColorQualityItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isQuality);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_quality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsHelper.ColorQualityItem __cl_gen_to_be_invoked = (xc.GoodsHelper.ColorQualityItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.quality);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_whiteBkgColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsHelper.ColorQualityItem __cl_gen_to_be_invoked = (xc.GoodsHelper.ColorQualityItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.whiteBkgColor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_blackBkgColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsHelper.ColorQualityItem __cl_gen_to_be_invoked = (xc.GoodsHelper.ColorQualityItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.blackBkgColor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_qualityName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsHelper.ColorQualityItem __cl_gen_to_be_invoked = (xc.GoodsHelper.ColorQualityItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.qualityName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isQuality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsHelper.ColorQualityItem __cl_gen_to_be_invoked = (xc.GoodsHelper.ColorQualityItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isQuality = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_quality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsHelper.ColorQualityItem __cl_gen_to_be_invoked = (xc.GoodsHelper.ColorQualityItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.quality = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_whiteBkgColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsHelper.ColorQualityItem __cl_gen_to_be_invoked = (xc.GoodsHelper.ColorQualityItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.whiteBkgColor = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_blackBkgColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsHelper.ColorQualityItem __cl_gen_to_be_invoked = (xc.GoodsHelper.ColorQualityItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.blackBkgColor = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_qualityName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GoodsHelper.ColorQualityItem __cl_gen_to_be_invoked = (xc.GoodsHelper.ColorQualityItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.qualityName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
