using KORMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsoleAp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClsTestModel model = new ClsTestModel();
            ClsCommonModel.ModelStruct info = model.GetModelInfo();

            foreach (string str in info.TableInfo["test"])
            {
                Console.WriteLine(str);
            }

            foreach (ClsCommonModel.ParamStruct param in info.Param["test"])
            {
                Console.WriteLine(param.Param);
                Console.WriteLine(param.ParamOrder);
            }
        }
    }
}
