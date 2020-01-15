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
    public class xcDBBaptizeGrooveDBBaptizeGrooveInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBBaptizeGroove.DBBaptizeGrooveInfo), L, translator, 0, 0, 4, 4);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Cost", _g_get_Cost);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttrAddition", _g_get_AttrAddition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaseRank", _g_get_BaseRank);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Cost", _s_set_Cost);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttrAddition", _s_set_AttrAddition);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BaseRank", _s_set_BaseRank);
            
			XUtils.EndObjectRegister(typeof(xc.DBBaptizeGroove.DBBaptizeGrooveInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBBaptizeGroove.DBBaptizeGrooveInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBBaptizeGroove.DBBaptizeGrooveInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBBaptizeGroove.DBBaptizeGrooveInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBBaptizeGroove.DBBaptizeGrooveInfo __cl_gen_ret = new xc.DBBaptizeGroove.DBBaptizeGrooveInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBBaptizeGroove.DBBaptizeGrooveInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeGroove.DBBaptizeGrooveInfo __cl_gen_to_be_invoked = (xc.DBBaptizeGroove.DBBaptizeGrooveInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Cost(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeGroove.DBBaptizeGrooveInfo __cl_gen_to_be_invoked = (xc.DBBaptizeGroove.DBBaptizeGrooveInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Cost);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttrAddition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeGroove.DBBaptizeGrooveInfo __cl_gen_to_be_invoked = (xc.DBBaptizeGroove.DBBaptizeGrooveInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.AttrAddition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseRank(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeGroove.DBBaptizeGrooveInfo __cl_gen_to_be_invoked = (xc.DBBaptizeGroove.DBBaptizeGrooveInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BaseRank);
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
			
                xc.DBBaptizeGroove.DBBaptizeGrooveInfo __cl_gen_to_be_invoked = (xc.DBBaptizeGroove.DBBaptizeGrooveInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Cost(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeGroove.DBBaptizeGrooveInfo __cl_gen_to_be_invoked = (xc.DBBaptizeGroove.DBBaptizeGrooveInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Cost = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttrAddition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeGroove.DBBaptizeGrooveInfo __cl_gen_to_be_invoked = (xc.DBBaptizeGroove.DBBaptizeGrooveInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttrAddition = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BaseRank(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeGroove.DBBaptizeGrooveInfo __cl_gen_to_be_invoked = (xc.DBBaptizeGroove.DBBaptizeGrooveInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BaseRank = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
