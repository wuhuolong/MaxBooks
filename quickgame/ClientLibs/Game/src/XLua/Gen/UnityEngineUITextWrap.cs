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
    public class UnityEngineUITextWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Text), L, translator, 0, 4, 24, 13);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FontTextureChanged", _m_FontTextureChanged);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetGenerationSettings", _m_GetGenerationSettings);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CalculateLayoutInputHorizontal", _m_CalculateLayoutInputHorizontal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CalculateLayoutInputVertical", _m_CalculateLayoutInputVertical);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "cachedTextGenerator", _g_get_cachedTextGenerator);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "cachedTextGeneratorForLayout", _g_get_cachedTextGeneratorForLayout);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mainTexture", _g_get_mainTexture);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "font", _g_get_font);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "text", _g_get_text);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "supportRichText", _g_get_supportRichText);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "resizeTextForBestFit", _g_get_resizeTextForBestFit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "resizeTextMinSize", _g_get_resizeTextMinSize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "resizeTextMaxSize", _g_get_resizeTextMaxSize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "alignment", _g_get_alignment);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "alignByGeometry", _g_get_alignByGeometry);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "fontSize", _g_get_fontSize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "horizontalOverflow", _g_get_horizontalOverflow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "verticalOverflow", _g_get_verticalOverflow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "lineSpacing", _g_get_lineSpacing);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "fontStyle", _g_get_fontStyle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "pixelsPerUnit", _g_get_pixelsPerUnit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "minWidth", _g_get_minWidth);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "preferredWidth", _g_get_preferredWidth);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "flexibleWidth", _g_get_flexibleWidth);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "minHeight", _g_get_minHeight);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "preferredHeight", _g_get_preferredHeight);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "flexibleHeight", _g_get_flexibleHeight);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "layoutPriority", _g_get_layoutPriority);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "font", _s_set_font);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "text", _s_set_text);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "supportRichText", _s_set_supportRichText);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "resizeTextForBestFit", _s_set_resizeTextForBestFit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "resizeTextMinSize", _s_set_resizeTextMinSize);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "resizeTextMaxSize", _s_set_resizeTextMaxSize);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "alignment", _s_set_alignment);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "alignByGeometry", _s_set_alignByGeometry);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "fontSize", _s_set_fontSize);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "horizontalOverflow", _s_set_horizontalOverflow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "verticalOverflow", _s_set_verticalOverflow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "lineSpacing", _s_set_lineSpacing);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "fontStyle", _s_set_fontStyle);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Text), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.Text), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTextAnchorPivot", _m_GetTextAnchorPivot_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Text));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.Text), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.Text does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FontTextureChanged(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.FontTextureChanged(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGenerationSettings(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector2 extents;translator.Get(L, 2, out extents);
                    
                        UnityEngine.TextGenerationSettings __cl_gen_ret = __cl_gen_to_be_invoked.GetGenerationSettings( extents );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextAnchorPivot_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.TextAnchor anchor;translator.Get(L, 1, out anchor);
                    
                        UnityEngine.Vector2 __cl_gen_ret = UnityEngine.UI.Text.GetTextAnchorPivot( anchor );
                        translator.PushUnityEngineVector2(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateLayoutInputHorizontal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CalculateLayoutInputHorizontal(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateLayoutInputVertical(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CalculateLayoutInputVertical(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cachedTextGenerator(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.cachedTextGenerator);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cachedTextGeneratorForLayout(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.cachedTextGeneratorForLayout);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mainTexture(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mainTexture);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_font(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.font);
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
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.text);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_supportRichText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.supportRichText);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_resizeTextForBestFit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.resizeTextForBestFit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_resizeTextMinSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.resizeTextMinSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_resizeTextMaxSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.resizeTextMaxSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_alignment(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineTextAnchor(L, __cl_gen_to_be_invoked.alignment);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_alignByGeometry(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.alignByGeometry);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fontSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.fontSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_horizontalOverflow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.horizontalOverflow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_verticalOverflow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.verticalOverflow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lineSpacing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.lineSpacing);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fontStyle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.fontStyle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pixelsPerUnit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.pixelsPerUnit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_minWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.minWidth);
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
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.preferredWidth);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flexibleWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.flexibleWidth);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_minHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.minHeight);
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
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.preferredHeight);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flexibleHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.flexibleHeight);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_layoutPriority(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.layoutPriority);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_font(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.font = (UnityEngine.Font)translator.GetObject(L, 2, typeof(UnityEngine.Font));
            
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
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.text = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_supportRichText(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.supportRichText = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_resizeTextForBestFit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.resizeTextForBestFit = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_resizeTextMinSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.resizeTextMinSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_resizeTextMaxSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.resizeTextMaxSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_alignment(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                UnityEngine.TextAnchor __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.alignment = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_alignByGeometry(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.alignByGeometry = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fontSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.fontSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_horizontalOverflow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                UnityEngine.HorizontalWrapMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.horizontalOverflow = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_verticalOverflow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                UnityEngine.VerticalWrapMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.verticalOverflow = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lineSpacing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.lineSpacing = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fontStyle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Text __cl_gen_to_be_invoked = (UnityEngine.UI.Text)translator.FastGetCSObj(L, 1);
                UnityEngine.FontStyle __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.fontStyle = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
