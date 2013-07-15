using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KORMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class AbstractBind
    {
        /// <summary>
        /// バインド情報格納ディクショナリ
        /// </summary>
        protected static Dictionary<string, Type> bindDictionary = new Dictionary<string, Type>();

        /// <summary>
        /// バインド情報格納ディクショナリプロパティ
        /// </summary>
        public static Dictionary<string, Type> BindDictionary { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected internal virtual AbstractBind Bind()
        {
            return this;
        }

        /// <summary>
        /// モデルの名称との紐付け
        /// </summary>
        /// <param name="t">依存関係情報</param>
        /// <returns>現在のインスタンス</returns>
        protected AbstractBind Named(Type t)
        {
            object[] arAt = t.GetCustomAttributes(typeof(InjectAttribute), true);

            if (arAt == null)
            {
                throw new NullReferenceException("InjectAttribute is not exists.");
                
            }
            else
            {
                foreach (var o in arAt)
                {
                    var io = o as InjectAttribute;
                    if (io == null)
                    {
                        throw new InvalidCastException("Attribute can't cast to InjectAttribute.");
                    }

                    if (bindDictionary.ContainsKey(io.Name) == true)
                    {
                        throw new ArgumentException("this Name is exists. Name is " + io.Name);
                    }

                    bindDictionary.Add(io.Name, t);
                }
            }

            return this;
        }
    }
}
