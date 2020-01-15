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
    public class xcuiUIHandBookItemSlotWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.UIHandBookItemSlot), L, translator, 0, 15, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHandBookPicture", _m_SetHandBookPicture);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHandBookInfo", _m_SetHandBookInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHandBookName", _m_SetHandBookName);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHandBookBorder", _m_SetHandBookBorder);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetHandBookPicture", _m_GetHandBookPicture);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHandBookActive", _m_SetHandBookActive);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHandBookStars", _m_SetHandBookStars);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetHandBookFull", _m_SetHandBookFull);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetGrey", _m_SetGrey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetToggleEnabled", _m_SetToggleEnabled);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetToggleOn", _m_SetToggleOn);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetRedPointID", _m_SetRedPointID);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetActivateEff", _m_SetActivateEff);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetUpgradeEff", _m_SetUpgradeEff);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnHandBookItemClick", _g_get_OnHandBookItemClick);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnHandBookItemClick", _s_set_OnHandBookItemClick);
            
			XUtils.EndObjectRegister(typeof(xc.ui.UIHandBookItemSlot), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.UIHandBookItemSlot), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.UIHandBookItemSlot));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.UIHandBookItemSlot), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.UIHandBookItemSlot __cl_gen_ret = new xc.ui.UIHandBookItemSlot();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIHandBookItemSlot constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_SetHandBookPicture(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string picturePath = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetHandBookPicture( picturePath );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Texture>(L, 2)) 
                {
                    UnityEngine.Texture picture = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
                    
                    __cl_gen_to_be_invoked.SetHandBookPicture( picture );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIHandBookItemSlot.SetHandBookPicture!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHandBookInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    string name = LuaAPI.lua_tostring(L, 3);
                    int stars = LuaAPI.xlua_tointeger(L, 4);
                    bool full = LuaAPI.lua_toboolean(L, 5);
                    bool selected = LuaAPI.lua_toboolean(L, 6);
                    
                    __cl_gen_to_be_invoked.SetHandBookInfo( id, name, stars, full, selected );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    string name = LuaAPI.lua_tostring(L, 3);
                    int stars = LuaAPI.xlua_tointeger(L, 4);
                    bool full = LuaAPI.lua_toboolean(L, 5);
                    
                    __cl_gen_to_be_invoked.SetHandBookInfo( id, name, stars, full );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    string name = LuaAPI.lua_tostring(L, 3);
                    int stars = LuaAPI.xlua_tointeger(L, 4);
                    
                    __cl_gen_to_be_invoked.SetHandBookInfo( id, name, stars );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    string name = LuaAPI.lua_tostring(L, 3);
                    
                    __cl_gen_to_be_invoked.SetHandBookInfo( id, name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.UIHandBookItemSlot.SetHandBookInfo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHandBookName(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetHandBookName( name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHandBookBorder(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Sprite border = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
                    
                    __cl_gen_to_be_invoked.SetHandBookBorder( border );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHandBookPicture(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.UI.RawImage __cl_gen_ret = __cl_gen_to_be_invoked.GetHandBookPicture(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHandBookActive(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isActive = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetHandBookActive( isActive );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHandBookStars(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int stars = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SetHandBookStars( stars );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHandBookFull(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool full = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetHandBookFull( full );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGrey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_grey = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetGrey( is_grey );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetToggleEnabled(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool bRet = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetToggleEnabled( bRet );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetToggleOn(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isOn = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetToggleOn( isOn );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRedPointID(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint redPointID = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.SetRedPointID( redPointID );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActivateEff(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool show = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetActivateEff( show );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUpgradeEff(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool show = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.SetUpgradeEff( show );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnHandBookItemClick(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnHandBookItemClick);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnHandBookItemClick(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.UIHandBookItemSlot __cl_gen_to_be_invoked = (xc.ui.UIHandBookItemSlot)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnHandBookItemClick = translator.GetDelegate<System.Func<int, bool>>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
