using MtrSclTs8DataMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using System.Collections.Generic;

namespace MtrSclTs8DataMapperTest
{
    
    
    /// <summary>
    ///ClsDataMapperTest のテスト クラスです。すべての
    ///ClsDataMapperTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class ClsDataMapperTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 追加のテスト属性
        // 
        //テストを作成するときに、次の追加属性を使用することができます:
        //
        //クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //各テストを実行する前にコードを実行するには、TestInitialize を使用
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //各テストを実行した後にコードを実行するには、TestCleanup を使用
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///GetDataToObject のテスト
        ///</summary>
        public void GetDataToObjectTestHelper<T>()
        {
            ClsDataMapper target = new ClsDataMapper(); // TODO: 適切な値に初期化してください
            DataAdapter da = null; // TODO: 適切な値に初期化してください
            List<T> expected = null; // TODO: 適切な値に初期化してください
            List<T> actual;
            actual = target.GetDataToObject<T>(da);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        [TestMethod()]
        public void GetDataToObjectTest()
        {
            GetDataToObjectTestHelper<GenericParameterHelper>();
        }
    }
}
