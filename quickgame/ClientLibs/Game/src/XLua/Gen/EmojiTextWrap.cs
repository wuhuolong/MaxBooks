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
    public class EmojiTextWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(EmojiText), L, translator, 0, 5, 8, 5);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "setClip", _m_setClip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerClick", _m_OnPointerClick);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPreferredWidth", _m_GetPreferredWidth);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPreferredHeight", _m_GetPreferredHeight);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnTextChange", _m_OnTextChange);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OrginText", _g_get_OrginText);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OutlineEffectColor", _g_get_OutlineEffectColor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OutlineEffectDistance", _g_get_OutlineEffectDistance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "preferredWidth", _g_get_preferredWidth);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "preferredHeight", _g_get_preferredHeight);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "text", _g_get_text);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onClickHref", _g_get_onClickHref);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "outline", _g_get_outline);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OutlineEffectColor", _s_set_OutlineEffectColor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OutlineEffectDistance", _s_set_OutlineEffectDistance);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "text", _s_set_text);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onClickHref", _s_set_onClickHref);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "outline", _s_set_outline);
            
			XUtils.EndObjectRegister(typeof(EmojiText), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(EmojiText), L, __CreateInstance, 4, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetEmojiTextName", _m_GetEmojiTextName_xlua_st_);
            
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "no_breaking_space", EmojiText.no_breaking_space);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "hrefMatcher", EmojiText.hrefMatcher);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(EmojiText));
			
			
			XUtils.EndClassRegister(typeof(EmojiText), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					EmojiText __cl_gen_ret = new EmojiText();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to EmojiText constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setClip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.RectTransform rect = (UnityEngine.RectTransform)translator.GetObject(L, 2, typeof(UnityEngine.RectTransform));
                    
                    __cl_gen_to_be_invoked.setClip( rect );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerClick(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnPointerClick( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPreferredWidth(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float scaleFactor = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.GetPreferredWidth( scaleFactor );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPreferredHeight(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float scaleFactor = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.GetPreferredHeight( scaleFactor );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnTextChange(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnTextChange(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEmojiTextName_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    EmojiText.EmojiMaterialType var_type;translator.Get(L, 1, out var_type);
                    
                        string __cl_gen_ret = EmojiText.GetEmojiTextName( var_type );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OrginText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.OrginText);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OutlineEffectColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OutlineEffectColor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OutlineEffectDistance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.OutlineEffectDistance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preferredWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.preferredWidth);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preferredHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.preferredHeight);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_text(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.text);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onClickHref(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onClickHref);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_outline(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.outline);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OutlineEffectColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                UnityEngine.Color32 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.OutlineEffectColor = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OutlineEffectDistance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.OutlineEffectDistance = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_text(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.text = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onClickHref(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onClickHref = translator.GetDelegate<EmojiText.OnClickHref>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_outline(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                EmojiText __cl_gen_to_be_invoked = (EmojiText)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.outline = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
