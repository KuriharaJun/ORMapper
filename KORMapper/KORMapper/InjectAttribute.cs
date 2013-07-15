using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KORMapper
{
    /// <summary>
    /// 依存属性クラス
    /// <para>クラス・インターフェース・構造体に対して設定する</para>
    /// </summary>
    /// <example>
    /// <code>
    /// [Inject(Name = "injectName")]
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct,AllowMultiple=false,Inherited=true)]
    public class InjectAttribute : Attribute
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }

        ///// <summary>
        ///// シングルトン
        ///// </summary>
        //public bool Singleton { get; set; }

        ///// <summary>
        ///// 実装
        ///// </summary>
        //public Type ToImple { get; set; }
    }
}
