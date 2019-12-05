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
    public class xcMailManager2Wrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.MailManager2), L, translator, 0, 18, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMailsBySorted", _m_GetMailsBySorted);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMails", _m_GetMails);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetMailNotNew", _m_SetMailNotNew);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMailsCount", _m_GetMailsCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ChangeMailState", _m_ChangeMailState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMailByIndex", _m_GetMailByIndex);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowAttachmentsTipsDialog", _m_ShowAttachmentsTipsDialog);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Delete", _m_Delete);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetMail", _m_GetMail);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetUnReadMailCount", _m_GetUnReadMailCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearAllMail", _m_ClearAllMail);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddMail", _m_AddMail);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHaveWithAccessoriesMail", _m_IsHaveWithAccessoriesMail);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHaveCanDeleteMail", _m_IsHaveCanDeleteMail);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetUnCollectMailCount", _m_GetUnCollectMailCount);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HaveUnReadMails", _m_HaveUnReadMails);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateRedPoint", _m_UpdateRedPoint);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mMails", _g_get_mMails);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mMails", _s_set_mMails);
            
			XUtils.EndObjectRegister(typeof(xc.MailManager2), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.MailManager2), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.MailManager2));
			
			
			XUtils.EndClassRegister(typeof(xc.MailManager2), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.MailManager2 __cl_gen_ret = new xc.MailManager2();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.MailManager2 constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMailsBySorted(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.MailInfo> __cl_gen_ret = __cl_gen_to_be_invoked.GetMailsBySorted(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMails(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.MailInfo> __cl_gen_ret = __cl_gen_to_be_invoked.GetMails(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMailNotNew(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong mailId = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.SetMailNotNew( mailId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_GetMailsCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetMailsCount(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeMailState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint state = LuaAPI.xlua_touint(L, 2);
                    ulong mailId = LuaAPI.lua_touint64(L, 3);
                    
                    __cl_gen_to_be_invoked.ChangeMailState( state, mailId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMailByIndex(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                        xc.MailInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetMailByIndex( index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowAttachmentsTipsDialog(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string tips = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowAttachmentsTipsDialog( tips );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Delete(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong mailId = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.Delete( mailId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMail(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong mailId = LuaAPI.lua_touint64(L, 2);
                    
                        xc.MailInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetMail( mailId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUnReadMailCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetUnReadMailCount(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearAllMail(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearAllMail(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddMail(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.MailInfo info = (xc.MailInfo)translator.GetObject(L, 2, typeof(xc.MailInfo));
                    
                    __cl_gen_to_be_invoked.AddMail( info );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHaveWithAccessoriesMail(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHaveWithAccessoriesMail(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHaveCanDeleteMail(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHaveCanDeleteMail(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUnCollectMailCount(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetUnCollectMailCount(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HaveUnReadMails(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HaveUnReadMails(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateRedPoint(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateRedPoint(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mMails(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mMails);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mMails(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.MailManager2 __cl_gen_to_be_invoked = (xc.MailManager2)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mMails = (System.Collections.Generic.Dictionary<ulong, xc.MailInfo>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ulong, xc.MailInfo>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
