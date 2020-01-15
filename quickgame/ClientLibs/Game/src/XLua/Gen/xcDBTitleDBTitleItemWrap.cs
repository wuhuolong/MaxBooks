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
    public class xcDBTitleDBTitleItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBTitle.DBTitleItem), L, translator, 0, 0, 14, 14);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Quality", _g_get_Quality);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SortId", _g_get_SortId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PageType", _g_get_PageType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Type", _g_get_Type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IgnoreNewTitle", _g_get_IgnoreNewTitle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Time", _g_get_Time);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Icon", _g_get_Icon);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EffectId", _g_get_EffectId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GetCondition", _g_get_GetCondition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TimeDesc", _g_get_TimeDesc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CollectAttr", _g_get_CollectAttr);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WearAttr", _g_get_WearAttr);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Quality", _s_set_Quality);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SortId", _s_set_SortId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PageType", _s_set_PageType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Type", _s_set_Type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IgnoreNewTitle", _s_set_IgnoreNewTitle);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Time", _s_set_Time);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Icon", _s_set_Icon);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EffectId", _s_set_EffectId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GetCondition", _s_set_GetCondition);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TimeDesc", _s_set_TimeDesc);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CollectAttr", _s_set_CollectAttr);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WearAttr", _s_set_WearAttr);
            
			XUtils.EndObjectRegister(typeof(xc.DBTitle.DBTitleItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBTitle.DBTitleItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBTitle.DBTitleItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBTitle.DBTitleItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBTitle.DBTitleItem __cl_gen_ret = new xc.DBTitle.DBTitleItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBTitle.DBTitleItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Quality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Quality);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SortId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PageType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PageType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreNewTitle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IgnoreNewTitle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Icon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Icon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EffectId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.EffectId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GetCondition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.GetCondition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TimeDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.TimeDesc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CollectAttr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CollectAttr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WearAttr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.WearAttr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Quality(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Quality = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SortId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SortId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PageType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PageType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Type = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IgnoreNewTitle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IgnoreNewTitle = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Time = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Icon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Icon = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EffectId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EffectId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GetCondition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GetCondition = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TimeDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TimeDesc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CollectAttr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CollectAttr = (System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WearAttr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBTitle.DBTitleItem __cl_gen_to_be_invoked = (xc.DBTitle.DBTitleItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WearAttr = (System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
