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
    public class xcMailNetWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.MailNet), L, translator, 0, 7, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessage", _m_RegisterAllMessage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MailDetail", _m_MailDetail);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ReadMail", _m_ReadMail);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAllMails", _m_GetAllMails);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAllMailPlugs", _m_GetAllMailPlugs);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMailPlugs", _m_GetMailPlugs);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DeleteMail", _m_DeleteMail);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.MailNet), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.MailNet), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.MailNet));
			
			
			XUtils.EndClassRegister(typeof(xc.MailNet), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.MailNet __cl_gen_ret = new xc.MailNet();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.MailNet constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailNet __cl_gen_to_be_invoked = (xc.MailNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterAllMessage(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MailDetail(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailNet __cl_gen_to_be_invoked = (xc.MailNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong mailId = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.MailDetail( mailId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadMail(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailNet __cl_gen_to_be_invoked = (xc.MailNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong mailId = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.ReadMail( mailId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllMails(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailNet __cl_gen_to_be_invoked = (xc.MailNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.GetAllMails(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllMailPlugs(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailNet __cl_gen_to_be_invoked = (xc.MailNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.GetAllMailPlugs(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMailPlugs(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailNet __cl_gen_to_be_invoked = (xc.MailNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong mailId = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.GetMailPlugs( mailId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteMail(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailNet __cl_gen_to_be_invoked = (xc.MailNet)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong mailId = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.DeleteMail( mailId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
