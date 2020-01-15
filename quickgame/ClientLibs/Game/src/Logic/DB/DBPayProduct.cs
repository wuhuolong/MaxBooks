/*----------------------------------------------------------------
// 文件名： DBPayProduct.cs
// 文件功能描述： 商品id表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBPayProduct : DBSqliteTableResource
    {
        public class PayDroductInfo
        {
            public string ProductId; // 商品ID
            public string ProductName;// 商品名称
            public string ProductDesc;// 商品描述
        }
        Dictionary<string, PayDroductInfo> mPayItemInfos = new Dictionary<string, PayDroductInfo>();

        public DBPayProduct(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mPayItemInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mPayItemInfos.Clear();

            if (reader == null || reader.HasRows == false)
                return;

            while (reader.Read())
            {
                
                string channel = GetReaderString(reader, "channel");
                string rmb_low = GetReaderString(reader, "rmb_low");
                string key = string.Format("{0}_{1}", rmb_low, channel);

                var info = new PayDroductInfo();
                info.ProductId = GetReaderString(reader, "product_id");
                info.ProductName = GetReaderString(reader, "product_name");
                info.ProductDesc = GetReaderString(reader, "product_desc");
                mPayItemInfos[key] = info;
            }
        }



        public PayDroductInfo getProductInfo(float rmb_low)
        {
            IBridge brideg = DBOSManager.getOSBridge();
            var channel = brideg.getSDKName();
#if UNITY_ANDROID
            if (Const.Region == RegionType.KOREA)
            {
                if (Application.identifier == GameConst.APK_NAME_KOREA_ONESTORE) 
                    channel = "eagle_468";
                else
                    channel = "google_eagle_468";
            }
            else if (Const.Region == RegionType.HKTW)
            {
                channel = "eagle_427";
            }
#endif
            string key = string.Format("{0}_{1}", rmb_low, channel);
            if (mPayItemInfos.ContainsKey(key))
            {
                return mPayItemInfos[key];
            }
            else
            {
                if (Const.Region == RegionType.CHINA)
                {
                    key = string.Format("{0}_{1}", rmb_low, "undefined");
                    return mPayItemInfos[key];
                }
                else
                    return null;
            }
        }


    }


}
