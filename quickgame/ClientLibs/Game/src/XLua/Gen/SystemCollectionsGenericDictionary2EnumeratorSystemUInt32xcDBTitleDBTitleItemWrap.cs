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
    public class SystemCollectionsGenericDictionary_2Enumerator_SystemUInt32xcDBTitleDBTitleItem_Wrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>.Enumerator), L, translator, 0, 2, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MoveNext", _m_MoveNext);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Dispose", _m_Dispose);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Current", _g_get_Current);
            
			
			XUtils.EndObjectRegister(typeof(System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>.Enumerator), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>.Enumerator), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>.Enumerator));
			
			
			XUtils.EndClassRegister(typeof(System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>.Enumerator), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			translator.Push(L, default(System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>.Enumerator));
			return 1;
			
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveNext(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>.Enumerator __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.MoveNext(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>.Enumerator __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Dispose(  );
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Current(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Collections.Generic.Dictionary<uint, xc.DBTitle.DBTitleItem>.Enumerator __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.Push(L, __cl_gen_to_be_invoked.Current);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
