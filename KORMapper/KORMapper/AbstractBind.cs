using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KORMapper
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AbstractBind
    {
        /// <summary>
        /// バインド情報格納ディクショナリ
        /// </summary>
        protected static Dictionary<string, Type> bindDictionary = new Dictionary<string, Type>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected internal abstract AbstractBind Bind();

        /// <summary>
        /// モデルの名称との紐付け
        /// </summary>
        /// <param name="t">依存関係情報</param>
        /// <returns>現在のインスタンス</returns>
        protected AbstractBind Named(Type t)
        {
            // tよりInject属性のNameを取得する
            //bindDictionary.Add(name, t);

            return this;
        }
    }
}
