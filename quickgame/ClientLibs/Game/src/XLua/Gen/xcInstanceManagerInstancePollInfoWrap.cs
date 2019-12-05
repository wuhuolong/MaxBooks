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
    public class xcInstanceManagerInstancePollInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.InstanceManager.InstancePollInfo), L, translator, 0, 1, 3, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ChangeVote", _m_ChangeVote);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InstanceId", _g_get_InstanceId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PollId", _g_get_PollId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VoteList", _g_get_VoteList);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InstanceId", _s_set_InstanceId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PollId", _s_set_PollId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "VoteList", _s_set_VoteList);
            
			XUtils.EndObjectRegister(typeof(xc.InstanceManager.InstancePollInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.InstanceManager.InstancePollInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.InstanceManager.InstancePollInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.InstanceManager.InstancePollInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.InstanceManager.InstancePollInfo __cl_gen_ret = new xc.InstanceManager.InstancePollInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.InstanceManager.InstancePollInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeVote(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.InstanceManager.InstancePollInfo __cl_gen_to_be_invoked = (xc.InstanceManager.InstancePollInfo)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint uuid = LuaAPI.xlua_touint(L, 2);
                    uint vote = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.ChangeVote( uuid, vote );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager.InstancePollInfo __cl_gen_to_be_invoked = (xc.InstanceManager.InstancePollInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.InstanceId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PollId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager.InstancePollInfo __cl_gen_to_be_invoked = (xc.InstanceManager.InstancePollInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PollId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VoteList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager.InstancePollInfo __cl_gen_to_be_invoked = (xc.InstanceManager.InstancePollInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VoteList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager.InstancePollInfo __cl_gen_to_be_invoked = (xc.InstanceManager.InstancePollInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PollId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager.InstancePollInfo __cl_gen_to_be_invoked = (xc.InstanceManager.InstancePollInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PollId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_VoteList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.InstanceManager.InstancePollInfo __cl_gen_to_be_invoked = (xc.InstanceManager.InstancePollInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.VoteList = (System.Collections.Generic.Dictionary<uint, uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
