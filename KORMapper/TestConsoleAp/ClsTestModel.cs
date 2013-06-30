using KORMapper;

namespace TestConsoleAp
{
    public class ClsTestModel : ClsCommonModel
    {
        [DataMapper("test", Column = "testCol1", Param = "testParam1")]
        public string test = string.Empty;
        [DataMapper("test", Column = "testCol2", Param = "testParam2")]
        public string Test { set; get; }
    }
}
