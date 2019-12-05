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
    public class SystemCollectionsGenericKeyValuePair_2_SystemUInt64xcGoodsEquip_Wrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip>), L, translator, 0, 1, 2, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToString", _m_ToString);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Key", _g_get_Key);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Value", _g_get_Value);
            
			
			XUtils.EndObjectRegister(typeof(System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip>), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip>), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip>));
			
			
			XUtils.EndClassRegister(typeof(System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip>), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isuint64(L, 2)) && translator.Assignable<xc.GoodsEquip>(L, 3))
				{
					ulong key = LuaAPI.lua_touint64(L, 2);
					xc.GoodsEquip value = (xc.GoodsEquip)translator.GetObject(L, 3, typeof(xc.GoodsEquip));
					
					System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip> __cl_gen_ret = new System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip>(key, value);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip> constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip> __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Key(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip> __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.lua_pushuint64(L, __cl_gen_to_be_invoked.Key);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Value(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Collections.Generic.KeyValuePair<ulong, xc.GoodsEquip> __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.Push(L, __cl_gen_to_be_invoked.Value);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
