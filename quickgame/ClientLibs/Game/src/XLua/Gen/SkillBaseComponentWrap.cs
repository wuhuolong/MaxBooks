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
    public class SkillBaseComponentWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(SkillBaseComponent), L, translator, 0, 4, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddMonoEnableOption", _m_AddMonoEnableOption);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateCycle", _m_UpdateCycle);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DestroyAll", _m_DestroyAll);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SkillAttackInst", _g_get_SkillAttackInst);
            
			
			XUtils.EndObjectRegister(typeof(SkillBaseComponent), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(SkillBaseComponent), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(SkillBaseComponent));
			
			
			XUtils.EndClassRegister(typeof(SkillBaseComponent), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					SkillBaseComponent __cl_gen_ret = new SkillBaseComponent();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to SkillBaseComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddMonoEnableOption(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SkillBaseComponent __cl_gen_to_be_invoked = (SkillBaseComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.MonoBehaviour kTarget = (UnityEngine.MonoBehaviour)translator.GetObject(L, 2, typeof(UnityEngine.MonoBehaviour));
                    bool bEnable = LuaAPI.lua_toboolean(L, 3);
                    float fDelayTime = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    __cl_gen_to_be_invoked.AddMonoEnableOption( kTarget, bEnable, fDelayTime );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateCycle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SkillBaseComponent __cl_gen_to_be_invoked = (SkillBaseComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float elapseTime = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateCycle( elapseTime );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyAll(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SkillBaseComponent __cl_gen_to_be_invoked = (SkillBaseComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.DestroyAll(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SkillBaseComponent __cl_gen_to_be_invoked = (SkillBaseComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.SkillAttackInstance inst = (xc.SkillAttackInstance)translator.GetObject(L, 2, typeof(xc.SkillAttackInstance));
                    
                    __cl_gen_to_be_invoked.Init( inst );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SkillAttackInst(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                SkillBaseComponent __cl_gen_to_be_invoked = (SkillBaseComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SkillAttackInst);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
