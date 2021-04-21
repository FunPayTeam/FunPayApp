using System;
using System.Collections.Generic;
using System.Text;

namespace FunPayApp.Models
{
    /// <summary>
    /// [行動支付OpenAPI]行動支付地點_易付通金融科技有限公司
    /// </summary>
    public class PaymentApiItem
    {
        /// <summary>
        /// 總筆數
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 回傳資訊
        /// </summary>
        public List<PaymentApiInfo> payment { get; set; }
    }

    /// <summary>
    /// 回傳資訊明細
    /// </summary>
    public class PaymentApiInfo
    {
        /// <summary>
        /// 門市城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 資料識別碼
        /// </summary>
        public string DataID { get; set; }

        /// <summary>
        /// 門市地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// StoreId
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 品牌名稱
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 行動支付載具編碼
        /// </summary>
        public string PayDevice { get; set; }

        /// <summary>
        /// 門市名稱
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 行動支付載具備註
        /// </summary>
        public string PayDeviceNote { get; set; }

        /// <summary>
        /// 上線日期
        /// </summary>
        public string PaymentOnlineDate { get; set; }
    }
}
