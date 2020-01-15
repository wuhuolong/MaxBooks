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
    public class NetNetClientNetCoreHeaderWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Net.NetClient.NetCoreHeader), L, translator, 0, 0, 2, 2);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "length", _g_get_length);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "compress", _g_get_compress);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "length", _s_set_length);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "compress", _s_set_compress);
            
			XUtils.EndObjectRegister(typeof(Net.NetClient.NetCoreHeader), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Net.NetClient.NetCoreHeader), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Net.NetClient.NetCoreHeader));
			
			
			XUtils.EndClassRegister(typeof(Net.NetClient.NetCoreHeader), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			translator.Push(L, default(Net.NetClient.NetCoreHeader));
			return 1;
			
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_length(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Net.NetClient.NetCoreHeader __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.length);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_compress(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Net.NetClient.NetCoreHeader __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.compress);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_length(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Net.NetClient.NetCoreHeader __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked.length = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_compress(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Net.NetClient.NetCoreHeader __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                __cl_gen_to_be_invoked.compress = (byte)LuaAPI.lua_tonumber(L, 2);
            
                translator.Update(L, 1, __cl_gen_to_be_invoked);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
