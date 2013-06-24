using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KORMapper;

namespace TestApp
{
    public class Model
    {
        /// <summary>
        /// 氏名
        /// </summary>
        [DatabaseMap("customer","Name")]
        public string Name { set; get; }

        /// <summary>
        /// 住所
        /// </summary>
        [DatabaseMap("customer", "Address")]
        public string Address { set; get; }
    }
}
