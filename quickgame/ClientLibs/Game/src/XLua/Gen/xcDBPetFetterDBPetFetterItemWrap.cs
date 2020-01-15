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
    public class xcDBPetFetterDBPetFetterItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBPetFetter.DBPetFetterItem), L, translator, 0, 1, 5, 5);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSkills", _m_GetSkills);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PetId", _g_get_PetId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Index", _g_get_Index);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Condition", _g_get_Condition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Attr", _g_get_Attr);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Skills", _g_get_Skills);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PetId", _s_set_PetId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Index", _s_set_Index);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Condition", _s_set_Condition);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Attr", _s_set_Attr);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Skills", _s_set_Skills);
            
			XUtils.EndObjectRegister(typeof(xc.DBPetFetter.DBPetFetterItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBPetFetter.DBPetFetterItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBPetFetter.DBPetFetterItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBPetFetter.DBPetFetterItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBPetFetter.DBPetFetterItem __cl_gen_ret = new xc.DBPetFetter.DBPetFetterItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBPetFetter.DBPetFetterItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkills(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint vocation = LuaAPI.xlua_touint(L, 2);
                    
                        System.Collections.Generic.List<xc.DBPetFetter.FetterSkillItem> __cl_gen_ret = __cl_gen_to_be_invoked.GetSkills( vocation );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PetId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PetId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Index(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Index);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Condition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Condition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Attr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Attr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Skills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Skills);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PetId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PetId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Index(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Index = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Condition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Condition = (System.Collections.Generic.List<xc.DBPet.UnLockPrePetCondition>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBPet.UnLockPrePetCondition>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Attr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Attr = (System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBTextResource.DBAttrItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Skills(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBPetFetter.DBPetFetterItem __cl_gen_to_be_invoked = (xc.DBPetFetter.DBPetFetterItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Skills = (System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<xc.DBPetFetter.FetterSkillItem>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, System.Collections.Generic.List<xc.DBPetFetter.FetterSkillItem>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
